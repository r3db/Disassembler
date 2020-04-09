using System;

namespace Disassembler
{

    internal sealed class CliMetadataTokenConstant : CliMetadataTokenBase
    {
        internal CliMetadataTokenConstant()
            : base(CliMetadataToken.Constant)
        {
        }

        internal ushort Type;
        internal uint   Parent;
        internal uint   Value;
    }
}