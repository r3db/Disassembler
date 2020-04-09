using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFieldLayoutPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenFieldLayout> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenFieldLayout.Offset), indexSize == 2 ? "{0:x8}" : "{0:x4}",  8);
                x.Add(nameof(CliMetadataTokenFieldLayout.Field),  indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
            });
        }
    }
}