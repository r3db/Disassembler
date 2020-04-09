using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenMemberRef : CliMetadataTokenBase
    {
        internal CliMetadataTokenMemberRef()
            : base(CliMetadataToken.MemberRef)
        {
        }

        internal uint   Class;
        internal uint   Name;
        internal uint   Signature;

        internal string NameResolved;
    }
}