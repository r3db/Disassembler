using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyRefOSReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var osPlatformId   = reader.ReadUInt32();
                var osMajorVersion = reader.ReadUInt32();
                var osMinorVersion = reader.ReadUInt32();
                var assemblyRef    = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenAssemblyRefOS
                {
                    OsPlatformId   = osPlatformId,
                    OsMajorVersion = osMajorVersion,
                    OsMinorVersion = osMinorVersion,
                    AssemblyRef    = assemblyRef,
                });
            }

            return result;
        }
    }
}