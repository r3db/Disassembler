using System;

namespace PeUtility
{
    internal sealed class DosHeader
    {
        internal ushort   Magic;    // Magic number
        internal ushort   Cblp;     // Bytes on last page of file
        internal ushort   Cp;       // Pages in file
        internal ushort   Crlc;     // Relocations
        internal ushort   Cparhdr;  // Size of header in paragraphs
        internal ushort   Minalloc; // Minimum extra paragraphs needed
        internal ushort   Maxalloc; // Maximum extra paragraphs needed
        internal ushort   Ss;       // Initial (relative) SS value
        internal ushort   Sp;       // Initial SP value
        internal ushort   CSum;     // Checksum
        internal ushort   Ip;       // Initial IP value
        internal ushort   Cs;       // Initial (relative) CS value
        internal ushort   Lfarlc;   // File address of relocation table
        internal ushort   Ovno;     // Overlay number
        internal ushort[] Res1;     // Reserved
        internal ushort   Oemid;    // OEM identifier (for e_oeminfo)
        internal ushort   Oeminfo;  // OEM information; Oemid specific
        internal ushort[] Res2;     // Reserved
        internal uint     Lfanew;   // File address of new exe header
    }
}