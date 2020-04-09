using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenGenericParamPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenGenericParam> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenGenericParam.Number),       indexSize == 2 ? "{0:x4}" : "{0:x4}", 8);
                x.Add(nameof(CliMetadataTokenGenericParam.Flags),        indexSize == 2 ? "{0:x4}" : "{0:x4}", 8);
                x.Add(nameof(CliMetadataTokenGenericParam.Owner),        indexSize == 2 ? "{0:x4}" : "{0:x8}", 8);
                x.Add(nameof(CliMetadataTokenGenericParam.Name),         indexSize == 2 ? "{0:x4}" : "{0:x8}", 8);

                x.Add(nameof(CliMetadataTokenGenericParam.NameResolved), "'{0}'", 111);
            });
        }
    }
}