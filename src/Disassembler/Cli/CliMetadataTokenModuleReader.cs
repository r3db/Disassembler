using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenModuleReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var generation   = reader.ReadUInt16();
                var name         = reader.ReadMetadataTableIndex(indexSize);
                var mvid         = reader.ReadMetadataTableIndex(indexSize);
                var encId        = reader.ReadMetadataTableIndex(indexSize);
                var encBaseId    = reader.ReadMetadataTableIndex(indexSize);

                var nameResolved = reader.ReadStreamStringEntry(name);
                var mvidResolved = reader.ReadStreamGuidEntry(mvid);

                result.Add(new CliMetadataTokenModule
                {
                    Generation   = generation,
                    Name         = name,
                    Mvid         = mvid,
                    EncId        = encId,
                    EncBaseId    = encBaseId,

                    NameResolved = nameResolved,
                    MvidResolved = mvidResolved,
                });
            }

            return result;
        }
    }
}