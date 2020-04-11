using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenModule : CliMetadataTokenBase
    {
        internal CliMetadataTokenModule()
            : base(CliMetadataToken.Module)
        {
        }

        internal ushort Generation;
        internal uint   Name;
        internal uint   Mvid;
        internal uint   EncId;
        internal uint   EncBaseId;
        internal string NameResolved;
        internal Guid   MvidResolved;
    }
}