using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenGenericParamReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var number = reader.ReadUInt16();
                var flags  = reader.ReadUInt16();
                var owner  = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var name   = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenGenericParam
                {
                    Number = number,
                    Flags  = (CliMetadataGenericParamAttribute)flags,
                    Owner  = owner,
                    Name   = name,
                });
            }

            return result;
        }
    }
}