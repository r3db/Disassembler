using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenInterfaceImplReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var @class     = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var @interface = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenInterfaceImpl
                {
                    Class     = @class,
                    Interface = @interface,
                });
            }

            return result;
        }
    }
}