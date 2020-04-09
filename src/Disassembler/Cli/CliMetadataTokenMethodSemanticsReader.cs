using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodSemanticsReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var semantics   = reader.ReadUInt16();
                var method      = reader.ReadMetadataTableIndex(indexSize);
                var association = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenMethodSemantics
                {
                    Semantics   = (CliMetadataMethodSemanticsAttribute)semantics,
                    Method      = method,
                    Association = association,
                });
            }

            return result;
        }
    }
}