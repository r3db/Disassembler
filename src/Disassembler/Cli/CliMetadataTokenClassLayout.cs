using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenClassLayout : CliMetadataTokenBase
    {
        internal CliMetadataTokenClassLayout()
            : base(CliMetadataToken.ClassLayout)
        {
        }

        internal ushort PackingSize;
        internal uint   ClassSize;
        internal uint   Parent;
    }
}