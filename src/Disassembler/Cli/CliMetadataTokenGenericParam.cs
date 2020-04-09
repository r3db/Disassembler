using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenGenericParam : CliMetadataTokenBase
    {
        internal CliMetadataTokenGenericParam()
            : base(CliMetadataToken.GenericParam)
        {
        }

        internal ushort                           Number;
        internal CliMetadataGenericParamAttribute Flags;
        internal uint                             Owner;
        internal uint                             Name;
        
        internal string                           NameResolved;
    }
}