using System;
using System.Collections.Generic;
using System.IO;

namespace Disassembler
{
    internal class Program
    {
        private static void Main()
        {
            //const string path = @"C:\Users\r3db\Desktop\dll\odbc32.dll";
            const string path = "Disassembler.dll";
            const bool present = true;

            using (var br = new ImageReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                var dosHeader                   = ReadDosHeader(br, present);
                var coffHeader                  = ReadCoffHeader(br, dosHeader.Lfanew, present);

                if (coffHeader.SizeOfOptionalHeader == 0)
                {
                    throw new NotSupportedException();
                }

                var coffOptionalHeader          = ReadCoffOptionalHeader(br, present);
                var coffOptionalDataDirectories = ReadCoffOptionalDataDirectories(br, coffOptionalHeader.NumberOfRvaAndSizes, present);
                var coffSectionHeaders          = ReadCoffSectionHeaders(br, coffHeader.NumberOfSections, present);

                br.AddSections(coffSectionHeaders);

                var directoryTables             = ReadCoffDirectoryTables(br, coffOptionalHeader, coffOptionalDataDirectories, present);
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

        private static CoffDirectoryTable ReadCoffDirectoryTableExport(ImageReader reader, bool present)
        {
            var table = CoffDirectoryTableExportReader.Read(reader);

            if (present)
            {
                CoffDirectoryTableExportPresenter.Present(table);
            }

            return table;
        }

        private static CoffDirectoryTable ReadCoffDirectoryTableImport(ImageReader reader, CoffOptionalHeader optionalHeader, bool present)
        {
            var table = CoffDirectoryTableImportReader.Read(reader, optionalHeader);

            if (present)
            {
                CoffDirectoryTableImportPresenter.Present(table);
            }

            return table;
        }

        private static CoffDirectoryTable ReadCoffDirectoryTableCli(ImageReader reader, bool present)
        {
            var cliHeader         = ReadCliHeader(reader, present);
            var cliMetadataHeader = ReadCliMetadataHeader(reader, cliHeader, present);
            var cliMetadataTable  = ReadCliMetadataTableStream(reader, cliMetadataHeader.NumberOfStreams, present);

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

        private static CliMetadataTableStream ReadCliMetadataTableStream(ImageReader reader, ushort numberOfStreams, bool present)
        {
            var result = new CliMetadataTableStream();
            var streamHeaders = ReadCliMetadataStreamHeaders(reader, numberOfStreams, present);

            foreach (var item in streamHeaders)
            {
                if (present)
                {
                    Shell.WriteHeader($"CLI Metadata Table Stream Header [{item.Name}]");
                }

                switch (item.Name)
                {
                    case "#~":
                    {
                        result.DefaultCompressed = ReadCliMetadataTableStreamDefaultCompressed(reader, present);
                        break;
                    }
                    case "#Strings":
                    {
                        break;
                    }
                    case "#US":
                    {
                        break;
                    }
                    case "#GUID":
                    {
                        break;
                    }
                    case "#Blob":
                    {
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

        private static CliMetadataTableStreamDefaultCompressed ReadCliMetadataTableStreamDefaultCompressed(ImageReader reader, bool present)
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
    }
}