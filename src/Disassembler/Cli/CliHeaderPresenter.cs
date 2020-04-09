using System;

namespace Disassembler
{
    internal static class CliHeaderPresenter
    {
        internal static void Present(CliHeader header)
        {
            Shell.WriteHeader("CLI Header");
            Shell.WriteItem(nameof(header.Cb),                          header.Cb);
            Shell.WriteItem(nameof(header.MajorRuntimeVersion),         header.MajorRuntimeVersion);
            Shell.WriteItem(nameof(header.MinorRuntimeVersion),         header.MinorRuntimeVersion);
            Shell.WriteItem(nameof(header.MetadataRva),                 header.MetadataRva);
            Shell.WriteItem(nameof(header.MetadataSize),                header.MetadataSize);
            Shell.WriteItem(nameof(header.Flags),                       header.Flags);
            Shell.WriteItem(nameof(header.EntryPointToken),             header.EntryPointToken);
            Shell.WriteItem(nameof(header.ResourcesRva),                header.ResourcesRva);
            Shell.WriteItem(nameof(header.ResourcesSize),               header.ResourcesSize);
            Shell.WriteItem(nameof(header.StrongNameSignatureRva),      header.StrongNameSignatureRva);
            Shell.WriteItem(nameof(header.StrongNameSignatureRva),      header.StrongNameSignatureRva);
            Shell.WriteItem(nameof(header.CodeManagerTableRva),         header.CodeManagerTableRva);
            Shell.WriteItem(nameof(header.CodeManagerTableSize),        header.CodeManagerTableSize);
            Shell.WriteItem(nameof(header.VTableFixupsRva),             header.VTableFixupsRva);
            Shell.WriteItem(nameof(header.VTableFixupsSize),            header.VTableFixupsSize);
            Shell.WriteItem(nameof(header.ExportAddressTableJumpsRva),  header.ExportAddressTableJumpsRva);
            Shell.WriteItem(nameof(header.ExportAddressTableJumpsSize), header.ExportAddressTableJumpsSize);
            Shell.WriteItem(nameof(header.ManagedNativeHeaderRva),      header.ManagedNativeHeaderRva);
            Shell.WriteItem(nameof(header.ManagedNativeHeaderSize),     header.ManagedNativeHeaderSize);
            Shell.WriteFooter();
        }
    }
}