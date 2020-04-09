using System;


namespace Disassembler
{
    internal static class CoffOptionalHeaderReader
    { 
        internal static CoffOptionalHeader Read(ImageReader reader)
        {
            var magic                       = (CoffOptionalPeFormat)reader.ReadUInt16();
            var majorLinkerVersion          = reader.ReadByte();
            var minorLinkerVersion          = reader.ReadByte();
            var sizeOfCode                  = reader.ReadUInt32();
            var sizeOfInitializedData       = reader.ReadUInt32();
            var sizeOfUninitializedData     = reader.ReadUInt32();
            var addressOfEntryPoint         = reader.ReadUInt32();
            var baseOfCode                  = reader.ReadUInt32();
            var baseOfData                  = magic == CoffOptionalPeFormat.PE32 ? reader.ReadUInt32() : 0; // PE32 contains this additional field, which is absent in PE32+.
            var imageBase                   = magic == CoffOptionalPeFormat.PE32 ? reader.ReadUInt32() : reader.ReadUInt64();
            var sectionAlignment            = reader.ReadUInt32();
            var fileAlignment               = reader.ReadUInt32();
            var majorOperatingSystemVersion = reader.ReadUInt16();
            var minorOperatingSystemVersion = reader.ReadUInt16();
            var majorImageVersion           = reader.ReadUInt16();
            var minorImageVersion           = reader.ReadUInt16();
            var majorSubsystemVersion       = reader.ReadUInt16();
            var minorSubsystemVersion       = reader.ReadUInt16();
            var reserved1                   = reader.ReadUInt32();
            var sizeOfImage                 = reader.ReadUInt32();
            var sizeOfHeaders               = reader.ReadUInt32();
            var checkSum                    = reader.ReadUInt32();
            var subsystem                   = (CoffOptionalWindowsSubsystem)reader.ReadUInt16();
            var dllCharacteristics          = (CoffOptionalDllCharacteristics)reader.ReadUInt16();
            var sizeOfStackReserve          = magic == CoffOptionalPeFormat.PE32 ? reader.ReadUInt32() : reader.ReadUInt64();
            var sizeOfStackCommit           = magic == CoffOptionalPeFormat.PE32 ? reader.ReadUInt32() : reader.ReadUInt64();
            var sizeOfHeapReserve           = magic == CoffOptionalPeFormat.PE32 ? reader.ReadUInt32() : reader.ReadUInt64();
            var sizeOfHeapCommit            = magic == CoffOptionalPeFormat.PE32 ? reader.ReadUInt32() : reader.ReadUInt64();
            var loaderFlags                 = reader.ReadUInt32();
            var numberOfRvaAndSizes         = reader.ReadUInt32();

            if (magic == CoffOptionalPeFormat.ROM)
            {
                throw new NotSupportedException();
            }

            return new CoffOptionalHeader
            {
                Magic                       = magic,
                MajorLinkerVersion          = majorLinkerVersion,
                MinorLinkerVersion          = minorLinkerVersion,
                SizeOfCode                  = sizeOfCode,
                SizeOfInitializedData       = sizeOfInitializedData,
                SizeOfUninitializedData     = sizeOfUninitializedData,
                AddressOfEntryPoint         = addressOfEntryPoint,
                BaseOfCode                  = baseOfCode,
                BaseOfData                  = baseOfData,
                ImageBase                   = imageBase,
                SectionAlignment            = sectionAlignment,
                FileAlignment               = fileAlignment,
                MajorOperatingSystemVersion = majorOperatingSystemVersion,
                MinorOperatingSystemVersion = minorOperatingSystemVersion,
                MajorImageVersion           = majorImageVersion,
                MinorImageVersion           = minorImageVersion,
                MajorSubsystemVersion       = majorSubsystemVersion,
                MinorSubsystemVersion       = minorSubsystemVersion,
                Reserved1                   = reserved1,
                SizeOfImage                 = sizeOfImage,
                SizeOfHeaders               = sizeOfHeaders,
                CheckSum                    = checkSum,
                Subsystem                   = subsystem,
                DllCharacteristics          = dllCharacteristics,
                SizeOfStackReserve          = sizeOfStackReserve,
                SizeOfStackCommit           = sizeOfStackCommit,
                SizeOfHeapReserve           = sizeOfHeapReserve,
                SizeOfHeapCommit            = sizeOfHeapCommit,
                LoaderFlags                 = loaderFlags,
                NumberOfRvaAndSizes         = numberOfRvaAndSizes,
            };
        }
    }
}