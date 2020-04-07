using System;

namespace PeUtility
{
    internal sealed class CoffSectionHeader
    {
        internal string           Name;
        internal uint             VirtualSize;
        internal uint             VirtualAddress;
        internal uint             SizeOfRawData;
        internal uint             PointerToRawData;
        internal uint             PointerToRelocations;
        internal uint             PointerToLinenumbers;
        internal ushort           NumberOfRelocations;
        internal ushort           NumberOfLinenumbers;
        internal CoffSectionFlags Characteristics;
    }
}