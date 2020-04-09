using System;

namespace Disassembler
{
    [Flags]
    internal enum CliMetadataFileFlags
    {
        ffContainsMetaData   = 0x0000, // This is not a resource file
        ffContainsNoMetaData = 0x0001, // This is a resource file or other non-metadata-containing file

    }
}