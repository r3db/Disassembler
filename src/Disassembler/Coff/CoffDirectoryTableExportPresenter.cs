using System;

namespace Disassembler
{
    internal static class CoffDirectoryTableExportPresenter
    {
        internal static void Present(CoffDirectoryTableExport table)
        {
            CoffDirectoryTableExportHeaderPresenter.Present(table.Header);

            Shell.Table("Coff Directory Table Export Entries", table.Entries, x =>
            {
                x.Add(nameof(CoffDirectoryTableExportEntry.Address), "{0:x8}", 8);
                x.Add(nameof(CoffDirectoryTableExportEntry.Ordinal), "{0:x4}", 7);
                x.Add(nameof(CoffDirectoryTableExportEntry.Name),    "'{0}'", 66);
            });
        }
    }
}