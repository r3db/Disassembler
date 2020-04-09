using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodSpecPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenMethodSpec> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenMethodSpec.Method),    indexSize == 2 ? "{0:x4}" : "{0:x4}",  8);
                x.Add(nameof(CliMetadataTokenMethodSpec.Signature), indexSize == 2 ? "{0:x4}" : "{0:x8}", 76);
            });
        }
    }
}