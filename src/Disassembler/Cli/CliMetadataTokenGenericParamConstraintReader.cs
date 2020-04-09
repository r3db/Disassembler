using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenGenericParamConstraintReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var owner      = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var constraint = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenGenericParamConstraint
                {
                    Owner      = owner,
                    Constraint = constraint,
                });
            }

            return result;
        }
    }
}