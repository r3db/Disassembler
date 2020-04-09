using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodImplPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenMethodImpl> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenMethodImpl.Class),             indexSize == 2 ? "{0:x4}" : "{0:x8}",  8);
                x.Add(nameof(CliMetadataTokenMethodImpl.MethodBody),        indexSize == 2 ? "{0:x4}" : "{0:x8}", 10);
                x.Add(nameof(CliMetadataTokenMethodImpl.MethodDeclaration), indexSize == 2 ? "{0:x4}" : "{0:x8}", 65);
            });
        }
    }
}