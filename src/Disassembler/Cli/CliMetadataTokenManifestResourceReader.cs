using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenManifestResourceReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var offset       = reader.ReadUInt32();
                var flags          = reader.ReadUInt32();
                var name           = reader.ReadMetadataTableIndex(indexSize);
                var implementation = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenManifestResource
                {
                    Offset         = offset,
                    Flags          = (CliMetadataManifestResourceFlags)flags,
                    Name           = name,
                    Implementation = implementation,
                });
            }

            return result;
        }
    }
}