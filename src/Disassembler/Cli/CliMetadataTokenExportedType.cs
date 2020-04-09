using System;
using System.Reflection;

namespace Disassembler
{
    internal sealed class CliMetadataTokenExportedType : CliMetadataTokenBase
    {
        internal CliMetadataTokenExportedType()
            : base(CliMetadataToken.ExportedType)
        {
        }

        internal TypeAttributes Flags;
        internal uint           TypeDefId;
        internal uint           TypeName;
        internal uint           TypeNamespace;
        internal uint           Implementation;
    }

}