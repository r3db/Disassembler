using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenAssemblyRef : CliMetadataTokenBase
    {
        internal CliMetadataTokenAssemblyRef()
            : base(CliMetadataToken.AssemblyRef)
        {
        }

        internal ushort               MajorVersion;
        internal ushort               MinorVersion;
        internal ushort               BuildNumber;
        internal ushort               RevisionNumber;
        internal CliMetadataFileFlags Flags;
        internal uint                 PublicKeyOrToken;
        internal uint                 Name;
        internal uint                 Culture;
        internal uint                 HashValue;
    }
}