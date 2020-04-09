using System;

namespace Disassembler
{
    internal sealed class CoffDirectoryTableExportEntry
    {
        internal string Name;
        internal ushort Ordinal;
        internal uint   Address;
    }
}