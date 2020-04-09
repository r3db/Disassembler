using System;
using System.Collections.Generic;
using System.Reflection;

namespace Disassembler
{
    internal static class CliMetadataTokenExportedTypeReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags          = reader.ReadUInt32();
                var typeDefId      = reader.ReadUInt32();
                var typeName       = reader.ReadMetadataTableIndex(indexSize);
                var typeNamespace  = reader.ReadMetadataTableIndex(indexSize);
                var implementation = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenExportedType
                {
                    Flags          = (TypeAttributes)flags,
                    TypeDefId      = typeDefId,
                    TypeName       = typeName,
                    TypeNamespace  = typeNamespace,
                    Implementation = implementation,
                });
            }

            return result;
        }
    }
}