using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodSemanticsPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenMethodSemantics> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenMethodSemantics.Semantics), "{0}", 9);
                x.Add(nameof(CliMetadataTokenMethodSemantics.Method),      indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenMethodSemantics.Association), indexSize == 2 ? "{0:x4}" : "{0:x8}", 64);
            });
        }
    }
}