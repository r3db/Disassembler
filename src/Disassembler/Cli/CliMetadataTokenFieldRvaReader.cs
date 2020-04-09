using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFieldRvaReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var rva   = reader.ReadUInt32();
                var field = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenFieldRva
                {
                    Rva   = rva,
                    Field = field,
                });
            }

            return result;
        }
    }
}