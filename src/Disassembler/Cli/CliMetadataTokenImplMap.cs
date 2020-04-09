using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenImplMap : CliMetadataTokenBase
    {
        internal CliMetadataTokenImplMap()
            : base(CliMetadataToken.ImplMap)
        {
        }

        internal CliMetadataPinvokeMap MappingFlags;
        internal uint                  MemberForwarded;
        internal uint                  ImportName;
        internal uint                  ImportScope;
    }
}