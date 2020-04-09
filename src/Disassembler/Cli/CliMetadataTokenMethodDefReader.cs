using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodDefReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var rva          = reader.ReadUInt32();
                var implFlags    = reader.ReadUInt16();
                var flags        = reader.ReadUInt16();
                var name         = reader.ReadMetadataTableIndex(indexSize);
                var signature    = reader.ReadMetadataTableIndex(indexSize);
                var paramList    = reader.ReadMetadataTableIndex(indexSize);

                var nameResolved = reader.ReadStreamStringEntry(name);

                result.Add(new CliMetadataTokenMethodDef
                {
                    Rva          = rva,
                    ImplFlags    = implFlags,
                    Flags        = flags,
                    Name         = name,
                    Signature    = signature,
                    ParamList    = paramList,

                    NameResolved = nameResolved,
                });
            }

            return result;
        }
    }
}