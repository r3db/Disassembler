using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenMethodDef : CliMetadataTokenBase
    {
        internal CliMetadataTokenMethodDef()
            : base(CliMetadataToken.MethodDef)
        {
        }

        internal uint   Rva;
        internal ushort ImplFlags;
        internal ushort Flags;
        internal uint   Name;
        internal uint   Signature;
        internal uint   ParamList;
    }
}