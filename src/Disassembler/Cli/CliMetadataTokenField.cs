using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenField : CliMetadataTokenBase
    {
        internal CliMetadataTokenField()
            : base(CliMetadataToken.Field)
        {
        }

        internal ushort Flags;
        internal uint   Name;
        internal uint   Signature;

        internal string NameResolved;
    }
}