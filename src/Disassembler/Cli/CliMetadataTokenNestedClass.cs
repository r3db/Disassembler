using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenNestedClass : CliMetadataTokenBase
    {
        internal CliMetadataTokenNestedClass()
            : base(CliMetadataToken.NestedClass)
        {
        }

        internal uint NestedClass;
        internal uint EnclosingClass;
    }
}