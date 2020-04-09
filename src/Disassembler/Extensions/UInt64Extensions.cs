using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class UInt64Extensions
    {
        internal static IList<bool> ToBitArray(this ulong value)
        {
            var result = new List<bool>();

            for (int i = 0; i < sizeof(ulong) * 8; i++)
            {
                result.Add((value & 1) == 1);
                value >>= 1;
            }

            return result;
        }
    }
}