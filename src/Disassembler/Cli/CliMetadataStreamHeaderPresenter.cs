using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataStreamHeaderPresenter
    {
        internal static void Present(IList<CliMetadataStreamHeader> headers)
        {
            Shell.Table("CLI Metadata Stream Header", headers, x =>
            {
                x.Add(nameof(CliMetadataStreamHeader.Offset), "{0:x8}", 8);
                x.Add(nameof(CliMetadataStreamHeader.Size),   "{0:x8}", 8);
                x.Add(nameof(CliMetadataStreamHeader.Name),   "'{0}'", 65);
            });
        }
    }
}