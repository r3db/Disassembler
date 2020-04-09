using System;

namespace Disassembler
{
    internal sealed class CoffDirectoryTableImportHeader
    {
        internal uint ImportLookupTable;
        internal uint TimeDateStamp;
        internal uint ForwarderChain;
        internal uint NameRva;
        internal uint ImportAddressTable;
    }
}