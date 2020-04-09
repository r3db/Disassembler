using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenEventReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags = reader.ReadUInt16();
                var name  = reader.ReadMetadataTableIndex(indexSize);
                var type  = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenEvent
                {
                    Flags = (CliMetadataEventAttribute)flags,
                    Name  = name,
                    Type  = type,
                });
            }

            return result;
        }
    }
}