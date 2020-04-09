using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenGenericParamReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var number       = reader.ReadUInt16();
                var flags        = reader.ReadUInt16();
                var owner        = reader.ReadMetadataTableIndex(indexSize);
                var name         = reader.ReadMetadataTableIndex(indexSize);

                var nameResolved = reader.ReadStreamStringEntry(name);

                result.Add(new CliMetadataTokenGenericParam
                {
                    Number       = number,
                    Flags        = (CliMetadataGenericParamAttribute)flags,
                    Owner        = owner,
                    Name         = name,

                    NameResolved = nameResolved,
                });
            }

            return result;
        }
    }
}