﻿using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenClassLayoutReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var packingSize = reader.ReadUInt16();
                var classSize   = reader.ReadUInt32();
                var parent      = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenClassLayout
                {
                    PackingSize = packingSize,
                    ClassSize   = classSize,
                    Parent      = parent,
                });
            }

            return result;
        }
    }
}