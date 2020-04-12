using System;
using System.Collections.Generic;
using System.IO;

namespace Disassembler
{
    internal enum IntelInstructionDecoderMode
    {
        x86_16bits,
        x86,
        x64,
    }

    internal sealed class RexPrefix
    {
        internal readonly byte _prefix;

        internal RexPrefix(byte prefix)
        {
            _prefix = prefix;
        }

        public byte Code
        {
            get
            {
                return _prefix;
            }
        }

        public int W
        { 
            get
            {
                return (_prefix & 0b_0000_1000) >> 3;
            }
        }
    }

    internal sealed class IntelInstruction
    {
        public IntelInstruction(long offset, byte opCode, string name)
        {
            const string lineFormat = "\tL_{0:X8} ";
            var opCodes = string.Format("{0:x2}", opCode);

            Console.WriteLine(lineFormat + "{1} {2}", offset - 1, opCodes + new string(' ', 20 - opCodes.Length), name);
        }
    }

    // https://gerardnico.com/lang/assembly/intel/modrm
    // https://gerardnico.com/lang/assembly/intel/instruction
    // http://ref.x86asm.net/#column_x
    // http://ref.x86asm.net/coder32.html
    // https://marcin-chwedczuk.github.io/a-closer-look-at-portable-executable-msdos-stub
    // https://blog.kowalczyk.info/articles/pefileformat.html
    // file:///C:/Users/r3db/Downloads/Microsoft%20Portable%20Executable%20and%20Common%20Object%20File%20Format%20Specification%20-%201999%20(pecoff).pdf
    internal static class IntelInstructionDecoder
    {
        internal static IList<IntelInstruction> Decode(ImageReader reader, IntelInstructionDecoderMode mode, int codeSize)
        {
            var result = new List<IntelInstruction>();
            RexPrefix prefix = null;

            for (int i = 0; i < codeSize; i++)
            {
                var offset = i + 0x8000d760;
                var opCode = reader.ReadByte();

                switch (opCode)
                {
                    //case 0x0e:
                    //{
                    //    Console.WriteLine("{0:X8} {1:X2}         push cs", offset, opCode);
                    //    break;
                    //}
                    //case 0x1f:
                    //{
                    //    Console.WriteLine("{0:X8} {1:X2}         pop ds", offset, opCode);
                    //    break;
                    //}
                    //case 0x20:
                    //{
                    //    // Todo: I do not understand this one!
                    //    var a = reader.ReadByte();
                    //    var b = reader.ReadByte();
                    //    Console.WriteLine("{0:X8} {1:X2}{2:X2}{3:X2}     and [bx+si+0x{4:X2}],dh ", offset, opCode, a, b, b);
                    //    break;
                    //}
                    case 0x40:
                    case 0x41:
                    case 0x42:
                    case 0x43:
                    case 0x44:
                    case 0x45:
                    case 0x46:
                    case 0x47:
                    case 0x48:
                    {
                        if (mode == IntelInstructionDecoderMode.x64)
                        {
                            prefix = new RexPrefix(opCode);
                        }

                        break;
                    }
                    case 0x49:
                    case 0x4a:
                    {
                        if (mode == IntelInstructionDecoderMode.x64)
                        {
                            prefix = new RexPrefix(opCode);
                        }

                        break;
                    }
                    case 0x4b:
                    case 0x4c:
                    case 0x4d:
                    case 0x4e:
                    case 0x4f:
                    {
                        break;
                    }
                    //case 0x54:
                    //{
                    //    Console.WriteLine("{0:X8} {1:X2}         push sp", offset, opCode);
                    //    break;
                    //}
                    case 0x57:
                    {
                        result.Add(new IntelInstruction(offset - 1, opCode, "push rdi"));
                        break;
                    }
                    //case 0x67:
                    //{
                    //    // Todo: Complete Address Modifier!
                    //    break;
                    //}
                    //case 0x68:
                    //{
                    //    var payload = reader.ReadUInt16();
                    //    var a = (payload & 0b_0000_0000_1111_1111) >> 0;
                    //    var b = (payload & 0b_1111_1111_0000_0000) >> 0;
                    //    Console.WriteLine("{0:X8} {1:X2}{2:X2}{3:X2}   push word 0x{4:X4}", offset, opCode, a, b, payload);
                    //    break;
                    //}
                    //case 0x6d:
                    //{
                    //    Console.WriteLine("{0:X8} {1:X2}         insw", offset, opCode);
                    //    break;
                    //}
                    //case 0x6f:
                    //{
                    //    Console.WriteLine("{0:X8} {1:X2}         outsw", offset, opCode);
                    //    break;
                    //}
                    //case 0x72:
                    //{
                    //    var payload = reader.ReadByte();
                    //    var jump = fix - offset + payload;
                    //    Console.WriteLine("{0:X8} {1:X2}{2:X2}       jc 0x{3:X2}", offset, opCode, payload, jump);
                    //    break;
                    //}
                    case 0x75:
                    {
                        var op = reader.ReadByte();
                        i += 1;

                        result.Add(new IntelInstruction(offset, opCode, string.Format("jnz 0x{0:x2}", offset + 2 + op)));

                        break;
                    }

                    case 0x83:
                    {
                        var modRM = reader.ReadByte();
                        i += 1;

                        var mod = (modRM & 0b_1100_0000) >> 6;
                        var reg = (modRM & 0b_0011_1000) >> 3;
                        var rm  = (modRM & 0b_0000_0111) >> 0;

                        var mnemonic = string.Empty;

                        switch (reg)
                        {
                            case 0: mnemonic = "add"; break;
                            case 1: mnemonic = "or";  break;
                            case 2: mnemonic = "adc"; break;
                            case 3: mnemonic = "sbb"; break;
                            case 4: mnemonic = "and"; break;
                            case 5: mnemonic = "sub"; break;
                            case 6: mnemonic = "xor"; break;
                            case 7: mnemonic = "cmp"; break;
                        }

                        var op = reader.ReadByte();
                        i += 1;

                        if (prefix != null)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2:x2} {3:x2} {4:x2} {5}", offset - 1, prefix.Code, opCode, modRM, op, mnemonic);
                            prefix = null;
                        }
                        else
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2:x2} {3:x2} {4}", offset, opCode, modRM, op, mnemonic);
                        }

