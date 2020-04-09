using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenInterfaceImpl : CliMetadataTokenBase
    {
        internal CliMetadataTokenInterfaceImpl()
            : base(CliMetadataToken.InterfaceImpl)
        {
        }

        internal uint Class;
        internal uint Interface;
    }
}