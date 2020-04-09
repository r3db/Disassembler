using System;
using System.Collections.Generic;
using System.Reflection;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
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
                var publickKey     = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var name           = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var culture        = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

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
                });
            }

            return result;
        }
    }
}