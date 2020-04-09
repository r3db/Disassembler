using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal sealed class CliMetadataTableHeader
    {
        internal uint        Reserved;
        internal byte        Major;
        internal byte        Minor;
        internal byte        HeapSizes;
        internal byte        Rid;
        internal ulong       MaskValid;
        internal IList<bool> MaskValidArray;
        internal ulong       MaskSorted;
        internal IList<bool> MaskSortedArray;
        internal IList<uint> RowCount;
    }
}