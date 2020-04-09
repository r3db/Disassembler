using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenTypeSpec : CliMetadataTokenBase
    {
        internal CliMetadataTokenTypeSpec()
            : base(CliMetadataToken.TypeSpec)
        {
        }

        internal uint Signature;
    }
}