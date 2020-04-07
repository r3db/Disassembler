using System;

namespace PeUtility
{
    internal static class CoffHeaderPresenter
    {
        internal static void Present(CoffHeader header)
        {
            Shell.WriteHeader("COFF Header");
            Shell.WriteItem(nameof(header.Magic),                header.Magic);
            Shell.WriteItem(nameof(header.Machine),              header.Machine);
            Shell.WriteItem(nameof(header.NumberOfSections),     header.NumberOfSections);
            Shell.WriteItem(nameof(header.TimeDateStamp),        header.TimeDateStamp);
            Shell.WriteItem(nameof(header.PointerToSymbolTable), header.PointerToSymbolTable);
            Shell.WriteItem(nameof(header.NumberOfSymbols),      header.NumberOfSymbols);
            Shell.WriteItem(nameof(header.SizeOfOptionalHeader), header.SizeOfOptionalHeader);
            Shell.WriteItem(nameof(header.Characteristics),      header.Characteristics);
            Shell.WriteFooter();
        }
    }
}
