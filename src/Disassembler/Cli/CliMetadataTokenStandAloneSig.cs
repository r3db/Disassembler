using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenStandAloneSig : CliMetadataTokenBase
    {
        internal CliMetadataTokenStandAloneSig()
            : base(CliMetadataToken.StandAloneSig)
        {
        }

        internal uint Signature;
    }
}