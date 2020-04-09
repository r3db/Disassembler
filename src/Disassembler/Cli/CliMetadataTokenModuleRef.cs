using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenModuleRef : CliMetadataTokenBase
    {
        internal CliMetadataTokenModuleRef()
            : base(CliMetadataToken.ModuleRef)
        {
        }

        internal uint Name;
    }
}