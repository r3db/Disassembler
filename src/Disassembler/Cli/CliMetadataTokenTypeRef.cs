using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenTypeRef : CliMetadataTokenBase
    {
        internal CliMetadataTokenTypeRef()
            : base(CliMetadataToken.TypeRef)
        {
        }

        internal uint   ResolutionScope;
        internal uint   TypeName;
        internal uint   TypeNamespace;

        internal string TypeNameResolved;
        internal string TypeNamespaceResolved;
    }
}