using System;

namespace Disassembler
{
    internal static class ImageReaderUtility
    {
        internal static uint ReadMetadataTableIndex(ImageReader reader, uint size)
        {
            switch (size)
            {
                case 2: return reader.ReadUInt16();
                case 4: return reader.ReadUInt32();
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}