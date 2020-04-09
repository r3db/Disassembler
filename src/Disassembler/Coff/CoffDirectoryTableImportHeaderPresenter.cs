using System;

namespace Disassembler
{
    internal static class CoffDirectoryTableImportHeaderPresenter
    {
        internal static void Present(CoffDirectoryTableImportHeader header)
        {
            Shell.WriteHeader("COFF Directory Table Import Header");
            Shell.WriteItem("ImportLookupTable",  header.ImportLookupTable);
            Shell.WriteItem("TimeDateStamp",      header.TimeDateStamp);
            Shell.WriteItem("ForwarderChain",     header.ForwarderChain);
            Shell.WriteItem("NameRva",            header.NameRva);
            Shell.WriteItem("ImportAddressTable", header.ImportAddressTable);
            Shell.WriteFooter();
        }
    }
}