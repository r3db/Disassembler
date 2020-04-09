using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenInterfaceImplPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenInterfaceImpl> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenInterfaceImpl.Class),      indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenInterfaceImpl.Interface),  indexSize == 2 ? "{0:x4}" : "{0:x8}", 76);
            });
        }
    }
}