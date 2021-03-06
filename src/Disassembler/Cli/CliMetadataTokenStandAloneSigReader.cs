﻿using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenStandAloneSigReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var signature = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenStandAloneSig
                {
                    Signature = signature,
                });
            }

            return result;
        }
    }
}