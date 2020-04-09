using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyProcessorPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenAssemblyProcessor> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenAssemblyProcessor.Processor),  indexSize == 2 ? "{0:x4}" : "{0:x8}", 80);
            });
        }
    }
}