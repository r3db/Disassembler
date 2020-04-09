using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenManifestResourcePresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenManifestResource> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenManifestResource.Offset),         indexSize == 2 ? "{0:x8}" : "{0:x4}",  8);
                x.Add(nameof(CliMetadataTokenManifestResource.Flags),          indexSize == 2 ? "{0:x8}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenManifestResource.Name),           indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenManifestResource.Implementation), indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}