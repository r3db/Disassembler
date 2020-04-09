using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenNestedClassPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenNestedClass> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenNestedClass.NestedClass),    indexSize == 2 ? "{0:x4}" : "{0:x4}",  11);
                x.Add(nameof(CliMetadataTokenNestedClass.EnclosingClass), indexSize == 2 ? "{0:x4}" : "{0:x8}", 143);
            });
        }
    }
}