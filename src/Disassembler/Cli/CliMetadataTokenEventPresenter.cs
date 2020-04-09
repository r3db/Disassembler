using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenEventPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenEvent> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenEvent.Flags), indexSize == 2 ? "{0:x4}" : "{0:x4}",  5);
                x.Add(nameof(CliMetadataTokenEvent.Name),  indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenEvent.Type),  indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}