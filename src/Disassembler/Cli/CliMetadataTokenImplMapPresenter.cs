using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenImplMapPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenImplMap> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenImplMap.MappingFlags),    indexSize == 2 ? "{0:x4}" : "{0:x4}", 12);
                x.Add(nameof(CliMetadataTokenImplMap.MemberForwarded), indexSize == 2 ? "{0:x4}" : "{0:x8}", 15);
                x.Add(nameof(CliMetadataTokenImplMap.ImportName),      indexSize == 2 ? "{0:x4}" : "{0:x8}", 10);
                x.Add(nameof(CliMetadataTokenImplMap.ImportScope),     indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}