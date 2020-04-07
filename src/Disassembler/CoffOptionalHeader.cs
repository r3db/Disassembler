using System;

namespace PeUtility
{
    internal sealed class CoffOptionalHeader
    {
        internal CoffOptionalPeFormat           Magic;
        internal byte                           MajorLinkerVersion;
        internal byte                           MinorLinkerVersion;
        internal uint                           SizeOfCode;
        internal uint                           SizeOfInitializedData;
        internal uint                           SizeOfUninitializedData;
        internal uint                           AddressOfEntryPoint;
        internal uint                           BaseOfCode;
        internal uint                           BaseOfData;
        internal ulong                          ImageBase;
        internal uint                           SectionAlignment;
        internal uint                           FileAlignment;
        internal ushort                         MajorOperatingSystemVersion;
        internal ushort                         MinorOperatingSystemVersion;
        internal ushort                         MajorImageVersion;
        internal ushort                         MinorImageVersion;
        internal ushort                         MajorSubsystemVersion;
        internal ushort                         MinorSubsystemVersion;
        internal uint                           Reserved1;
        internal uint                           SizeOfImage;
        internal uint                           SizeOfHeaders;
        internal uint                           CheckSum;
        internal CoffOptionalWindowsSubsystem   Subsystem;
        internal CoffOptionalDllCharacteristics DllCharacteristics;
        internal ulong                          SizeOfStackReserve;
        internal ulong                          SizeOfStackCommit;
        internal ulong                          SizeOfHeapReserve;
        internal ulong                          SizeOfHeapCommit;
        internal uint                           LoaderFlags;
        internal uint                           NumberOfRvaAndSizes;
    }
}