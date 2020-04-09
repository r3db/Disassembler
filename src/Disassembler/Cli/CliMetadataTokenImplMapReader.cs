using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenImplMapReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var mappingFlags    = reader.ReadUInt16();
                var memberForwarded = reader.ReadMetadataTableIndex(indexSize);
                var importName      = reader.ReadMetadataTableIndex(indexSize);
                var importScope     = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenImplMap
                {
                    MappingFlags    = (CliMetadataPinvokeMap)mappingFlags,
                    MemberForwarded = memberForwarded,
                    ImportName      = importName,
                    ImportScope     = importScope,
                });
            }

            return result;
        }
    }
}