using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenParam : CliMetadataTokenBase
    {
        internal CliMetadataTokenParam()
            : base(CliMetadataToken.Param)
        {
        }

        internal ushort Flags;
        internal uint   Name;
        internal ushort Sequence;

        internal string NameResolved;
    }
}