using System;

namespace Disassembler
{
    internal static class DosHeaderReader
    {
        internal static DosHeader Read(ImageReader reader)
        {
            var magic    = reader.ReadUInt16();
            var cblp     = reader.ReadUInt16();
            var cp       = reader.ReadUInt16();
            var crlc     = reader.ReadUInt16();
            var cparhdr  = reader.ReadUInt16();
            var minalloc = reader.ReadUInt16();
            var maxalloc = reader.ReadUInt16();
            var ss       = reader.ReadUInt16();
            var sp       = reader.ReadUInt16();
            var csum     = reader.ReadUInt16();
            var ip       = reader.ReadUInt16();
            var cs       = reader.ReadUInt16();
            var lfarlc   = reader.ReadUInt16();
            var ovno     = reader.ReadUInt16();
            var res      = reader.ReadUInt16Array(4);
            var oemid    = reader.ReadUInt16();
            var oeminfo  = reader.ReadUInt16();
            var res2     = reader.ReadUInt16Array(10);
            var lfanew   = reader.ReadUInt32();

            return new DosHeader
            {
               Magic    = magic,
               Cblp     = cblp,
               Cp       = cp,
               Crlc     = crlc,
               Cparhdr  = cparhdr,
               Minalloc = minalloc,
               Maxalloc = maxalloc,
               Ss       = ss,
               Sp       = sp,
               CSum     = csum,
               Ip       = ip,
               Cs       = cs,
               Lfarlc   = lfarlc,
               Ovno     = ovno,
               Res1      = res,
               Oemid    = oemid,
               Oeminfo  = oeminfo,
               Res2     = res2,
               Lfanew   = lfanew,
            };
        }
    }
}