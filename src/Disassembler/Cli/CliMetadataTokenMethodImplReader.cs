using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodImplReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var @class            = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var methodBody        = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var methodDeclaration = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenMethodImpl
                {
                    Class             = @class,
                    MethodBody        = methodBody,
                    MethodDeclaration = methodDeclaration,
                });
            }

            return result;
        }
    }
}