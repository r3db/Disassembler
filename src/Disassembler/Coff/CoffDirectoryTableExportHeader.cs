using System;

namespace Disassembler
{
    internal sealed class CoffDirectoryTableExportHeader
    {
        internal uint   Characteristics;
        internal uint   TimeDateStamp;
        internal ushort MajorVersion;
        internal ushort MinorVersion;
        internal uint   Name;
        internal uint   Base;
        internal uint   NumberOfFunctions;
        internal uint   NumberOfNames;
        internal uint   AddressOfFunctions;
        internal uint   AddressOfNames;
        internal uint   AddressOfNameOrdinals;
    }
}