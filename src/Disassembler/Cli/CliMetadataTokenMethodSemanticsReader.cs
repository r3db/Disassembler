using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodSemanticsReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var semantics   = reader.ReadUInt16();
                var method      = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var association = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

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