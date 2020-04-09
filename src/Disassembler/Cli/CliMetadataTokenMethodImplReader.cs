using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodImplReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var @class            = reader.ReadMetadataTableIndex(indexSize);
                var methodBody        = reader.ReadMetadataTableIndex(indexSize);
                var methodDeclaration = reader.ReadMetadataTableIndex(indexSize);

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