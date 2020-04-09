using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFieldRvaPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenFieldRva> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenFieldRva.Rva),   indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenFieldRva.Field), indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}