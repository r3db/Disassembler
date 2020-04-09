using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyRefReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var majorVersion     = reader.ReadUInt16();
                var minorVersion     = reader.ReadUInt16();
                var buildNumber      = reader.ReadUInt16();
                var revisionNumber   = reader.ReadUInt16();
                var flags            = reader.ReadUInt32();
                var publicKeyOrToken = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var name             = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var culture          = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var hashValue        = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

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
                });
            }

            return result;
        }
    }
}