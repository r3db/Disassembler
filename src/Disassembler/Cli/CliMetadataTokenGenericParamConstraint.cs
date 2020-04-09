using System;

namespace Disassembler
{
    internal sealed class CliMetadataTokenGenericParamConstraint : CliMetadataTokenBase
    {
        internal CliMetadataTokenGenericParamConstraint()
            : base(CliMetadataToken.GenericParamConstraint)
        {
        }

        internal uint Owner;
        internal uint Constraint;
    }
}