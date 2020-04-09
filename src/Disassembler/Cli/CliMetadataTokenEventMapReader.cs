using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenEventMapReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var parent    = reader.ReadMetadataTableIndex(indexSize);
                var eventList = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenEventMap
                {
                    Parent    = parent,
                    EventList = eventList,
                });
            }

            return result;
        }
    }
}