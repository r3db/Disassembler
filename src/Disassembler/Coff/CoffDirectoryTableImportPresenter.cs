using System;

namespace Disassembler
{
    internal static class CoffDirectoryTableImportPresenter
    {
        internal static void Present(CoffDirectoryTableImport table)
        {
            for (int i = 0; i < table.Headers.Count; i++)
            {
                var header = table.Headers[i];
                CoffDirectoryTableImportHeaderPresenter.Present(header);

                Shell.Table($"Imports [{table.ModuleNames[i]}] ({table.LookupTable[i].Count})", table.LookupTable[i], x =>
                {
                    x.Add(nameof(CoffDirectoryTableImportEntry.Entry),        "{0:x8}", 10);
                    x.Add(nameof(CoffDirectoryTableImportEntry.ImportByName), "{0}",    12);
                    x.Add(nameof(CoffDirectoryTableImportEntry.Ordinal),      "{0:x4}", 10);
                    x.Add(nameof(CoffDirectoryTableImportEntry.Hint),         "{0:x4}", 10);
                    x.Add(nameof(CoffDirectoryTableImportEntry.Name),         "'{0}'",  33);
                });
            }
        }
    }
}