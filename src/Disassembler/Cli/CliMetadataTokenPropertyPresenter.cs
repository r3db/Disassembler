using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenPropertyPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenProperty> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenProperty.Flags), "{0}", 5);
                x.Add(nameof(CliMetadataTokenProperty.Name),  indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenProperty.Type),  indexSize == 2 ? "{0:x4}" : "{0:x8}", 68);
            });
        }
    }
}