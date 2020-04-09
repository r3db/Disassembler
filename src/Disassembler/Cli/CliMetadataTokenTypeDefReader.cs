using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenTypeDefReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags           = reader.ReadUInt32();
                var typeName        = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var typeNamespace   = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var extends         = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var fieldList       = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var methodList      = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenTypeDef
                {
                    Flags         = flags,
                    TypeName      = typeName,
                    TypeNamespace = typeNamespace,
                    Extends       = extends,
                    FieldList     = fieldList,
                    MethodList    = methodList,
                });
            }

            return result;
        }
    }
}