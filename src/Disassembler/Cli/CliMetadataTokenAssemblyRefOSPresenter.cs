using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyRefOSPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenAssemblyRefOS> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenAssemblyRefOS.OsPlatformId),   indexSize == 2 ? "{0:x4}" : "{0:x4}", 8);
                x.Add(nameof(CliMetadataTokenAssemblyRefOS.OsMajorVersion), indexSize == 2 ? "{0:x4}" : "{0:x8}", 8);
                x.Add(nameof(CliMetadataTokenAssemblyRefOS.OsMinorVersion), indexSize == 2 ? "{0:x4}" : "{0:x8}", 8);
                x.Add(nameof(CliMetadataTokenAssemblyRefOS.AssemblyRef),    indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}