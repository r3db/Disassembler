using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenTypeRefReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var resolutionScope       = reader.ReadMetadataTableIndex(indexSize);
                var typeName              = reader.ReadMetadataTableIndex(indexSize);
                var typeNamespace         = reader.ReadMetadataTableIndex(indexSize);

                var typeNameResolved      = reader.ReadStreamStringEntry(typeName);
                var typeNamespaceResolved = reader.ReadStreamStringEntry(typeNamespace);

                result.Add(new CliMetadataTokenTypeRef
                {
                    ResolutionScope       = resolutionScope,
                    TypeName              = typeName,
                    TypeNamespace         = typeNamespace,

                    TypeNameResolved      = typeNameResolved,
                    TypeNamespaceResolved = typeNamespaceResolved,
                });
            }

            return result;
        }
    }
}