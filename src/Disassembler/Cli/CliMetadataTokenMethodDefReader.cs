using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataTokenMethodDefReader
    {
        internal static IList<CliMetadataTokenBase> Read(ImageReader reader, uint count, uint indexSize)
        {
            var result = new List<CliMetadataTokenBase>();

            for (int i = 0; i < count; i++)
            {
                var rva       = reader.ReadUInt32();
                var implFlags = reader.ReadUInt16();
                var flags     = reader.ReadUInt16();
                var name      = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var signature = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);
                var paramList = ImageReaderUtility.ReadMetadataTableIndex(reader, indexSize);

                result.Add(new CliMetadataTokenMethodDef
                {
                    Rva       = rva,
                    ImplFlags = implFlags,
                    Flags     = flags,
                    Name      = name,
                    Signature = signature,
                    ParamList = paramList,
                });
            }

            return result;
        }
    }
}