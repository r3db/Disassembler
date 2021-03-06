﻿using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenTypeSpecPresenter
    {
        internal static void Present(CliMetadataToken token, IEnumerable<CliMetadataTokenTypeSpec> tokens, uint indexSize)
        {
            Shell.Table($"Metadata Token [{token}]", tokens, 8, x =>
            {
                x.Add(nameof(CliMetadataTokenTypeSpec.Signature), indexSize == 2 ? "{0:x4}" : "{0:x8}", 157);
            });
        }
    }
}