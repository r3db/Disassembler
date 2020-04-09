using System;

namespace Disassembler
{

    internal abstract class CliMetadataTokenBase
    {
        public CliMetadataTokenBase(CliMetadataToken kind)
        {
            Kind = kind;
        }

        public CliMetadataToken Kind { get; }
    }
}