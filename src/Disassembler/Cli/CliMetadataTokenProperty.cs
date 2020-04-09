using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenProperty : CliMetadataTokenBase
    {
        internal CliMetadataTokenProperty()
            : base(CliMetadataToken.Property)
        {
        }

        internal CliMetadataPropertyAttribute Flags;
        internal uint                         Name;
        internal uint                         Type;

        internal string                       NameResolved;
    }
}