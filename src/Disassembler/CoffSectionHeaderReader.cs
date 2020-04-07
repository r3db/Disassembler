using System;
using System.IO;
using System.Text;

namespace PeUtility
{
    internal static class CoffSectionHeaderReader
    {
        internal static CoffSectionHeader Read(BinaryReader reader)
        {
            var name                 = Encoding.ASCII.GetString(reader.ReadBytes(8)).Replace("\0", string.Empty);
            var virtualSize          = reader.ReadUInt32();
            var virtualAddress       = reader.ReadUInt32();
            var sizeOfRawData        = reader.ReadUInt32();
            var pointerToRawData     = reader.ReadUInt32();
            var pointerToRelocations = reader.ReadUInt32();
            var pointerToLinenumbers = reader.ReadUInt32();
            var numberOfRelocations  = reader.ReadUInt16();
            var numberOfLinenumbers  = reader.ReadUInt16();
            var characteristics      = (CoffSectionFlags)reader.ReadUInt32();

            return new CoffSectionHeader
            {
                Name                 = name,
                VirtualSize          = virtualSize,
                VirtualAddress       = virtualAddress,
                SizeOfRawData        = sizeOfRawData,
                PointerToRawData     = pointerToRawData,
                PointerToRelocations = pointerToRelocations,
                PointerToLinenumbers = pointerToLinenumbers,
                NumberOfRelocations  = numberOfRelocations,
                NumberOfLinenumbers  = numberOfLinenumbers,
                Characteristics      = characteristics,
            };
        }
    }
}