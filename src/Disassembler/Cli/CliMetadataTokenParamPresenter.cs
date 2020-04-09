using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenParamPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenParam> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenParam.Flags),    indexSize == 2 ? "{0:x4}" : "{0:x4}",  5);
                x.Add(nameof(CliMetadataTokenParam.Name),     indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenParam.Sequence), indexSize == 2 ? "{0:x4}" : "{0:x8}", 68);
            });
        }
    }
}