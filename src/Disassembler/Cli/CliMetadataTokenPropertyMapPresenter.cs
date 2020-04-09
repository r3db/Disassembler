using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenPropertyMapPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenPropertyMap> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenPropertyMap.Parent),       indexSize == 2 ? "{0:x4}" : "{0:x8}",   8);
                x.Add(nameof(CliMetadataTokenPropertyMap.PropertyList), indexSize == 2 ? "{0:x4}" : "{0:x8}", 146);
            });
        }
    }
}