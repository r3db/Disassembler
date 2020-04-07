using System;
using System.Collections.Generic;
using System.IO;

namespace PeUtility
{
    internal static class CliMetadataStreamHeaderReader
    {
        internal static IList<CliMetadataStreamHeader> Read(BinaryReader reader, uint numberOfStreams)
        {
            var result = new List<CliMetadataStreamHeader>();

            for (int i = 0; i < numberOfStreams; i++)
            {
                // Metadata Directory!
                var offset = reader.ReadUInt32();
                var size   = reader.ReadUInt32();
                var name   = reader.ReadNullTerminatedString();

                // Note: We may need to pad!
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