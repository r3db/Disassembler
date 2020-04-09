using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenAssemblyOSReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var osPlatformID   = reader.ReadUInt32();
                var osMajorVersion = reader.ReadUInt32();
                var osMinorVersion = reader.ReadUInt32();

                result.Add(new CliMetadataTokenAssemblyOS
                {
                    OsPlatformID   = osPlatformID,
                    OsMajorVersion = osMajorVersion,
                    OsMinorVersion = osMinorVersion,
                });
            }

            return result;
        }
    }
}