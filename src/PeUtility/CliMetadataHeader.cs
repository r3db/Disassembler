using System;

namespace PeUtility
{
    internal sealed class CliMetadataHeader
    {
        internal string Signature;
        internal ushort MajorVersion;
        internal ushort MinorVersion;
        internal uint   ExtraData;      // Reserved!
        internal uint   VersionLength;
        internal string Version;
        internal ushort Flags;
        internal ushort NumberOfStreams;
    }
}