using System;
using System.Collections.Generic;

namespace PeUtility
{
    internal sealed class CoffDirectoryTableExport : CoffDirectoryTable
    {
        internal CoffDirectoryTableExportHeader       Header;
        internal IList<CoffDirectoryTableExportEntry> Entries;
    }
}