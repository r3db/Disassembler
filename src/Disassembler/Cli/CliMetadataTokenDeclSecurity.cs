using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenDeclSecurity : CliMetadataTokenBase
    {
        internal CliMetadataTokenDeclSecurity()
            : base(CliMetadataToken.DeclSecurity)
        {
        }

        internal ushort Action;
        internal uint   Parent;
        internal uint   PermissionSet;
    }
}