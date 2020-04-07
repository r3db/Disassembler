using System;
using System.IO;
using System.Text;

namespace PeUtility
{
    internal static class CliMetadataHeaderReader
    {
        internal static CliMetadataHeader Read(BinaryReader reader)
        {
            var signature       = Encoding.ASCII.GetString(reader.ReadBytes(4));
            var majorVersion    = reader.ReadUInt16();
            var minorVersion    = reader.ReadUInt16();
            var extraData       = reader.ReadUInt32();  // Reserved!
            var versionLength   = reader.ReadUInt32();
            var version         = Encoding.ASCII.GetString(reader.ReadBytes((int)versionLength)).Replace("\0", string.Empty);
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