using System;
using System.Collections.Generic;
using System.Linq;

namespace Disassembler
{
    internal static class CliMetadataTableHeaderReader
    {
        internal static CliMetadataTableHeader Read(MetadataStreamReader reader)
        {
            var reserved   = reader.ReadUInt32();
            var major      = reader.ReadByte();
            var minor      = reader.ReadByte();
            var heapSizes  = reader.ReadByte();
            var rid        = reader.ReadByte(); 
            var maskValid  = reader.ReadUInt64();
            var maskSorted = reader.ReadUInt64();

            var maskValidArray       = maskValid.ToBitArray();
            var maskSortedArray      = maskSorted.ToBitArray();
            var maskValidArrayCount  = maskValidArray.Count(x => x == true);
            var maskSortedArrayCount = maskSortedArray.Count(x => x == true);

            var rowCount = new List<uint>();

            for (int i = 0; i < maskValidArrayCount; i++)
            {
                rowCount.Add(reader.ReadUInt32());
            }

            return new CliMetadataTableHeader
            {
                Reserved        = reserved,
                Major           = major,
                Minor           = minor,
                HeapSizes       = heapSizes,
                Rid             = rid,
                MaskValid       = maskValid,
                MaskValidArray  = maskValidArray,
                MaskSorted      = maskSorted,
                MaskSortedArray = maskSortedArray,
                RowCount        = rowCount,
            };
        }
    }
}