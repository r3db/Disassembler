using System;

namespace Disassembler
{
    internal abstract class CliMetadataTokenBase
    {
        internal CliMetadataTokenBase(CliMetadataToken kind)
        {
            Kind = kind;
        }

        internal CliMetadataToken Kind { get; }
    }
}