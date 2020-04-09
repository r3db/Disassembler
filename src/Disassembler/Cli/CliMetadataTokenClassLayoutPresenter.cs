using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenClassLayoutPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenClassLayout> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenClassLayout.PackingSize), indexSize == 2 ? "{0:x4}" : "{0:x4}", 11);
                x.Add(nameof(CliMetadataTokenClassLayout.ClassSize),   indexSize == 2 ? "{0:x8}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenClassLayout.Parent),      indexSize == 2 ? "{0:x4}" : "{0:x8}", 61);
            });
        }
    }
}