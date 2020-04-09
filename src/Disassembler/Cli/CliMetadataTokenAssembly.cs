using System;
using System.Reflection;

namespace Disassembler
{
    internal sealed class CliMetadataTokenAssembly : CliMetadataTokenBase
    {
        internal CliMetadataTokenAssembly()
            : base(CliMetadataToken.Assembly)
        {
        }

        internal AssemblyHashAlgorithm    HashAlgId;
        internal ushort                   MajorVersion;
        internal ushort                   MinorVersion;
        internal ushort                   BuildNumber;
        internal ushort                   RevisionNumber;
        internal CliMetadataAssemblyFlags Flags;
        internal uint                     PublickKey;
        internal uint                     Name;
        internal uint                     Culture;

        internal string                   NameResolved;
    }
}