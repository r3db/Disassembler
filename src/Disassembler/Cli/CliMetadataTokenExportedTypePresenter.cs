using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenExportedTypePresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenExportedType> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenExportedType.Flags),          indexSize == 2 ? "{0:x8}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenExportedType.TypeDefId),      indexSize == 2 ? "{0:x4}" : "{0:x8}",  9);
                x.Add(nameof(CliMetadataTokenExportedType.TypeName),       indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenExportedType.TypeNamespace),  indexSize == 2 ? "{0:x4}" : "{0:x8}", 13);
                x.Add(nameof(CliMetadataTokenExportedType.Implementation), indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}