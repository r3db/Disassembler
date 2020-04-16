using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Disassembler
{
    internal sealed class ImageReader : IDisposable
    {
        private readonly BinaryReader _reader;
        private readonly List<CoffSectionHeader> _sections = new List<CoffSectionHeader>();
        private readonly Stack<long> _offsets = new Stack<long>();

        internal ImageReader(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }

        internal void AddSections(IList<CoffSectionHeader> sections)
        {
            _sections.Clear();
            _sections.AddRange(sections);
        }

        internal void ToRva(uint virtualAddress)
        {
            ToOffset(Rva2Offset(virtualAddress));
        }

        internal void ToOffset(uint offset)
        {
            _reader.BaseStream.Position = offset;
        }

        // Todo: Rename!
        internal void Save()
        {
            _offsets.Push(_reader.BaseStream.Position);
        }

        internal void Resume()
        {
            _reader.BaseStream.Position = _offsets.Pop();
        }

        internal byte ReadByte()
        {
            return _reader.ReadByte();
        }

        internal byte[] ReadBytes(uint count)
        {
            return _reader.ReadBytes((int)count);
        }

        internal byte[] ReadBytes(int count)
        {
            return _reader.ReadBytes(count);
        }

        internal ushort ReadUInt16()
        {
            return _reader.ReadUInt16();
        }

        internal ushort[] ReadUInt16Array(int length)
        {
            var result = new ushort[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = _reader.ReadUInt16();
            }

            return result;
        }

        internal uint ReadUInt32()
        {
            return _reader.ReadUInt32();
        }

        internal int ReadInt32()
        {
            return _reader.ReadInt32();
        }

        internal ulong ReadUInt64()
        {
            return _reader.ReadUInt64();
        }

        internal float ReadSingle()
        {
            return _reader.ReadSingle();
        }

        internal double ReadDouble()
        {
            return _reader.ReadDouble();
        }

        internal string ReadString(int length)
        {
            return Encoding.ASCII.GetString(_reader.ReadBytes(length)).TrimEnd('\0');
        }

        internal string ReadNullTerminatedString()
        {
            byte t;
            var result = new StringBuilder(8);

            while ((t = _reader.ReadByte()) != 0)
            {
                result.Append((char)t);
            }

            return result.ToString();
        }
        
        // Interface Implementations
        public void Dispose()
        {
            _reader.Dispose();
        }

        // Helpers
        private uint Rva2Offset(uint rva)
        {
            foreach (var section in _sections)
            {
                if (rva >= section.VirtualAddress && rva < section.VirtualAddress + section.SizeOfRawData)
                {
                    return section.PointerToRawData + (rva - section.VirtualAddress);
                }
            }

            throw new ArgumentOutOfRangeException("Invalid Address.");
        }
    }
}