using System;

namespace Disassembler
{
    [Flags]
    internal enum CliMetadataEventAttribute
    {
        evSpecialName   = 0x0200, // event is special. Name describes how.

        // Reserved flags for Runtime use only.
        evReservedMask  = 0x0400,
        evRTSpecialName = 0x0400, // Runtime(metadata internal APIs) should check name encoding.
    }
}