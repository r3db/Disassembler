using System;

namespace Disassembler
{
    internal static class CoffDirectoryTableExportHeaderReader
    { 
        internal static CoffDirectoryTableExportHeader Read(ImageReader reader)
        {
            var characteristics       = reader.ReadUInt32();
            var timeDateStamp         = reader.ReadUInt32();
            var majorVersion          = reader.ReadUInt16();
            var minorVersion          = reader.ReadUInt16();
            var name                  = reader.ReadUInt32();
            var ordinalBase           = reader.ReadUInt32();
            var numberOfFunctions     = reader.ReadUInt32();
            var numberOfNames         = reader.ReadUInt32();
            var addressOfFunctions    = reader.ReadUInt32();
            var addressOfNames        = reader.ReadUInt32();
            var addressOfNameOrdinals = reader.ReadUInt32();

            return new CoffDirectoryTableExportHeader
            {
                Characteristics       = characteristics,
                TimeDateStamp         = timeDateStamp,
                MajorVersion          = majorVersion,
                MinorVersion          = minorVersion,
                Name                  = name,
                Base                  = ordinalBase,
                NumberOfFunctions     = numberOfFunctions,
                NumberOfNames         = numberOfNames,
                AddressOfFunctions    = addressOfFunctions,
                AddressOfNames        = addressOfNames,
                AddressOfNameOrdinals = addressOfNameOrdinals,
            };
        }
    }
}