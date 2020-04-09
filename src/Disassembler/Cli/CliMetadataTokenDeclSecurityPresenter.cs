using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenDeclSecurityPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenDeclSecurity> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenDeclSecurity.Action),         indexSize == 2 ? "{0:x4}" : "{0:x4}",  8);
                x.Add(nameof(CliMetadataTokenDeclSecurity.Parent),         indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenDeclSecurity.PermissionSet),  indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}