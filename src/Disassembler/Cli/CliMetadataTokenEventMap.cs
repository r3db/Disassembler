using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenEventMap : CliMetadataTokenBase
    {
        internal CliMetadataTokenEventMap()
            : base(CliMetadataToken.EventMap)
        {
        }

        internal uint Parent;
        internal uint EventList;
    }
}