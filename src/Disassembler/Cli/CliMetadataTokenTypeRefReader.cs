using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenTypeRefReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var resolutionScope = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var typeName        = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var typeNamespace   = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenTypeRef
                {
                    ResolutionScope = resolutionScope,
                    TypeName        = typeName,
                    TypeNamespace   = typeNamespace,
                });
            }

            return result;
        }
    }
}