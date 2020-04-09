using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenCustomAttributePresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenCustomAttribute> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenCustomAttribute.Parent), indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenCustomAttribute.Type),   indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenCustomAttribute.Value),  indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}