using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenModuleReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var generation = reader.ReadUInt16();
                var name =      ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var mvid =      ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var encId =     ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var encBaseId = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenModule
                {
                    Generation = generation,
                    Name       = name,
                    Mvid       = mvid,
                    EncId      = encId,
                    EncBaseId  = encBaseId,
                });
            }

            return result;
        }
    }
}