using System;

namespace Disassembler
{
    internal static class CliMetadataHeaderReader
    {
        internal static CliMetadataHeader Read(ImageReader reader)
        {
            var signature       = reader.ReadString(4);
            var majorVersion    = reader.ReadUInt16();
            var minorVersion    = reader.ReadUInt16();
            var extraData       = reader.ReadUInt32();
            var versionLength   = reader.ReadUInt32();
            var version         = reader.ReadString((int)versionLength);
            var flags           = reader.ReadUInt16();
            var numberOfStreams = reader.ReadUInt16();

            return new CliMetadataHeader
            {
                Signature       = signature,
                MajorVersion    = majorVersion,
                MinorVersion    = minorVersion,
                ExtraData       = extraData,
                VersionLength   = versionLength,
                Version         = version,
                Flags           = flags,
                NumberOfStreams = numberOfStreams,
            };
        }
    }
}