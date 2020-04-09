using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenMethodSpec : CliMetadataTokenBase
    {
        internal CliMetadataTokenMethodSpec()
            : base(CliMetadataToken.MethodSpec)
        {
        }

        internal uint Method;
        internal uint Signature;
    }
}