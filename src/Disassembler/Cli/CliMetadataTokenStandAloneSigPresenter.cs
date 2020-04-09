using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenStandAloneSigPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenStandAloneSig> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenStandAloneSig.Signature), indexSize == 2 ? "{0:x4}" : "{0:x8}", 157);
            });
        }
    }
}