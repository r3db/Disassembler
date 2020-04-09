using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal sealed class CliMetadataTableStreamDefaultCompressed
    {
        internal CliMetadataTableHeader             Header;
        internal IList<IList<CliMetadataTokenBase>> Tokens;
    }
}