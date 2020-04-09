using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenAssembly> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenAssembly.HashAlgId),      "{0}",  9);
                x.Add(nameof(CliMetadataTokenAssembly.MajorVersion),   indexSize == 2 ? "{0:x8}" : "{0:x8}", 12);
                x.Add(nameof(CliMetadataTokenAssembly.MinorVersion),   indexSize == 2 ? "{0:x8}" : "{0:x8}", 12);
                x.Add(nameof(CliMetadataTokenAssembly.BuildNumber),    indexSize == 2 ? "{0:x8}" : "{0:x8}", 11);
                x.Add(nameof(CliMetadataTokenAssembly.RevisionNumber), indexSize == 2 ? "{0:x8}" : "{0:x8}", 14);
                x.Add(nameof(CliMetadataTokenAssembly.Flags),          indexSize == 2 ? "{0:x8}" : "{0:x8}", 12);
                x.Add(nameof(CliMetadataTokenAssembly.PublickKey),     indexSize == 2 ? "{0:x4}" : "{0:x8}", 10);
                x.Add(nameof(CliMetadataTokenAssembly.Name),           indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenAssembly.Culture),        indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);

                x.Add(nameof(CliMetadataTokenAssembly.NameResolved),   "'{0}'", 32);
            });
        }
    }
}