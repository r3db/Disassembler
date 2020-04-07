using System;

namespace PeUtility
{
    internal sealed class CoffDirectoryTableImportEntry
    {
        internal ulong Entry;
        internal bool ImportByName;
        internal ushort Ordinal;
        internal ushort Hint;
        internal string Name;
    }
}