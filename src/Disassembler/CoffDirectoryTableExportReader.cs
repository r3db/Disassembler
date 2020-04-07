using System;
using System.Collections.Generic;
using System.IO;

namespace PeUtility
{
    internal static class CoffDirectoryTableExportReader
    {
        internal static CoffDirectoryTableExport Read(BinaryReader reader, Func<uint, uint> rvaResolver)
        {
            var header    = CoffDirectoryTableExportHeaderReader.Read(reader);
            var names     = ReadFunctionNames(header,     rvaResolver, reader);
            var ordinals  = ReadFunctionOrdinals(header,  rvaResolver, reader);
            var addresses = ReadFunctionAddresses(header, rvaResolver, reader);

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
        private static IList<string> ReadFunctionNames(CoffDirectoryTableExportHeader directory, Func<uint, uint> rvaResolver, BinaryReader reader)
        {
            var result = new List<string>();
            var basePosition = rvaResolver(directory.AddressOfNames);

            for (int i = 0; i < directory.NumberOfNames; i++)
            {
                reader.BaseStream.Position = basePosition + sizeof(uint) * i;

                var nameRva = reader.ReadUInt32();

                reader.BaseStream.Position = rvaResolver(nameRva);
                result.Add(reader.ReadNullTerminatedString());
            }

            return result;
        }

        private static IList<ushort> ReadFunctionOrdinals(CoffDirectoryTableExportHeader directory, Func<uint, uint> rvaResolver, BinaryReader reader)
        {
            reader.BaseStream.Position = rvaResolver(directory.AddressOfNameOrdinals);

            var result = new List<ushort>();

            for (int i = 0; i < directory.NumberOfNames; i++)
            {

                result.Add((ushort)(reader.ReadUInt16() + directory.Base));
            }

            return result;
        }

        private static IList<uint> ReadFunctionAddresses(CoffDirectoryTableExportHeader directory, Func<uint, uint> rvaResolver, BinaryReader reader)
        {
            reader.BaseStream.Position = rvaResolver(directory.AddressOfFunctions);

            var result = new List<uint>();

            for (int i = 0; i < directory.NumberOfNames; i++)
            {

                result.Add(reader.ReadUInt32());
            }

            return result;
        }
    }
}