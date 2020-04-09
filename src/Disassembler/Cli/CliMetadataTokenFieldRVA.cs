using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenFieldRva : CliMetadataTokenBase
    {
        internal CliMetadataTokenFieldRva()
            : base(CliMetadataToken.FieldRva)
        {
        }

        internal uint Rva;
        internal uint Field;
    }
}