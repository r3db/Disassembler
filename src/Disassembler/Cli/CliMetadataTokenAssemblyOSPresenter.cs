using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyOSPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenAssemblyOS> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenAssemblyOS.OsPlatformID),   indexSize == 2 ? "{0:x8}" : "{0:x4}", 12);
                x.Add(nameof(CliMetadataTokenAssemblyOS.OsMajorVersion), indexSize == 2 ? "{0:x8}" : "{0:x8}", 12);
                x.Add(nameof(CliMetadataTokenAssemblyOS.OsMinorVersion), indexSize == 2 ? "{0:x8}" : "{0:x8}", 65);
            });
        }
    }
}