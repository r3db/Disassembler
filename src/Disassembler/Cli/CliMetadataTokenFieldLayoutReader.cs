using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFieldLayoutReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var offset = reader.ReadUInt32();
                var field  = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenFieldLayout
                {
                    Offset = offset,
                    Field  = field,
                });
            }

            return result;
        }
    }
}