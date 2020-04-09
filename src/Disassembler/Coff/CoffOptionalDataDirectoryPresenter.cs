using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CoffOptionalDataDirectoryPresenter
    {
        internal static void Present(IList<CoffOptionalDataDirectory> directories)
        {
            Shell.Table("Coff Data Directories", directories, x =>
            {
                x.Add(nameof(CoffOptionalDataDirectory.VirtualAddress), "{0:x8}", 15);
                x.Add(nameof(CoffOptionalDataDirectory.Size),           "{0:x8}",  8);
                x.Add(nameof(CoffOptionalDataDirectory.Section),        "'{0}'",   8);
                x.Add(nameof(CoffOptionalDataDirectory.Kind),           "'{0}'",  47);
            });
        }
    }
}