using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenConstantReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var type   = reader.ReadUInt16();
                var parent = reader.ReadMetadataTableIndex(indexSize);
                var value  = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenConstant
                {
                    Type   = type,
                    Parent = parent,
                    Value  = value,
                });
            }

            return result;
        }
    }
}