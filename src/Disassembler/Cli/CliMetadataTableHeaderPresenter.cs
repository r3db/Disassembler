using System;

namespace Disassembler
{
    internal static class CliMetadataTableHeaderPresenter
    {
        internal static void Present(CliMetadataTableHeader header)
        {
            Shell.WriteHeader("CLI Metadata Table Header");
            Shell.WriteItem(nameof(header.Reserved),   header.Reserved);
            Shell.WriteItem(nameof(header.Major),      header.Major);
            Shell.WriteItem(nameof(header.Minor),      header.Minor);
            Shell.WriteItem(nameof(header.HeapSizes),  header.HeapSizes);
            Shell.WriteItem(nameof(header.Rid),        header.Rid);
            Shell.WriteItem(nameof(header.MaskValid),  header.MaskValid);
            Shell.WriteItem(nameof(header.MaskSorted), header.MaskSorted);
            Shell.WriteItem(nameof(header.RowCount),   header.RowCount);
            Shell.WriteFooter();
        }
    }
}