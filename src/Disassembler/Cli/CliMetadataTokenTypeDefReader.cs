using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenTypeDefReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags                 = reader.ReadUInt32();
                var typeName              = reader.ReadMetadataTableIndex(indexSize);
                var typeNamespace         = reader.ReadMetadataTableIndex(indexSize);
                var extends               = reader.ReadMetadataTableIndex(indexSize);
                var fieldList             = reader.ReadMetadataTableIndex(indexSize);
                var methodList            = reader.ReadMetadataTableIndex(indexSize);

                var typeNameResolved      = reader.ReadStreamStringEntry(typeName);
                var typeNamespaceResolved = reader.ReadStreamStringEntry(typeNamespace);

                result.Add(new CliMetadataTokenTypeDef
                {
                    Flags                 = flags,
                    TypeName              = typeName,
                    TypeNamespace         = typeNamespace,
                    Extends               = extends,
                    FieldList             = fieldList,
                    MethodList            = methodList,

                    TypeNameResolved      = typeNameResolved,
                    TypeNamespaceResolved = typeNamespaceResolved,
                });
            }

            return result;
        }
    }
}