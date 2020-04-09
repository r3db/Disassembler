using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenFieldPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenField> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenField.Flags),        indexSize == 2 ? "{0:x4}" : "{0:x4}",  5);
                x.Add(nameof(CliMetadataTokenField.Name),         indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenField.Signature),    indexSize == 2 ? "{0:x4}" : "{0:x8}",  9);
                
                x.Add(nameof(CliMetadataTokenField.NameResolved), "'{0}'", 124);
            });
        }
    }
}