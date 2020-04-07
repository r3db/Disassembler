using System;
using System.Collections.Generic;

namespace PeUtility
{
    internal static class CoffSectionHeaderPresenter
    {
        internal static void Present(IList<CoffSectionHeader> sections)
        {
            foreach (var item in sections)
            {
                Shell.WriteHeader($"Coff Section Header [{item.Name}]");
                Shell.WriteItem("Name",                 item.Name);
                Shell.WriteItem("VirtualSize",          item.VirtualSize);
                Shell.WriteItem("VirtualAddress",       item.VirtualAddress);
                Shell.WriteItem("SizeOfRawData",        item.SizeOfRawData);
                Shell.WriteItem("PointerToRawData",     item.PointerToRawData);
                Shell.WriteItem("PointerToRelocations", item.PointerToRelocations);
                Shell.WriteItem("PointerToLinenumbers", item.PointerToLinenumbers);
                Shell.WriteItem("NumberOfLinenumbers",  item.NumberOfLinenumbers);
                Shell.WriteItem("Characteristics",      item.Characteristics);
                Shell.WriteFooter();
            }
        }
    }
}