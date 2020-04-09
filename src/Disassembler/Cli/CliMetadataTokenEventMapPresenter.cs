using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenEventMapPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenEventMap> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenEventMap.Parent),    indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenEventMap.EventList), indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}