using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenNestedClassReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var nestedClass    = reader.ReadMetadataTableIndex(indexSize);
                var enclosingClass = reader.ReadMetadataTableIndex(indexSize);

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