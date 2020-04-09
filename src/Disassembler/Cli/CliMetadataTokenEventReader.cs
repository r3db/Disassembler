﻿using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenEventReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var flags = reader.ReadUInt16();
                var name  = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var type  = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenEvent
                {
                    Flags = (CliMetadataEventAttribute)flags,
                    Name  = name,
                    Type  = type,
                });
            }

            return result;
        }
    }
}