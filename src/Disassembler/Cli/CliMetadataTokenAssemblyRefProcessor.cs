using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenAssemblyRefProcessor : CliMetadataTokenBase
    {
        internal CliMetadataTokenAssemblyRefProcessor()
            : base(CliMetadataToken.AssemblyRefProcessor)
        {
        }

        internal uint Processor;
        internal uint AssemblyRef;
    }
}