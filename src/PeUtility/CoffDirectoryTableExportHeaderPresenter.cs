using System;

namespace PeUtility
{
    internal static class CoffDirectoryTableExportHeaderPresenter
    {
        internal static void Present(CoffDirectoryTableExportHeader header)
        {
            Shell.WriteHeader("COFF Directory Table Export");
            Shell.WriteItem("Characteristics",       header.Characteristics);
            Shell.WriteItem("TimeDateStamp",         header.TimeDateStamp);
            Shell.WriteItem("MajorVersion",          header.MajorVersion);
            Shell.WriteItem("MinorVersion",          header.MinorVersion);
            Shell.WriteItem("Name",                  header.Name);
            Shell.WriteItem("Base",                  header.Base);
            Shell.WriteItem("NumberOfFunctions",     header.NumberOfFunctions);
            Shell.WriteItem("NumberOfNames",         header.NumberOfNames);
            Shell.WriteItem("AddressOfFunctions",    header.AddressOfFunctions);
            Shell.WriteItem("AddressOfNames",        header.AddressOfNames);
            Shell.WriteItem("AddressOfNameOrdinals", header.AddressOfNameOrdinals);
            Shell.WriteFooter();
        }
    }
}