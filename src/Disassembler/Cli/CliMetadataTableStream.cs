using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal sealed class CliMetadataTableStream
    {
        internal IList<CliMetadataStreamHeader>          Streams;
        internal CliMetadataTableStreamDefaultCompressed DefaultCompressed;
    }
}