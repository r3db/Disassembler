using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Disassembler
{
    internal class Program
    {
        private static void Main()
        {
            const string path = @"C:\Users\r3db\Desktop\dll\odbc32.dll";
            //const string path = "Disassembler.dll";
            const bool present = false;

            using (var br = new ImageReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                var dosHeader  = ReadDosHeader(br, present);
                var coffHeader = ReadCoffHeader(br, dosHeader.Lfanew, present);

                if (coffHeader.SizeOfOptionalHeader == 0)
                {
                    throw new NotSupportedException();
                }

                var coffOptionalHeader          = ReadCoffOptionalHeader(br, present);
                var coffOptionalDataDirectories = ReadCoffOptionalDataDirectories(br, coffOptionalHeader.NumberOfRvaAndSizes, present);
                var coffSectionHeaders          = ReadCoffSectionHeaders(br, coffHeader.NumberOfSections, present);

                br.AddSections(coffSectionHeaders);

                var directoryTables             = ReadCoffDirectoryTables(br, coffOptionalHeader, coffOptionalDataDirectories, present);

                if (present)
                {
                    PresentIL(br, directoryTables);
                }

                //if (present)
                {
                    br.ToRva(coffOptionalHeader.AddressOfEntryPoint);
                    IntelInstructionDecoder.Decode(br, IntelInstructionDecoderMode.x64, 100);
                }
            }
        }

        // Helpers
        private static DosHeader ReadDosHeader(ImageReader reader, bool present)
        {
            var result = DosHeaderReader.Read(reader);
            
            if (present)
            {
                DosHeaderPresenter.Present(result);
            }

            return result;
        }

        private static CoffHeader ReadCoffHeader(ImageReader reader, uint lfanewOffset, bool present)
        {
            var result = CoffHeaderReader.Read(lfanewOffset, reader);
            
            if (present)
            {
                CoffHeaderPresenter.Present(result);
            }

            return result;
        }

        private static CoffOptionalHeader ReadCoffOptionalHeader(ImageReader reader, bool present)
        {
            var result = CoffOptionalHeaderReader.Read(reader);
            
            if (present)
            {
                CoffOptionalHeaderPresenter.Present(result);
            }

            return result;
        }

        private static IList<CoffOptionalDataDirectory> ReadCoffOptionalDataDirectories(ImageReader reader, uint numberOfRvaAndSizes, bool present)
        {
            var result = CoffOptionalDataDirectoryReader.Read(reader, numberOfRvaAndSizes);

            if (present)
            {
                CoffOptionalDataDirectoryPresenter.Present(result);
            }

            return result;
        }

        private static IList<CoffSectionHeader> ReadCoffSectionHeaders(ImageReader reader, uint numberOfSections, bool present)
        {
            var result = new List<CoffSectionHeader>();

            for (int i = 0; i < numberOfSections; i++)
            {
                result.Add(CoffSectionHeaderReader.Read(reader));
            }

            if (present)
            {
                CoffSectionHeaderPresenter.Present(result);
            }

            return result;
        }

        private static IList<CoffDirectoryTable> ReadCoffDirectoryTables(ImageReader reader, CoffOptionalHeader optionalHeader, IList<CoffOptionalDataDirectory> directories, bool present)
        {
            var result = new List<CoffDirectoryTable>();

            foreach (var item in directories)
            {
                if (item.VirtualAddress == 0 || item.Size == 0)
                {
                    continue;
                }

                reader.ToRva(item.VirtualAddress);

                switch (item.Kind)
                {
                    case CoffOptionalDataDirectoryKind.ExportTable:
                    {
                        result.Add(ReadCoffDirectoryTableExport(reader, present));
                        break;
                    }
                    case CoffOptionalDataDirectoryKind.ImportTable:
                    {
                        result.Add(ReadCoffDirectoryTableImport(reader, optionalHeader, present));
                        break;
                    }
                    case CoffOptionalDataDirectoryKind.ClrRuntimeHeader:
                    {
                        result.Add(ReadCoffDirectoryTableCli(reader, present));
                        break;
                    }
                }
            }

            return result;
        }

        private static CoffDirectoryTableExport ReadCoffDirectoryTableExport(ImageReader reader, bool present)
        {
            var table = CoffDirectoryTableExportReader.Read(reader);

            if (present)
            {
                CoffDirectoryTableExportPresenter.Present(table);
            }

            return table;
        }

        private static CoffDirectoryTableImport ReadCoffDirectoryTableImport(ImageReader reader, CoffOptionalHeader optionalHeader, bool present)
        {
            var table = CoffDirectoryTableImportReader.Read(reader, optionalHeader);

            if (present)
            {
                CoffDirectoryTableImportPresenter.Present(table);
            }

            return table;
        }

        private static CoffDirectoryTableCli ReadCoffDirectoryTableCli(ImageReader reader, bool present)
        {
            var cliHeader         = ReadCliHeader(reader, present);
            var cliMetadataHeader = ReadCliMetadataHeader(reader, cliHeader, present);
            var cliMetadataTable  = ReadCliMetadataTableStream(reader, cliHeader.MetadataRva, cliMetadataHeader.NumberOfStreams, present);

            return new CoffDirectoryTableCli
            {
                Header   = cliHeader,
                Metadata = cliMetadataHeader,
                Tables   = cliMetadataTable,
            };
        }

        private static CliHeader ReadCliHeader(ImageReader reader, bool present)
        {
            var header = CliHeaderReader.Read(reader);

            if(present)
            {
                CliHeaderPresenter.Present(header);
            }

            return header;
        }

        private static CliMetadataHeader ReadCliMetadataHeader(ImageReader reader, CliHeader cliHeader, bool present)
        {
            reader.ToRva(cliHeader.MetadataRva);

            var header = CliMetadataHeaderReader.Read(reader);

            if (present)
            {
                CliMetadataHeaderPresenter.Present(header);
            }

            return header;
        }

        private static CliMetadataTableStream ReadCliMetadataTableStream(ImageReader reader, uint metadataRva, ushort numberOfStreams, bool present)
        {
            var result               = new CliMetadataTableStream();
            var streamHeaders        = ReadCliMetadataStreamHeaders(reader, numberOfStreams, present);
            var metadataStreamReader = new MetadataStreamReader(reader, streamHeaders, metadataRva);

            result.Streams = streamHeaders;

            foreach (var item in streamHeaders)
            {
                reader.ToRva(item.Offset + metadataRva);

                if (present)
                {
                    Shell.WriteHeader($"CLI Metadata Table Stream Header [{item.Name}]");
                }

                switch (item.Name)
                {
                    case "#~":
                    {
                        result.DefaultCompressed = ReadCliMetadataTableStreamDefaultCompressed(metadataStreamReader, present);
                        break;
                    }
                    case "#Strings":
                    {
                        // Should not be read directly, It may contain garbage!
                        break;
                    }
                    case "#US":
                    {
                        // Should not be read directly, It may contain garbage!
                        break;
                    }
                    case "#GUID":
                    {
                        // Should not be read directly, It may contain garbage, I'm not sure!
                        break;
                    }
                    case "#Blob":
                    {
                        // Should not be read directly!
                        break;
                    }
                    default:
                    {
                        throw new NotSupportedException();
                    }
                }
            }

            return result;
        }

        private static IList<CliMetadataStreamHeader> ReadCliMetadataStreamHeaders(ImageReader reader, ushort numberOfStreams, bool present)
        {
            var result = CliMetadataStreamHeaderReader.Read(reader, numberOfStreams);

            if (present)
            {
                CliMetadataStreamHeaderPresenter.Present(result);
            }

            return result;
        }

        private static CliMetadataTableStreamDefaultCompressed ReadCliMetadataTableStreamDefaultCompressed(MetadataStreamReader reader, bool present)
        {
            var header = CliMetadataTableHeaderReader.Read(reader);

            if (present)
            {
                CliMetadataTableHeaderPresenter.Present(header);
            }

            var tokens = CliMetadataTokenBaseReader.Read(reader, header, 2);

            if (present)
            {
                CliMetadataTokenBasePresenter.Present(tokens, 2);
            }

            return new CliMetadataTableStreamDefaultCompressed
            {
                Header = header,
                Tokens = tokens,
            };
        }

        private static void PresentIL(ImageReader br, IList<CoffDirectoryTable> directoryTables)
        {
            var table  = directoryTables.OfType<CoffDirectoryTableCli>().FirstOrDefault();
            
            if (table == null)
            {
                return;
            }
            
            var tokens = table.Tables.DefaultCompressed.Tokens.SelectMany(x => x).OfType<CliMetadataTokenMethodDef>().ToArray();
            var reader = new MetadataStreamReader(br, table.Tables.Streams, table.Header.MetadataRva);

            var size = 80;

            foreach (var item in tokens)
            {
                Console.WriteLine("\t|" + new string('-', size) + "|");

                var a = string.Format("\t| RVA : {0:x4}", item.Rva);
                var b = string.Format("\t| Name: '{0}'", item.NameResolved);

                Console.WriteLine(a + new string(' ', size + 2 - a.Length) + "|");
                Console.WriteLine(b + new string(' ', size + 2 - b.Length) + "|");
                Console.WriteLine("\t|" + new string('-', size) + "|");

                foreach (var inst in ILInstructionDecoder.Decode(reader, item.Rva))
                {
                    if (inst.OpCode.Length == 1)
                    {
                        var line = string.Format("\t| IL_{0:x4} 0x{1:x2}      {2}", inst.Offset, inst.OpCode[0], inst.Name);
                        Console.WriteLine(line + new string(' ', size + 2 - line.Length) + "|");
                    }
                    else
                    {
                        var line = string.Format("\t| IL_{0:x4} 0x{1:x2} 0x{2:x2} {3}", inst.Offset, inst.OpCode[0], inst.OpCode[1], inst.Name);
                        Console.WriteLine(line + new string(' ', size + 2 - line.Length) + "|");
                    }
                }

                Console.WriteLine("\t|" + new string('-', size) + "|");
                Console.WriteLine();
            }
        }
    }
}