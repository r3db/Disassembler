using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFilePresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenFile> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenFile.Flags),     indexSize == 2 ? "{0:x8}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenFile.Name),      indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenFile.HashValue), indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}