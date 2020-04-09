using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenParamReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags    = reader.ReadUInt16();
                var name     = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var sequence = reader.ReadUInt16();

                result.Add(new CliMetadataTokenParam
                {
                    Flags    = flags,
                    Name     = name,
                    Sequence = sequence,
                });
            }

            return result;
        }
    }
}