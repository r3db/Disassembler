using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyRefPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenAssemblyRef> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenAssemblyRef.MajorVersion),     indexSize == 2 ? "{0:x4}" : "{0:x4}", 12);
                x.Add(nameof(CliMetadataTokenAssemblyRef.MinorVersion),     indexSize == 2 ? "{0:x4}" : "{0:x4}", 12);
                x.Add(nameof(CliMetadataTokenAssemblyRef.BuildNumber),      indexSize == 2 ? "{0:x4}" : "{0:x4}", 11);
                x.Add(nameof(CliMetadataTokenAssemblyRef.RevisionNumber),   indexSize == 2 ? "{0:x4}" : "{0:x4}", 14);
                x.Add(nameof(CliMetadataTokenAssemblyRef.Flags),            indexSize == 2 ? "{0:x8}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenAssemblyRef.PublicKeyOrToken), indexSize == 2 ? "{0:x4}" : "{0:x8}", 16);
                x.Add(nameof(CliMetadataTokenAssemblyRef.Name),             indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenAssemblyRef.Culture),          indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenAssemblyRef.HashValue),        indexSize == 2 ? "{0:x4}" : "{0:x8}",  9);

                x.Add(nameof(CliMetadataTokenAssemblyRef.NameResolved),     "'{0}'", 30);
            });
        }
    }
}