                        break;
                    }
                    case 0x89:
                    {
                        var modRM = reader.ReadByte();
                        i += 1;

                        var mod = (modRM & 0b_1100_0000) >> 6;
                        var reg = (modRM & 0b_0011_1000) >> 3;
                        var rm  = (modRM & 0b_0000_0111) >> 0;

                        var sib = reader.ReadByte();
                        i += 1;

                        var op = reader.ReadByte();
                        i += 1;

                        if (prefix != null)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2:x2} {3:x2} {4:x2} {5:x2} {6}", offset - 1, prefix.Code, opCode, modRM, sib, op, "mov");
                            prefix = null;
                        }
                        else 
                        {
                            throw new NotSupportedException();
                        }

                        break;
                    }
                    case 0x8b:
                    {
                        var modRM = reader.ReadByte();
                        i += 1;

                        var mod = (modRM & 0b_1100_0000) >> 6;
                        var reg = (modRM & 0b_0011_1000) >> 3;
                        var rm  = (modRM & 0b_0000_0111) >> 0;

                        if (prefix != null)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2:x2} {3:x2} {4}", offset - 1, prefix.Code, modRM, opCode, "mov");
                            prefix = null;
                        }
                        else
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2:x2} {3}", offset, modRM, opCode, "mov");
                        }

                        break;
                    }
                    //case 0xb4:
                    //{
                    //    var payload = reader.ReadByte();
                    //    Console.WriteLine("{0:X8} {1:X2}{2:X2}       mov ah, 0x{3:X2}", offset, opCode, payload, payload);
                    //    break;
                    //}
                    //case 0xb8:
                    //{
                    //    var payload = reader.ReadUInt16();
                    //    var a = (payload & 0b_0000_0000_1111_1111) >> 0;
                    //    var b = (payload & 0b_1111_1111_0000_0000) >> 0;
                    //    Console.WriteLine("{0:X8} {1:X2}{2:X2}{3:X2}   mov ax, 0x{4:X4}", offset, opCode, a, b, payload);
                    //    break;
                    //}
                    //case 0xbA:
                    //{
                    //    var payload = reader.ReadUInt16();
                    //    var a = (payload & 0b_0000_0000_1111_1111) >> 0;
                    //    var b = (payload & 0b_1111_1111_0000_0000) >> 0;
                    //    Console.WriteLine("{0:X8} {1:X2}{2:X2}{3:X2}     mov dx, 0x{4:X4}", offset, opCode, a, b, payload);
                    //    break;
                    //}
                    //case 0xcd:
                    //{
                    //    var payload = reader.ReadByte();
                    //    Console.WriteLine("{0:X8} {1:X2}{2:X2}       int, 0x{3:X2}", offset, opCode, payload, payload);
                    //    break;
                    //}
                    case 0xe8:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;

                        var codes = BitConverter.GetBytes(op);

                        Console.WriteLine("{0:X8} {1:x2} {2:x2} {3:x2} {4:x2} {5:x2} {6} {7:x4}", offset, opCode, codes[0], codes[1], codes[2], codes[3], "call", offset + 5 + op);

                        break;
                    }
                    default:
                    {
                        throw new InvalidOperationException(string.Format("0x{0:x2}", opCode));
                    }
                }
            }

            return result;
        }
    }
}