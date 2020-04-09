using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal sealed class CoffDirectoryTableCli : CoffDirectoryTable
    {
        internal CliHeader              Header;
        internal CliMetadataHeader      Metadata;
        internal CliMetadataTableStream Tables;
    }
}