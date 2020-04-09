using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenNestedClassReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var nestedClass    = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var enclosingClass = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenNestedClass
                {
                    NestedClass    = nestedClass,
                    EnclosingClass = enclosingClass,
                });
            }

            return result;
        }
    }
}