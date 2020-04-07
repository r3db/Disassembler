using System;
using System.IO;

namespace PeUtility
{
    internal sealed class X86_64InstructionDecoder
    {
        // https://gerardnico.com/lang/assembly/intel/modrm
        // https://gerardnico.com/lang/assembly/intel/instruction
        // http://ref.x86asm.net/#column_x
        // http://ref.x86asm.net/coder32.html
        // https://marcin-chwedczuk.github.io/a-closer-look-at-portable-executable-msdos-stub
        // https://blog.kowalczyk.info/articles/pefileformat.html
        // file:///C:/Users/r3db/Downloads/Microsoft%20Portable%20Executable%20and%20Common%20Object%20File%20Format%20Specification%20-%201999%20(pecoff).pdf
        private readonly BinaryReader _reader;

        internal X86_64InstructionDecoder(BinaryReader reader)
        {
            _reader = reader;
        }

        internal void Next()
        {
            var offset = _reader.BaseStream.Position;

            while (true)
            {
                var opCode   = _reader.ReadByte();
                var position = _reader.BaseStream.Position - offset - 1;

                switch (opCode)
                {
                    case 0x0E:
                    {
                        Console.WriteLine("{0:X8} {1:X2}         push cs", position, opCode);
                        break;
                    }
                    case 0x1F:
                    {
                        Console.WriteLine("{0:X8} {1:X2}         pop ds", position, opCode);
                        break;
                    }
                    case 0x20:
                    {
                        // Todo: I do not understand this one!
                        var a = _reader.ReadByte();
                        var b = _reader.ReadByte();
                        Console.WriteLine("{0:X8} {1:X2}{2:X2}{3:X2}     and [bx+si+0x{4:X2}],dh ", position, opCode, a, b, b);
                        break;
                    }
                    case 0x54:
                    {
                        Console.WriteLine("{0:X8} {1:X2}         push sp", position, opCode);
                        break;
                    }
                    case 0x67:
                    {
                        // Todo: Complete Address Modifier!
                        break;
                    }
                    case 0x68:
                    {
                        var payload = _reader.ReadUInt16();
                        var a = (payload & 0b_0000_0000_1111_1111) >> 0;
                        var b = (payload & 0b_1111_1111_0000_0000) >> 0;
                        Console.WriteLine("{0:X8} {1:X2}{2:X2}{3:X2}   push word 0x{4:X4}", position, opCode, a, b, payload);
                        break;
                    }
                    case 0x6D:
                    {
                        Console.WriteLine("{0:X8} {1:X2}         insw", position, opCode);
                        break;
                    }
                    case 0x6F:
                    {
                        Console.WriteLine("{0:X8} {1:X2}         outsw", position, opCode);
                        break;
                    }
                    case 0x72:
                    {
                        var payload = _reader.ReadByte();
                        var jump = _reader.BaseStream.Position - offset + payload;
                        Console.WriteLine("{0:X8} {1:X2}{2:X2}       jc 0x{3:X2}", position, opCode, payload, jump);
                        break;
                    }
                    case 0xB4:
                    {
                        var payload = _reader.ReadByte();
                        Console.WriteLine("{0:X8} {1:X2}{2:X2}       mov ah, 0x{3:X2}", position, opCode, payload, payload);
                        break;
                    }
                    case 0xB8:
                    {
                        var payload = _reader.ReadUInt16();
                        var a = (payload & 0b_0000_0000_1111_1111) >> 0;
                        var b = (payload & 0b_1111_1111_0000_0000) >> 0;
                        Console.WriteLine("{0:X8} {1:X2}{2:X2}{3:X2}   mov ax, 0x{4:X4}", position, opCode, a, b, payload);
                        break;
                    }
                    case 0xBA:
                    {
                        var payload = _reader.ReadUInt16();
                        var a = (payload & 0b_0000_0000_1111_1111) >> 0;
                        var b = (payload & 0b_1111_1111_0000_0000) >> 0;
                        Console.WriteLine("{0:X8} {1:X2}{2:X2}{3:X2}     mov dx, 0x{4:X4}", position, opCode, a, b, payload);
                        break;
                    }
                    case 0xCD:
                    {
                        var payload = _reader.ReadByte();
                        Console.WriteLine("{0:X8} {1:X2}{2:X2}       int, 0x{3:X2}", position, opCode, payload, payload);
                        break;
                    }
                    default:
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}