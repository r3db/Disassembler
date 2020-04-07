using System;

namespace PeUtility
{
    internal sealed class CliHeader
    {
        internal uint                  Cb;
        internal ushort                MajorRuntimeVersion;
        internal ushort                MinorRuntimeVersion;
        internal uint                  MetadataRva;
        internal uint                  MetadataSize;
        internal CliHeaderRuntimeFlags Flags;
        internal uint                  EntryPointToken;
        internal uint                  ResourcesRva;
        internal uint                  ResourcesSize;
        internal uint                  StrongNameSignatureRva;
        internal uint                  StrongNameSignatureSize;
        internal uint                  CodeManagerTableRva;
        internal uint                  CodeManagerTableSize;
        internal uint                  VTableFixupsRva;
        internal uint                  VTableFixupsSize;
        internal uint                  ExportAddressTableJumpsRva;
        internal uint                  ExportAddressTableJumpsSize;
        internal uint                  ManagedNativeHeaderRva;
        internal uint                  ManagedNativeHeaderSize;
    }
}