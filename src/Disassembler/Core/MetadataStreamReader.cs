using System;
using System.Collections.Generic;

namespace Disassembler
{
    // Todo: Rename!
    internal sealed class MetadataStreamReader : IDisposable
    {
        // Internal Instance Data
        private readonly ImageReader _reader;
        private readonly IDictionary<string, uint> _offsets = new Dictionary<string, uint>();
        
        // .Ctor
        internal MetadataStreamReader(ImageReader reader, IList<CliMetadataStreamHeader> streams, uint metadataRva)
        {
            _reader = reader;

            foreach (var item in streams)
            {
                _offsets.Add(item.Name, item.Offset + metadataRva);
            }
        }

        // Properties
        internal ImageReader BaseReader { get { return _reader; } }

        // Methods
        internal byte ReadByte()
        {
            return _reader.ReadByte();
        }

        internal byte[] ReadBytes(uint count)
        {
            return _reader.ReadBytes(count);
        }

        internal ushort ReadUInt16()
        {
            return _reader.ReadUInt16();
        }

        internal uint ReadUInt32()
        {
            return _reader.ReadUInt32();
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

        internal uint ReadMetadataTableIndex(uint size)
        {
            switch (size)
            {
                case 2: return _reader.ReadUInt16();
                case 4: return _reader.ReadUInt32();
            }

            throw new ArgumentOutOfRangeException();
        }

        internal string ReadStreamStringEntry(uint index)
        {
            _reader.Save();
            _reader.ToRva(_offsets["#Strings"] + index);

            var result = _reader.ReadNullTerminatedString();

            _reader.Resume();
            return result;
        }

        internal Guid ReadStreamGuidEntry(uint index)
        {
            _reader.Save();
            _reader.ToRva(_offsets["#GUID"] + index);

            var result = new Guid(_reader.ReadBytes(16));

            _reader.Resume();
            return result;
        }

        // Interface Implementations
        public void Dispose()
        {
            _reader.Dispose();
        }
    }
}