using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenTypeDefPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenTypeDef> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenTypeDef.Flags),                 indexSize == 2 ? "{0:x8}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenTypeDef.TypeName),              indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenTypeDef.TypeNamespace),         indexSize == 2 ? "{0:x4}" : "{0:x8}", 13);
                x.Add(nameof(CliMetadataTokenTypeDef.Extends),               indexSize == 2 ? "{0:x4}" : "{0:x8}",  7);
                x.Add(nameof(CliMetadataTokenTypeDef.FieldList),             indexSize == 2 ? "{0:x4}" : "{0:x8}",  9);
                x.Add(nameof(CliMetadataTokenTypeDef.MethodList),            indexSize == 2 ? "{0:x4}" : "{0:x8}", 10);

                x.Add(nameof(CliMetadataTokenTypeRef.TypeNameResolved),      "'{0}'", 40);
                x.Add(nameof(CliMetadataTokenTypeRef.TypeNamespaceResolved), "'{0}'", 37);
            });
        }
    }
}