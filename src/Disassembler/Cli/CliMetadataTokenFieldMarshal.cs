using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenFieldMarshal : CliMetadataTokenBase
    {
        internal CliMetadataTokenFieldMarshal()
            : base(CliMetadataToken.FieldMarshal)
        {
        }

        internal uint Parent;
        internal uint NativeType;
    }
}