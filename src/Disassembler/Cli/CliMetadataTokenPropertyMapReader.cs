using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenPropertyMapReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var parent       = reader.ReadMetadataTableIndex(indexSize);
                var propertyList = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenPropertyMap
                {
                    Parent       = parent,
                    PropertyList = propertyList,
                });
            }

            return result;
        }
    }
}