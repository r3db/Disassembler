using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyRefProcessorPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenAssemblyRefProcessor> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenAssemblyRefProcessor.Processor),   indexSize == 2 ? "{0:x4}" : "{0:x4}",  9);
                x.Add(nameof(CliMetadataTokenAssemblyRefProcessor.AssemblyRef), indexSize == 2 ? "{0:x4}" : "{0:x8}", 75);
            });
        }
    }
}