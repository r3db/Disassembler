using System;

namespace PeUtility
{
    internal sealed class CoffHeader
    {
        internal string                    Magic;
        internal CoffHeaderMachine         Machine;
        internal ushort                    NumberOfSections;
        internal uint                      TimeDateStamp;
        internal uint                      PointerToSymbolTable;
        internal uint                      NumberOfSymbols;
        internal ushort                    SizeOfOptionalHeader;
        internal CoffHeaderCharacteristics Characteristics;
    }
}