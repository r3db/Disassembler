using System;
using System.Collections.Generic;
using System.IO;

namespace PeUtility
{
    internal static class CoffDirectoryTableImportHeaderReader
    {
        internal static IList<CoffDirectoryTableImportHeader> Read(BinaryReader reader)
        {
            var result = new List<CoffDirectoryTableImportHeader>();

            while (true)
            {
                var importLookupTable  = reader.ReadUInt32();
                var timeDateStamp      = reader.ReadUInt32();
                var forwarderChain     = reader.ReadUInt32();
                var nameRva            = reader.ReadUInt32();
                var importAddressTable = reader.ReadUInt32();

                var header = new CoffDirectoryTableImportHeader
                {
                    ImportLookupTable  = importLookupTable,
                    TimeDateStamp      = timeDateStamp,
                    ForwarderChain     = forwarderChain,
                    NameRva            = nameRva,
                    ImportAddressTable = importAddressTable,
                };

                if (header.ImportLookupTable == 0x00)
                {
                    break;
                }

                result.Add(header);
            }

            return result;
        }
    }
}