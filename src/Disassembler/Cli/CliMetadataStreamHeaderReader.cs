using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal static class CliMetadataStreamHeaderReader
    {
        internal static IList<CliMetadataStreamHeader> Read(ImageReader reader, uint numberOfStreams)
        {
            var result = new List<CliMetadataStreamHeader>();

            for (int i = 0; i < numberOfStreams; i++)
            {
                var offset = reader.ReadUInt32();
                var size   = reader.ReadUInt32();
                var name   = reader.ReadNullTerminatedString();

                if ((name.Length + 1) / 4.0f != (name.Length + 1) / 4)
                {
                    reader.ReadBytes((name.Length / 4) + 1);
                }

                var streamHeader = new CliMetadataStreamHeader
                { 
                    Offset = offset,
                    Size   = size,
                    Name   = name,
                };

                result.Add(streamHeader);
            }

            return result;
        }
    }
}