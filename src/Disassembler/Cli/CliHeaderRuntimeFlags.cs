﻿using System;

namespace Disassembler
{
    internal enum CliHeaderRuntimeFlags
    {
        COMIMAGE_FLAGS_ILONLY            = 0x00000001,
        COMIMAGE_FLAGS_32BITREQUIRED     = 0x00000002,
        COMIMAGE_FLAGS_IL_LIBRARY        = 0x00000004,
        COMIMAGE_FLAGS_STRONGNAMESIGNED  = 0x00000008,
        COMIMAGE_FLAGS_NATIVE_ENTRYPOINT = 0x00000010,
        COMIMAGE_FLAGS_TRACKDEBUGDATA    = 0x00010000,
    }
}