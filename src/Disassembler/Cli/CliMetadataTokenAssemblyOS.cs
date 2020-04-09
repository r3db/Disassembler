using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenAssemblyOS : CliMetadataTokenBase
    {
        internal CliMetadataTokenAssemblyOS()
            : base(CliMetadataToken.AssemblyOS)
        {
        }

        internal uint OsPlatformID;
        internal uint OsMajorVersion;
        internal uint OsMinorVersion;
    }
}