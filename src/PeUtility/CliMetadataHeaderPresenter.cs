using System;

namespace PeUtility
{
    internal static class CliMetadataHeaderPresenter
    {
        internal static void Present(CliMetadataHeader header)
        {
            Shell.WriteHeader("CLI Metadata Header");
            Shell.WriteItem(nameof(header.Signature),       header.Signature);
            Shell.WriteItem(nameof(header.MajorVersion),    header.MajorVersion);
            Shell.WriteItem(nameof(header.MinorVersion),    header.MinorVersion);
            Shell.WriteItem(nameof(header.ExtraData),       header.ExtraData);
            Shell.WriteItem(nameof(header.VersionLength),   header.VersionLength);
            Shell.WriteItem(nameof(header.Version),         header.Version);
            Shell.WriteItem(nameof(header.Flags),           header.Flags);
            Shell.WriteItem(nameof(header.NumberOfStreams), header.NumberOfStreams);
            Shell.WriteFooter();
        }
    }
}