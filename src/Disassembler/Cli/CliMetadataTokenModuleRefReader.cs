﻿using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenModuleRefReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var name = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenModuleRef
                {
                    Name = name,
                });
            }

            return result;
        }
    }
}