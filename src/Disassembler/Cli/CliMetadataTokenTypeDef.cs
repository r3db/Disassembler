using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenTypeDef : CliMetadataTokenBase
    {
        internal CliMetadataTokenTypeDef()
            : base(CliMetadataToken.TypeDef)
        {
        }

        internal uint Flags;
        internal uint TypeName;
        internal uint TypeNamespace;
        internal uint Extends;
        internal uint FieldList;
        internal uint MethodList;
    }
}