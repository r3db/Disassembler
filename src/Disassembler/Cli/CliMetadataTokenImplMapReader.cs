using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenImplMapReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var mappingFlags    = reader.ReadUInt16();
                var memberForwarded = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var importName      = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var importScope     = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

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