using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PeUtility
{
    internal static class CoffDirectoryTableImportReader
    {
        internal static CoffDirectoryTableImport Read(BinaryReader reader, CoffOptionalHeader optionalHeader, Func<uint, uint> rvaResolver)
        {
            var headers     = CoffDirectoryTableImportHeaderReader.Read(reader);
            var dllNames    = headers.Select(x => ReadDllName(x.NameRva, rvaResolver, reader)).ToArray();
            var lookupTable = headers.Select(x => ReadlookupTable(optionalHeader, x, rvaResolver, reader)).ToArray();

            return new CoffDirectoryTableImport
            {
                Headers     = headers,
                ModuleNames = dllNames,
                LookupTable = lookupTable
            };
        }

        // Helpers
        private static string ReadDllName(uint rva, Func<uint, uint> rvaResolver, BinaryReader reader)
        {
            reader.BaseStream.Position = rvaResolver(rva);
            return reader.ReadNullTerminatedString();
        }

        private static IList<CoffDirectoryTableImportEntry> ReadlookupTable(CoffOptionalHeader optionalHeader, CoffDirectoryTableImportHeader tableHeader, Func<uint, uint> rvaResolver, BinaryReader reader)
        {
            reader.BaseStream.Position = rvaResolver(tableHeader.ImportLookupTable);

            var result = new List<CoffDirectoryTableImportEntry>();

            while (true)
            {
                var entry        = optionalHeader.Magic == CoffOptionalPeFormat.PE64 ? reader.ReadUInt64() : reader.ReadUInt32();
                var importByName = (entry & 0x8000000000000000) == 0;
                var ordinal      = (ushort)(entry & 0x7FFFFFFFFFFFFFFF);

                if (entry == 0x00)
                {
                    break;
                }

                var hint = 0;
                var name = string.Empty;

                if (importByName)
                {
                    var offset = reader.BaseStream.Position;
                    reader.BaseStream.Position = rvaResolver((uint)entry);

                    hint = reader.ReadUInt16();
                    name = reader.ReadNullTerminatedString();

                    reader.BaseStream.Position = offset;
                }

                result.Add(new CoffDirectoryTableImportEntry
                {
                    Entry        = entry,
                    ImportByName = importByName,
                    Ordinal      = ordinal,
                    Hint         = (ushort)hint,
                    Name         = name
                }); 
            }

            return result;
        }
    }
}