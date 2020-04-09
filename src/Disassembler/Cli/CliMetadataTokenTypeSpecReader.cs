﻿using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenTypeSpecReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var signature = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenTypeSpec
                {
                    Signature = signature,
                });
            }

            return result;
        }
    }
}