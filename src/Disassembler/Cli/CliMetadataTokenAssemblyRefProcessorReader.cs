using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyRefProcessorReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var processor   = reader.ReadUInt32();
                var assemblyRef = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenAssemblyRefProcessor
                {
                    Processor   = processor,
                    AssemblyRef = assemblyRef,
                });
            }

            return result;
        }
    }
}