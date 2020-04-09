using System;
using System.Collections.Generic;
using System.Reflection;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var hashAlgId      = reader.ReadUInt32();
                var majorVersion   = reader.ReadUInt16();
                var minorVersion   = reader.ReadUInt16();
                var buildNumber    = reader.ReadUInt16();
                var revisionNumber = reader.ReadUInt16();
                var flags          = reader.ReadUInt32();
                var publickKey     = reader.ReadMetadataTableIndex(indexSize);
                var name           = reader.ReadMetadataTableIndex(indexSize);
                var culture        = reader.ReadMetadataTableIndex(indexSize);

                var nameResolved   = reader.ReadStreamStringEntry(name);

                result.Add(new CliMetadataTokenAssembly
                {
                    HashAlgId      = (AssemblyHashAlgorithm)hashAlgId,
                    MajorVersion   = majorVersion,
                    MinorVersion   = minorVersion,
                    BuildNumber    = buildNumber,
                    RevisionNumber = revisionNumber,
                    Flags          = (CliMetadataAssemblyFlags)flags,
                    PublickKey     = publickKey,
                    Name           = name,
                    Culture        = culture,
                    NameResolved   = nameResolved,
                });
            }

            return result;
        }
    }
}