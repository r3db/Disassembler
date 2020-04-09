using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMemberRefReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var @class       = reader.ReadMetadataTableIndex(indexSize);
                var name         = reader.ReadMetadataTableIndex(indexSize);
                var signature    = reader.ReadMetadataTableIndex(indexSize);

                var nameResolved = reader.ReadStreamStringEntry(name);

                result.Add(new CliMetadataTokenMemberRef
                {
                    Class        = @class,
                    Name         = name,
                    Signature    = signature,

                    NameResolved = nameResolved,
                });
            }

            return result;
        }
    }
}