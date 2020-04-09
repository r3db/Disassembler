using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenModuleRefReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var name         = reader.ReadMetadataTableIndex(indexSize);
                var nameResolved = reader.ReadStreamStringEntry(name);

                result.Add(new CliMetadataTokenModuleRef
                {
                    Name         = name,
                    NameResolved = nameResolved,
                });
            }

            return result;
        }
    }
}