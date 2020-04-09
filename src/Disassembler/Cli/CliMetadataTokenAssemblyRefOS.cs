using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenAssemblyRefOS : CliMetadataTokenBase
    {
        internal CliMetadataTokenAssemblyRefOS()
            : base(CliMetadataToken.AssemblyRefOS)
        {
        }

        internal uint OsPlatformId;
        internal uint OsMajorVersion;
        internal uint OsMinorVersion;
        internal uint AssemblyRef;
    }
}