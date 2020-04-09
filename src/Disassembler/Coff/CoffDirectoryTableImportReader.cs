using System;
using System.Collections.Generic;
using System.Linq;

namespace Disassembler
{
    internal static class CoffDirectoryTableImportReader
    {
        internal static CoffDirectoryTableImport Read(ImageReader reader, CoffOptionalHeader optionalHeader)
        {
            var headers     = CoffDirectoryTableImportHeaderReader.Read(reader);
            var dllNames    = headers.Select(x => ReadDllName(reader, x.NameRva)).ToArray();
            var lookupTable = headers.Select(x => ReadlookupTable(reader, optionalHeader, x)).ToArray();

            return new CoffDirectoryTableImport
            {
                Headers     = headers,
                ModuleNames = dllNames,
                LookupTable = lookupTable
            };
        }

        // Helpers
        private static string ReadDllName(ImageReader reader, uint rva)
        {
            reader.ToRva(rva);
            return reader.ReadNullTerminatedString();
        }

        private static IList<CoffDirectoryTableImportEntry> ReadlookupTable(ImageReader reader, CoffOptionalHeader optionalHeader, CoffDirectoryTableImportHeader tableHeader)
        {
            var result = new List<CoffDirectoryTableImportEntry>();

            reader.ToRva(tableHeader.ImportAddressTable);

            while (true)
            {
                var entry = ReadlookupTableEntry(reader, optionalHeader);

                if (entry == null)
                {
                    return result;
                }
                
                result.Add(entry); 
            }
        }

        private static CoffDirectoryTableImportEntry ReadlookupTableEntry(ImageReader reader, CoffOptionalHeader optionalHeader)
        {
            var entry        = optionalHeader.Magic == CoffOptionalPeFormat.PE64 ? reader.ReadUInt64() : reader.ReadUInt32();
            var importByName = (entry & 0x8000000000000000) == 0;
            var ordinal      = (ushort)(entry & 0x7FFFFFFFFFFFFFFF);

            if (entry == 0x00)
            {
                return null;
            }

            ushort hint;
            string name;

            if (importByName)
            {
                (hint, name) = ReadDllName(reader, entry);
            }
            else
            {
                throw new NotImplementedException();
            }

            return new CoffDirectoryTableImportEntry
            {
                Entry        = entry,
                ImportByName = importByName,
                Ordinal      = ordinal,
                Hint         = hint,
                Name         = name
            }; 
        }

        private static (ushort hint, string name) ReadDllName(ImageReader reader, ulong entry)
        {
            reader.Save();
            reader.ToRva((uint)entry);

            var hint = reader.ReadUInt16();
            var name = reader.ReadNullTerminatedString();

            reader.Resume();

            return (hint, name);
        }
    }
}