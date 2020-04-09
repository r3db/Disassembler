using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFieldMarshalReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var parent     = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var nativeType = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenFieldMarshal
                {
                    Parent     = parent,
                    NativeType = nativeType,
                });
            }

            return result;
        }
    }
}