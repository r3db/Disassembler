using System;

namespace Disassembler
{
    internal static class CoffOptionalHeaderPresenter
    {
        internal static void Present(CoffOptionalHeader header)
        {
            Shell.WriteHeader("COFF Optional Header");
            Shell.WriteItem(nameof(header.Magic),                       header.Magic);
            Shell.WriteItem(nameof(header.MajorLinkerVersion),          header.MajorLinkerVersion);
            Shell.WriteItem(nameof(header.MinorLinkerVersion),          header.MinorLinkerVersion);
            Shell.WriteItem(nameof(header.SizeOfCode),                  header.SizeOfCode);
            Shell.WriteItem(nameof(header.SizeOfInitializedData),       header.SizeOfInitializedData);
            Shell.WriteItem(nameof(header.SizeOfUninitializedData),     header.SizeOfUninitializedData);
            Shell.WriteItem(nameof(header.AddressOfEntryPoint),         header.AddressOfEntryPoint);
            Shell.WriteItem(nameof(header.BaseOfCode),                  header.BaseOfCode);
            Shell.WriteItem(nameof(header.BaseOfData),                  header.BaseOfData);
            Shell.WriteItem(nameof(header.ImageBase),                   header.ImageBase);
            Shell.WriteItem(nameof(header.SectionAlignment),            header.SectionAlignment);
            Shell.WriteItem(nameof(header.FileAlignment),               header.FileAlignment);
            Shell.WriteItem(nameof(header.MajorOperatingSystemVersion), header.MajorOperatingSystemVersion);
            Shell.WriteItem(nameof(header.MinorOperatingSystemVersion), header.MinorOperatingSystemVersion);
            Shell.WriteItem(nameof(header.MajorImageVersion),           header.MajorImageVersion);
            Shell.WriteItem(nameof(header.MinorImageVersion),           header.MinorImageVersion);
            Shell.WriteItem(nameof(header.MajorSubsystemVersion),       header.MajorSubsystemVersion);
            Shell.WriteItem(nameof(header.MinorSubsystemVersion),       header.MinorSubsystemVersion);
            Shell.WriteItem(nameof(header.SizeOfImage),                 header.SizeOfImage);
            Shell.WriteItem(nameof(header.SizeOfHeaders),               header.SizeOfHeaders);
            Shell.WriteItem(nameof(header.CheckSum),                    header.CheckSum);
            Shell.WriteItem(nameof(header.Subsystem),                   header.Subsystem);
            Shell.WriteItem(nameof(header.DllCharacteristics),          header.DllCharacteristics);
            Shell.WriteItem(nameof(header.SizeOfStackReserve),          header.SizeOfStackReserve);
            Shell.WriteItem(nameof(header.SizeOfStackCommit),           header.SizeOfStackCommit);
            Shell.WriteItem(nameof(header.SizeOfHeapReserve),           header.SizeOfHeapReserve);
            Shell.WriteItem(nameof(header.SizeOfHeapCommit),            header.SizeOfHeapCommit);
            Shell.WriteItem(nameof(header.LoaderFlags),                 header.LoaderFlags);
            Shell.WriteItem(nameof(header.NumberOfRvaAndSizes),         header.NumberOfRvaAndSizes);
            Shell.WriteFooter();
        }
    }
}