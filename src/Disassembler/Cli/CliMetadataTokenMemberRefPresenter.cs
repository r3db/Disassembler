using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMemberRefPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenMemberRef> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenMemberRef.Class),        indexSize == 2 ? "{0:x4}" : "{0:x8}", 8);
                x.Add(nameof(CliMetadataTokenMemberRef.Name),         indexSize == 2 ? "{0:x4}" : "{0:x8}", 8);
                x.Add(nameof(CliMetadataTokenMemberRef.Signature),    indexSize == 2 ? "{0:x4}" : "{0:x8}", 9);

                x.Add(nameof(CliMetadataTokenMemberRef.NameResolved), "'{0}'", 121);
            });
        }
    }
}