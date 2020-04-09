using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenModulePresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenModule> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenModule.Generation),   indexSize == 2 ? "{0:x4}" : "{0:x3}", 10);
                x.Add(nameof(CliMetadataTokenModule.Name),         indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenModule.Mvid),         indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenModule.EncId),        indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenModule.EncBaseId),    indexSize == 2 ? "{0:x4}" : "{0:x8}",  9);

                x.Add(nameof(CliMetadataTokenModule.MvidResolved), "{0}",                                36);
                x.Add(nameof(CliMetadataTokenModule.NameResolved), "'{0}'",                              58);
            });
        }
    }
}