using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenInterfaceImplReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var @class        = reader.ReadMetadataTableIndex(indexSize);
                var @interface    = reader.ReadMetadataTableIndex(indexSize);

                var classResolved = reader.ReadStreamStringEntry(@class);

                result.Add(new CliMetadataTokenInterfaceImpl
                {
                    Class         = @class,
                    Interface     = @interface,
                    ClassResolved = classResolved,
                });
            }

            return result;
        }
    }
}