using System;

namespace Disassembler
{
    [Flags]
    internal enum CliMetadataManifestResourceFlags
    {
        mrVisibilityMask = 0x0007,
        mrPublic         = 0x0001, // The Resource is exported from the Assembly.
        mrPrivate        = 0x0002, // The Resource is private to the Assembly.
    }
}