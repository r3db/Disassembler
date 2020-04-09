using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal sealed class CoffDirectoryTableImport : CoffDirectoryTable
    {
        internal IList<CoffDirectoryTableImportHeader>       Headers;
        internal IList<string>                               ModuleNames;
        internal IList<IList<CoffDirectoryTableImportEntry>> LookupTable;
    }
}