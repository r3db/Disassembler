using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFieldMarshalPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenFieldMarshal> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenFieldMarshal.Parent),     indexSize == 2 ? "{0:x4}" : "{0:x4}",  8);
                x.Add(nameof(CliMetadataTokenFieldMarshal.NativeType), indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}