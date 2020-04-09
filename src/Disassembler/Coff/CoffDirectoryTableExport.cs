using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal sealed class CoffDirectoryTableExport : CoffDirectoryTable
    {
        internal CoffDirectoryTableExportHeader       Header;
        internal IList<CoffDirectoryTableExportEntry> Entries;
    }
}