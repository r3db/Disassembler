using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenConstantPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenConstant> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenConstant.Type),   indexSize == 2 ? "{0:x4}" : "{0:x4}",  8);
                x.Add(nameof(CliMetadataTokenConstant.Parent), indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenConstant.Value),  indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}