using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenFieldLayout : CliMetadataTokenBase
    {
        internal CliMetadataTokenFieldLayout()
            : base(CliMetadataToken.FieldLayout)
        {
        }

        internal uint Offset;
        internal uint Field;
    }
}