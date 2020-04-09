using System;

namespace Disassembler
{
    [Flags]
    internal enum CoffOptionalDllCharacteristics
    {
        Reserved1                                      = 0x0001, //Reserved, must be zero.
        Reserved2                                      = 0x0002, //Reserved, must be zero.
        Reserved3                                      = 0x0004, //Reserved, must be zero.
        Reserved4                                      = 0x0008, //Reserved, must be zero.
        IMAGE_DLLCHARACTERISTICS_HIGH_ENTROPY_VA       = 0x0020, // TImage can handle a high entropy 64-bit virtual address space.
        IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE          = 0x0040, // TDLL can be relocated at load time.
        IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY       = 0x0080, // TCode Integrity checks are enforced.
        IMAGE_DLLCHARACTERISTICS_NX_COMPAT             = 0x0100, // TImage is NX compatible.
        IMAGE_DLLCHARACTERISTICS_NO_ISOLATION          = 0x0200, // TIsolation aware, but do not isolate the image.
        IMAGE_DLLCHARACTERISTICS_NO_SEH                = 0x0400, // TDoes not use structured exception (SE) handling. No SE handler may be called in this image.
        IMAGE_DLLCHARACTERISTICS_NO_BIND               = 0x0800, // TDo not bind the image.
        IMAGE_DLLCHARACTERISTICS_APPCONTAINER          = 0x1000, // TImage must execute in an AppContainer.
        IMAGE_DLLCHARACTERISTICS_WDM_DRIVER            = 0x2000, // A WDM driver.
        IMAGE_DLLCHARACTERISTICS_GUARD_CF              = 0x4000, // Image supports Control Flow Guard.
        IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000, // Terminal Server aware.
    }
}