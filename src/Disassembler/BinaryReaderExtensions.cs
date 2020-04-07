using System;
using System.IO;
using System.Text;

namespace PeUtility
{
    internal static class BinaryReaderExtensions
    {
        internal static ushort[] ReadUInt16Array(this BinaryReader reader, int length)
        {
            var result = new ushort[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = reader.ReadUInt16();
            }

            return result;
        }

        internal static string ReadNullTerminatedString(this BinaryReader reader)
        {
            byte t;
            var result = new StringBuilder(8);

            while ((t = reader.ReadByte()) != 0)
            {
                result.Append((char)t);
            }

            return result.ToString();
        }
    }
}