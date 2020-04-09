using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenEvent : CliMetadataTokenBase
    {
        internal CliMetadataTokenEvent()
            : base(CliMetadataToken.Event)
        {
        }

        internal CliMetadataEventAttribute Flags;
        internal uint                      Name;
        internal uint                      Type;
    }
}