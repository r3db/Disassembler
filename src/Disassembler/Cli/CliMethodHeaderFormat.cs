using System;

namespace Disassembler
{
    [Flags]
    internal enum CliMethodHeaderFormat
    {
        CorILMethod_TinyFormat = 0x2,
        CorILMethod_FatFormat  = 0x3,
        CorILMethod_MoreSects  = 0x8,
        CorILMethod_InitLocals = 0x10
    }
}