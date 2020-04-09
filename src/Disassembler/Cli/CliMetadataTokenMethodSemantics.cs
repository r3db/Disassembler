using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenMethodSemantics : CliMetadataTokenBase
    {
        internal CliMetadataTokenMethodSemantics()
            : base(CliMetadataToken.MethodSemantics)
        {
        }

        internal CliMetadataMethodSemanticsAttribute Semantics;
        internal uint                                Method;
        internal uint                                Association;
    }
}