using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenGenericParamConstraintPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenGenericParamConstraint> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenGenericParamConstraint.Owner),      indexSize == 2 ? "{0:x4}" : "{0:x8}",   8);
                x.Add(nameof(CliMetadataTokenGenericParamConstraint.Constraint), indexSize == 2 ? "{0:x4}" : "{0:x8}", 146);
            });
        }
    }
}