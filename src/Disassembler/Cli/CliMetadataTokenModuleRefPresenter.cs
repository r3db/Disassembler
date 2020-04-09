using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenModuleRefPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenModuleRef> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenModuleRef.Name), indexSize == 2 ? "{0:x4}" : "{0:x4}",  80);
            });
        }
    }
}