using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMemberRefReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var @class    = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var name      = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var signature = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenMemberRef
                {
                    Class     = @class,
                    Name      = name,
                    Signature = signature,
                });
            }

            return result;
        }
    }
}