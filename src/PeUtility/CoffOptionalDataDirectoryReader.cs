using System;
using System.Collections.Generic;
using System.IO;

namespace PeUtility
{
    internal static class CoffOptionalDataDirectoryReader
    {
        internal static IList<CoffOptionalDataDirectory> Read(BinaryReader reader, uint numberOfRvaAndSizes)
        {
            var result = new List<CoffOptionalDataDirectory>();

            for (int i = 0; i < numberOfRvaAndSizes; i++)
            {
                var virtualAddress = reader.ReadUInt32();
                var size           = reader.ReadUInt32();

                result.Add(new CoffOptionalDataDirectory
                {
                    Kind           = (CoffOptionalDataDirectoryKind)i,
                    Section        = null,
                    VirtualAddress = virtualAddress,
                    Size           = size,
                });
            }

            return result;
        }
    }
}