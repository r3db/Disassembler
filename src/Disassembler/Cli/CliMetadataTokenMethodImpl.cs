using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenMethodImpl : CliMetadataTokenBase
    {
        internal CliMetadataTokenMethodImpl()
            : base(CliMetadataToken.MethodImpl)
        {
        }

        internal uint Class;
        internal uint MethodBody;
        internal uint MethodDeclaration;
    }
}