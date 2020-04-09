using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodDefPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenMethodDef> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenMethodDef.Rva),          indexSize == 2 ? "{0:x8}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenMethodDef.ImplFlags),    indexSize == 2 ? "{0:x4}" : "{0:x4}",  9);
                x.Add(nameof(CliMetadataTokenMethodDef.Flags),        indexSize == 2 ? "{0:x4}" : "{0:x4}",  5);
                x.Add(nameof(CliMetadataTokenMethodDef.Name),         indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenMethodDef.Signature),    indexSize == 2 ? "{0:x4}" : "{0:x8}",  9);
                x.Add(nameof(CliMetadataTokenMethodDef.ParamList),    indexSize == 2 ? "{0:x4}" : "{0:x8}",  9);

                x.Add(nameof(CliMetadataTokenMethodDef.NameResolved), "'{0}'", 89);
            });
        }
    }
}