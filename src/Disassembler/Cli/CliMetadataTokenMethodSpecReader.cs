using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodSpecReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var method    = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var signature = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenMethodSpec
                {
                    Method    = method,
                    Signature = signature,
                });
            }

            return result;
        }
    }
}