using System;

namespace Disassembler
{
    internal sealed class CoffOptionalDataDirectory
    {
        internal CoffOptionalDataDirectoryKind Kind;
        internal string                        Section;
        internal uint                          VirtualAddress;
        internal uint                          Size;
    }
}