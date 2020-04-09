using System;

namespace Disassembler
{
    internal sealed class CliMetadataStreamHeader
    {
        internal uint   Offset;
        internal uint   Size;
        internal string Name;
    }
}