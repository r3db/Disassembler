using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenDeclSecurityReader
    {
        internal static IList<CliMetadataTokenBase> Read(MetadataStreamReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var action        = reader.ReadUInt16();
                var parent        = reader.ReadMetadataTableIndex(indexSize);
                var permissionSet = reader.ReadMetadataTableIndex(indexSize);

                result.Add(new CliMetadataTokenDeclSecurity
                {
                    Action        = action,
                    Parent        = parent,
                    PermissionSet = permissionSet,
                });
            }

            return result;
        }
    }
}