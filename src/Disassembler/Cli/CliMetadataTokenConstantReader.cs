using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenConstantReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var type   = reader.ReadUInt16();
                var parent = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var value  = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

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