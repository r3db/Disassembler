using System;

namespace Disassembler
{
    internal enum CoffOptionalPeFormat
    { 
        PE32 = 0x10b,
        PE64 = 0x20b,
        ROM  = 0x107,
    }
}