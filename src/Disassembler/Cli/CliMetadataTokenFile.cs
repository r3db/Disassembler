using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenFile : CliMetadataTokenBase
    {
        internal CliMetadataTokenFile()
            : base(CliMetadataToken.File)
        {
        }

        internal CliMetadataFileFlags Flags;
        internal uint                 Name;
        internal uint                 HashValue;
    }
}