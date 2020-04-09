using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFileReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags     = reader.ReadUInt32();
                var name      = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var hashValue = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenFile
                {
                    Flags     = (CliMetadataFileFlags)flags,
                    Name      = name,
                    HashValue = hashValue,
                });
            }

            return result;
        }
    }
}