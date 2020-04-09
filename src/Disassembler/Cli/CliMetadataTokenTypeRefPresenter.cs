using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenTypeRefPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenTypeRef> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenTypeRef.ResolutionScope), indexSize == 2 ? "{0:x4}" : "{0:x8}", 15);
                x.Add(nameof(CliMetadataTokenTypeRef.TypeName),        indexSize == 2 ? "{0:x4}" : "{0:x8}", 8);
                x.Add(nameof(CliMetadataTokenTypeRef.TypeNamespace),   indexSize == 2 ? "{0:x4}" : "{0:x8}", 58);
            });
        }
    }
}