using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenCustomAttribute : CliMetadataTokenBase
    {
        internal CliMetadataTokenCustomAttribute()
            : base(CliMetadataToken.CustomAttribute)
        {
        }

        internal uint Parent;
        internal uint Type;
        internal uint Value;
    }
}