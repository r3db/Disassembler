using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenAssemblyProcessor : CliMetadataTokenBase
    {
        internal CliMetadataTokenAssemblyProcessor()
            : base(CliMetadataToken.AssemblyProcessor)
        {
        }

        internal uint Processor;
    }
}