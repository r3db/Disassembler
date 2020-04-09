using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenCustomAttributeReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var parent = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var type   = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var value  = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

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