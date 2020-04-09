using System;
using System.Collections.Generic;
using System.Reflection;

namespace Disassembler
{
    internal static class CliMetadataTokenExportedTypeReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags          = reader.ReadUInt32();
                var typeDefId      = ImageReaderUtility.ReadMetadataTableIndex(reader, 4);
                var typeName       = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var typeNamespace  = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var implementation = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

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