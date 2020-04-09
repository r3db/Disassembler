using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenPropertyMap : CliMetadataTokenBase
    {
        internal CliMetadataTokenPropertyMap()
            : base(CliMetadataToken.PropertyMap)
        {
        }

        internal uint Parent;
        internal uint PropertyList;
    }
}