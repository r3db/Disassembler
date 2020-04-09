using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFieldReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags        = reader.ReadUInt16();
                var name         = reader.ReadMetadataTableIndex(indexSize);
                var signature    = reader.ReadMetadataTableIndex(indexSize);

                var nameResolved = reader.ReadStreamStringEntry(name);

                result.Add(new CliMetadataTokenField
                {
                    Flags        = flags,
                    Name         = name,
                    Signature    = signature,

                    NameResolved = nameResolved,
                });
            }

            return result;
        }
    }
}