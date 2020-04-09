using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenCustomAttributeReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var parent = reader.ReadMetadataTableIndex(indexSize);
                var type   = reader.ReadMetadataTableIndex(indexSize);
                var value  = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenCustomAttribute
                {
                    Parent = parent,
                    Type   = type,
                    Value  = value,
                });
            }

            return result;
        }
    }
}