using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenManifestResource : CliMetadataTokenBase
    {
        internal CliMetadataTokenManifestResource()
            : base(CliMetadataToken.ManifestResource)
        {
        }

        internal uint                             Offset;
        internal CliMetadataManifestResourceFlags Flags;
        internal uint                             Name;
        internal uint                             Implementation;
    }
}