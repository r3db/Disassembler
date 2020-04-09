using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CoffDirectoryTableExportReader
    {
        internal static CoffDirectoryTableExport Read(ImageReader reader)
        {
            var header    = CoffDirectoryTableExportHeaderReader.Read(reader);
            var names     = ReadFunctionNames(reader, header);
            var ordinals  = ReadFunctionOrdinals(reader, header);
            var addresses = ReadFunctionAddresses(reader, header);

            var entries = new List<CoffDirectoryTableExportEntry>();

            for (int i = 0; i < header.NumberOfNames; i++)
            {
                entries.Add(new CoffDirectoryTableExportEntry
                {
                    Name    = names[i],
                    Ordinal = ordinals[i],
                    Address = addresses[i],
                });
            }

            return new CoffDirectoryTableExport
            {
                Header  = header,
                Entries = entries,
            };
        }

        // Helpers
        private static IList<string> ReadFunctionNames(ImageReader reader, CoffDirectoryTableExportHeader directory)
        {
            var result = new List<string>();

            for (int i = 0; i < directory.NumberOfNames; i++)
            {
                reader.ToRva((uint)(directory.AddressOfNames + sizeof(uint) * i));
                reader.ToRva(reader.ReadUInt32());

                result.Add(reader.ReadNullTerminatedString());
            }

            return result;
        }

        private static IList<ushort> ReadFunctionOrdinals(ImageReader reader, CoffDirectoryTableExportHeader directory)
        {
            var result = new List<ushort>();

            reader.ToRva(directory.AddressOfNameOrdinals);

            for (int i = 0; i < directory.NumberOfNames; i++)
            {
                result.Add((ushort)(reader.ReadUInt16() + directory.Base));
            }

            return result;
        }

        private static IList<uint> ReadFunctionAddresses(ImageReader reader, CoffDirectoryTableExportHeader directory)
        {
            var result = new List<uint>();

            reader.ToRva(directory.AddressOfFunctions);

            for (int i = 0; i < directory.NumberOfNames; i++)
            {
                result.Add(reader.ReadUInt32());
            }

            return result;
        }
    }
}