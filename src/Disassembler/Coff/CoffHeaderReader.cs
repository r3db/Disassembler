using System;

namespace Disassembler
{
    internal static class CoffHeaderReader
    {
        internal static CoffHeader Read(uint lfanewOffset, ImageReader reader)
        { 
            reader.ToOffset(lfanewOffset);

            var magic                = reader.ReadString(4);
            var machine              = (CoffHeaderMachine)reader.ReadUInt16();
            var numberOfSections     = reader.ReadUInt16();
            var timeDateStamp        = reader.ReadUInt32();
            var pointerToSymbolTable = reader.ReadUInt32();
            var numberOfSymbols      = reader.ReadUInt32();
            var sizeOfOptionalHeader = reader.ReadUInt16();
            var characteristics      = (CoffHeaderCharacteristics)reader.ReadUInt16();

            return new CoffHeader
            {
                Magic                = magic,
                Machine              = machine,
                NumberOfSections     = numberOfSections,
                TimeDateStamp        = timeDateStamp,
                PointerToSymbolTable = pointerToSymbolTable,
                NumberOfSymbols      = numberOfSymbols,
                SizeOfOptionalHeader = sizeOfOptionalHeader,
                Characteristics      = characteristics,
            };
        }
    }
}