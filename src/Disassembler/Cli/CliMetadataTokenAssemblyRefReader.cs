using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyRefReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var majorVersion     = reader.ReadUInt16();
                var minorVersion     = reader.ReadUInt16();
                var buildNumber      = reader.ReadUInt16();
                var revisionNumber   = reader.ReadUInt16();
                var flags            = reader.ReadUInt32();
                var publicKeyOrToken = reader.ReadMetadataTableIndex(indexSize);
                var name             = reader.ReadMetadataTableIndex(indexSize);
                var culture          = reader.ReadMetadataTableIndex(indexSize);
                var hashValue        = reader.ReadMetadataTableIndex(indexSize);

                var nameResolved     = reader.ReadStreamStringEntry(name);

                result.Add(new CliMetadataTokenAssemblyRef
                {
                    MajorVersion     = majorVersion,
                    MinorVersion     = minorVersion,
                    BuildNumber      = buildNumber,
                    RevisionNumber   = revisionNumber,
                    Flags            = (CliMetadataFileFlags)flags,
                    PublicKeyOrToken = publicKeyOrToken,
                    Name             = name,
                    Culture          = culture,
                    HashValue        = hashValue,

                    NameResolved     = nameResolved,
                });
            }

            return result;
        }
    }
}