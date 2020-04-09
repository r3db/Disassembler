using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyProcessorReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var processor = reader.ReadUInt32();

                result.Add(new CliMetadataTokenAssemblyProcessor
                {
                    Processor = processor,
                });
            }

            return result;
        }
    }
}