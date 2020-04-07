using System;
using System.IO;

namespace PeUtility
{
    internal static class CliHeaderReader
    {
        internal static CliHeader Read(BinaryReader reader)
        {
            var cb                          = reader.ReadUInt32();
            var majorRuntimeVersion         = reader.ReadUInt16();
            var minorRuntimeVersion         = reader.ReadUInt16();
            var metadataRva                 = reader.ReadUInt32();
            var metadataSize                = reader.ReadUInt32();
            var flags                       = (CliHeaderRuntimeFlags)reader.ReadUInt32();
            var entryPointToken             = reader.ReadUInt32();
            var resourcesRva                = reader.ReadUInt32();
            var resourcesSize               = reader.ReadUInt32();
            var strongNameSignatureRva      = reader.ReadUInt32();
            var strongNameSignatureSize     = reader.ReadUInt32();
            var codeManagerTableRva         = reader.ReadUInt32();
            var codeManagerTableSize        = reader.ReadUInt32();
            var vTableFixupsRva             = reader.ReadUInt32();
            var vTableFixupsSize            = reader.ReadUInt32();
            var exportAddressTableJumpsRva  = reader.ReadUInt32();
            var exportAddressTableJumpsSize = reader.ReadUInt32();
            var managedNativeHeaderRva      = reader.ReadUInt32();
            var managedNativeHeaderSize     = reader.ReadUInt32();

            return new CliHeader 
            {
                Cb                          = cb,
                MajorRuntimeVersion         = majorRuntimeVersion,
                MinorRuntimeVersion         = minorRuntimeVersion,
                MetadataRva                 = metadataRva,
                MetadataSize                = metadataSize,
                Flags                       = flags,
                EntryPointToken             = entryPointToken,
                ResourcesRva                = resourcesRva,
                ResourcesSize               = resourcesSize,
                StrongNameSignatureRva      = strongNameSignatureRva,
                StrongNameSignatureSize     = strongNameSignatureSize,
                CodeManagerTableRva         = codeManagerTableRva,
                CodeManagerTableSize        = codeManagerTableSize,
                VTableFixupsRva             = vTableFixupsRva,
                VTableFixupsSize            = vTableFixupsSize,
                ExportAddressTableJumpsRva  = exportAddressTableJumpsRva,
                ExportAddressTableJumpsSize = exportAddressTableJumpsSize,
                ManagedNativeHeaderRva      = managedNativeHeaderRva,
                ManagedNativeHeaderSize     = managedNativeHeaderSize,
            };
        }
    }
}