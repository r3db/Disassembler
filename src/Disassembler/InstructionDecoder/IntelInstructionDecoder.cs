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
        internal readonly byte _value;

        internal RexPrefix(byte prefix)
        {
            _value = prefix;
        }

        internal byte Code
        {
            get
            {
                return _value;
            }
        }

        internal int W
        { 
            get
            {
                return (_value & 0b_0000_1000) >> 3;
            }
        }

        internal byte Value
        {
            get
            {
                return _value;
            }
        }
    }

    internal sealed class ModRM
    {
        private readonly byte _value;

        internal ModRM(byte modRM)
        {
            _value = modRM;
        }

        internal int Mod
        {
            get
            {
                return (_value & 0b_1100_0000) >> 6;
            }
        }

        internal int Reg
        {
            get
            {
                return (_value & 0b_0011_1000) >> 3;
            }
        }

        internal int Rm
        {
            get
            {
                return (_value & 0b_0000_0111) >> 0;
            }
        }

        internal byte Value
        { 
            get
            { 
                return _value;
            }
        }
    }

    internal sealed class SIB
    {
        private readonly byte _value;

        internal SIB(byte sib)
        {
            _value = sib;
        }

        internal int Scale
        {
            get
            {
                return (_value & 0b_1100_0000) >> 6;
            }
        }

        internal int Index
        {
            get
            {
                return (_value & 0b_0011_1000) >> 3;
            }
        }

        internal int Base
        {
            get
            {
                return (_value & 0b_0000_0111) >> 0;
            }
        }

        internal byte Value
        {
            get
            {
                return _value;
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

    internal static class IntelInstructionDecoder
    {
        internal static IList<IntelInstruction> Decode(ImageReader reader, IntelInstructionDecoderMode mode, int codeSize)
        {
            var result = new List<IntelInstruction>();
            
            for (int i = 0; i < codeSize; i++)
            {
                var offset             = i + 0x8000D0E0;
                var offsetPresentation = string.Format("{0:x8} ", offset);
                var opCode             = reader.ReadByte();
                var prefix             = (RexPrefix)null;

                switch (opCode)
                {
                    case 0x40:
                    case 0x41:
                    case 0x42:
                    case 0x43:
                    case 0x44:
                    case 0x45:
                    case 0x46:
                    case 0x47:
                    case 0x48:
                    case 0x49:
                    case 0x4a:
                    case 0x4b:
                    case 0x4c:
                    case 0x4d:
                    case 0x4e:
                    case 0x4f:
                    {
                        if (mode == IntelInstructionDecoderMode.x64)
                        {
                            prefix = new RexPrefix(opCode);
                        }

                        break;
                    }
                }

                var prefixPresentation = prefix != null
                    ? string.Format("{0:x2} ", prefix.Code)
                    : string.Empty;

                if (prefix != null)
                {
                    opCode = reader.ReadByte();
                    i += 1;
                }

                switch (opCode)
                {
                    case 0x33:
                    {
                        InternalParse(reader, offset, ref i, prefix, opCode, "xor");
                        break;
                    }
                    case 0x3b:
                    {
                        var modRM = new ModRM(reader.ReadByte());
                        i += 1;

                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0}{1:x2} {2:x2} {3}", offsetPresentation, opCode, modRM.Value, "cmp");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0}{1:x2} {2:x2} {3}", offsetPresentation, opCode, modRM.Value, "cmp");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x39:
                    {
                        InternalParse(reader, offset, ref i, prefix, opCode, "cmp");
                        break;
                    }
                    case 0x50:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "eax");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "rax");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x51:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "ecx");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "rcx");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x52:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "edx");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "rdx");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x53:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "ebx");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "rbx");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x54:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "esp");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "rsp");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x55:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "ebp");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "rbp");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x56:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0}{1:x2} {2} {3}", offsetPresentation, opCode, "push", "esi");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            if (prefix != null)
                            {
                                Console.WriteLine("{0}{1}{2:x2} {3} {4}", offsetPresentation, prefixPresentation, opCode, "push", "r14");
                            }
                            else
                            {
                                Console.WriteLine("{0}{1:x2} {2} {3}", offsetPresentation, opCode, "push", "rsi");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x57:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "edi");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "push", "rdi");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x5f:
                    {
                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "pop", "edi");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0:X8} {1:x2} {2} {3}", offset, opCode, "pop", "rdi");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x70:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jo", offset + 2 + immediate);
                        break;
                    }
                    case 0x71:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jno", offset + 2 + immediate);
                        break;
                    }
                    case 0x72:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jb", offset + 2 + immediate);
                        break;
                    }
                    case 0x73:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jnb", offset + 2 + immediate);
                        break;
                    }
                    case 0x74:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jz", offset + 2 + immediate);
                        break;
                    }
                    case 0x75:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jnz", offset + 2 + immediate);
                        break;
                    }
                    case 0x76:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jbe", offset + 2 + immediate);
                        break;
                    }
                    case 0x77:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "ja", offset + 2 + immediate);
                        break;
                    }
                    case 0x78:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "js", offset + 2 + immediate);
                        break;
                    }
                    case 0x79:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jns", offset + 2 + immediate);
                        break;
                    }
                    case 0x7a:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jp", offset + 2 + immediate);
                        break;
                    }
                    case 0x7b:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jnp", offset + 2 + immediate);
                        break;
                    }
                    case 0x7c:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jl", offset + 2 + immediate);
                        break;
                    }
                    case 0x7d:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jnl", offset + 2 + immediate);
                        break;
                    }
                    case 0x7e:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jle", offset + 2 + immediate);
                        break;
                    }
                    case 0x7f:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jnle", offset + 2 + immediate);
                        break;
                    }
                    case 0x81:
                    {
                        var modRM = new ModRM(reader.ReadByte());
                        i += 1;

                        var mnemonic = string.Empty;

                        switch (modRM.Reg)
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

                        uint immediate;
                        string codePresentation;

                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            immediate = reader.ReadUInt16();
                            i += 2;
                            var codes = BitConverter.GetBytes(immediate);
                            codePresentation = string.Format("{0:x2} {1:x2}", codes[0], codes[1]);
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            immediate = reader.ReadUInt32();
                            i += 4;
                            var codes = BitConverter.GetBytes(immediate);
                            codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4:x2} {5}", offsetPresentation, prefixPresentation, opCode, modRM.Value, codePresentation, mnemonic);
                        break;
                    }
                    case 0x83:
                    {
                        InternalParse(reader, offset, ref i, prefix, opCode, x =>
                        {
                            switch (x.Reg)
                            {
                                case 0: return "add";
                                case 1: return "or";
                                case 2: return "adc";
                                case 3: return "sbb";
                                case 4: return "and";
                                case 5: return "sub";
                                case 6: return "xor";
                                case 7: return "cmp";
                            }

                            throw new NotSupportedException();
                        });
                        break;
                    }
                    case 0x85:
                    {
                        var modRM = new ModRM(reader.ReadByte());
                        i += 1;

                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            Console.WriteLine("{0}{1:x2} {2:x2} {3}", offsetPresentation, opCode, modRM.Value, "test");
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            Console.WriteLine("{0}{1}{2:x2} {3:x2} {4}", offsetPresentation, prefixPresentation, opCode, modRM.Value, "test");
                        }
                        else
                        {
                            throw new InvalidOperationException(mode.ToString());
                        }

                        break;
                    }
                    case 0x89:
                    {
                        InternalParse(reader, offset, ref i, prefix, opCode, "mov");
                        break;
                    }
                    case 0x8b:
                    {
                        InternalParse(reader, offset, ref i, prefix, opCode, "mov");
                        break;
                    }
                    case 0x8d:
                    {
                        InternalParse(reader, offset, ref i, prefix, opCode, "lea");
                        break;
                    }
                    case 0xbe:
                    {
                        var immediate = reader.ReadUInt32();
                        i += 4;
                        
                        var codes = BitConverter.GetBytes(immediate);
                        var codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);

                        Console.WriteLine("{0}{1:x2} {2} {3} esi, 0x{4:x}", offsetPresentation, opCode, codePresentation, "mov", immediate);
                        break;
                    }
                    case 0xcc:
                    {
                        Console.WriteLine("{0}{1:x2} {2}", offsetPresentation, opCode, "int 3");
                        break;
                    }
                    case 0xe8:
                    {
                        uint immediate;
                        string codePresentation;

                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            immediate = reader.ReadUInt16();
                            i += 2;

                            var codes = BitConverter.GetBytes(immediate);
                            codePresentation = string.Format("{0:x2} {1:x2}", codes[0], codes[1]);
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            immediate = reader.ReadUInt32();
                            i += 4;

                            var codes = BitConverter.GetBytes(immediate);
                            codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }

                        Console.WriteLine("{0}{1:x2} {2} {3} {4:x4}", offsetPresentation, opCode, codePresentation, "call", offset + 5 + immediate);
                        break;
                    }
                    case 0xe9:
                    {
                        uint immediate;
                        string codePresentation;

                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            immediate = reader.ReadUInt16();
                            i += 2;
                            var codes = BitConverter.GetBytes(immediate);
                            codePresentation = string.Format("{0:x2} {1:x2}", codes[0], codes[1]);
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            immediate = reader.ReadUInt32();
                            i += 4;
                            var codes = BitConverter.GetBytes(immediate);
                            codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }

                        Console.WriteLine("{0}{1:x2} {2} {3} {4:x4}", offsetPresentation, opCode, codePresentation, "jmp", offset + 5 + immediate);
                        break;
                    }
                    case 0xeb:
                    {
                        var immediate = reader.ReadByte();
                        i += 1;

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4} 0x{5:x2}", offsetPresentation, prefixPresentation, opCode, immediate, "jmp", offset + 2 + immediate);
                        break;
                    }
                    case 0x0f:
                    {
                        opCode = reader.ReadByte();
                        i += 1;

                        var opCodePresentation = string.Format("{0:x2} {1:x2} ", 0x0f, opCode);

                        switch (opCode)
                        {
                            case 0x44:
                            {
                                InternalParse(reader, offset, ref i, prefix, 0x0f, opCode, "cmovz");
                                break;
                            }
                            case 0x84:
                            {
                                var immediate = reader.ReadInt32();
                                i += 4;

                                if (mode == IntelInstructionDecoderMode.x86)
                                {
                                    var codes = BitConverter.GetBytes(immediate);
                                    var codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);

                                    Console.WriteLine("{0}{1}{2} {3} {4:x}", offsetPresentation, opCodePresentation, codePresentation, "jz", offset + immediate + 6);
                                }
                                else if (mode == IntelInstructionDecoderMode.x64)
                                {
                                    var codes = BitConverter.GetBytes(immediate);
                                    var codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);

                                    Console.WriteLine("{0}{1}{2} {3} {4:x}", offsetPresentation, opCodePresentation, codePresentation, "jz", offset + immediate + 6);
                                }
                                else
                                {
                                    throw new InvalidOperationException(mode.ToString());
                                }

                                break;
                            }
                            case 0x85:
                            {
                                var immediate = reader.ReadInt32();
                                i += 4;

                                if (mode == IntelInstructionDecoderMode.x86)
                                {
                                    var codes = BitConverter.GetBytes(immediate);
                                    var codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);

                                    Console.WriteLine("{0}{1}{2} {3} {4:x}", offsetPresentation, opCodePresentation, codePresentation, "jnz", offset + immediate + 6);
                                }
                                else if (mode == IntelInstructionDecoderMode.x64)
                                {
                                    var codes = BitConverter.GetBytes(immediate);
                                    var codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);

                                    Console.WriteLine("{0}{1}{2} {3} {4:x}", offsetPresentation, opCodePresentation, codePresentation, "jnz", offset + immediate + 6);
                                }
                                else
                                {
                                    throw new InvalidOperationException(mode.ToString());
                                }

                                break;
                            }
                            case 0x87:
                            {
                                var immediate = reader.ReadInt32();
                                i += 4;

                                if (mode == IntelInstructionDecoderMode.x86)
                                {
                                    var codes = BitConverter.GetBytes(immediate);
                                    var codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);

                                    Console.WriteLine("{0}{1}{2} {3} {4:x}", offsetPresentation, opCodePresentation, codePresentation, "ja", offset + immediate + 6);
                                }
                                else if (mode == IntelInstructionDecoderMode.x64)
                                {
                                    var codes = BitConverter.GetBytes(immediate);
                                    var codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);

                                    Console.WriteLine("{0}{1}{2} {3} {4:x}", offsetPresentation, opCodePresentation, codePresentation, "ja", offset + immediate + 6);
                                }
                                else
                                {
                                    throw new InvalidOperationException(mode.ToString());
                                }

                                break;
                            }
                            default:
                            {
                                throw new InvalidOperationException(string.Format("0x0f 0x{0:x2}", opCode));
                            }
                        }

                        break;
                    }
                    case 0xff:
                    {
                        var modRM = new ModRM(reader.ReadByte());
                        i += 1;

                        var mnemonic = string.Empty;

                        switch (modRM.Reg)
                        {
                            case 0: mnemonic = "inc";   break;
                            case 1: mnemonic = "dec";   break;
                            case 2: mnemonic = "call";  break;
                            case 3: mnemonic = "callf"; break;
                            case 4: mnemonic = "jmp";   break;
                            case 5: mnemonic = "jmpf";  break;
                            case 6: mnemonic = "push";  break;
                        }

                        uint immediate;
                        string codePresentation;

                        if (mode == IntelInstructionDecoderMode.x86)
                        {
                            immediate = reader.ReadUInt16();
                            i += 2;
                            var codes = BitConverter.GetBytes(immediate);
                            codePresentation = string.Format("{0:x2} {1:x2}", codes[0], codes[1]);
                        }
                        else if (mode == IntelInstructionDecoderMode.x64)
                        {
                            immediate = reader.ReadUInt32();
                            i += 4;
                            var codes = BitConverter.GetBytes(immediate);
                            codePresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);
                        }
                        else
                        {
                            throw new NotSupportedException();
                        }

                        Console.WriteLine("{0}{1}{2:x2} {3:x2} {4:x2} {5}", offsetPresentation, prefixPresentation, opCode, modRM.Value, codePresentation, mnemonic);
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

        internal static void InternalParse(ImageReader reader, long offset, ref int i, RexPrefix prefix, byte opCode, string name)
        {
            InternalParse(reader, offset, ref i, prefix, -1, opCode, name);
        }

        internal static void InternalParse(ImageReader reader, long offset, ref int i, RexPrefix prefix, int opCodePrefix, byte opCode, string name)
        {
            var modRM = new ModRM(reader.ReadByte());
            i += 1;

            var sib = (SIB)null;

            if (modRM.Mod != 0b_11 && modRM.Rm == 0b_100)
            {
                sib = new SIB(reader.ReadByte());
                i += 1;
            }

            var displacementPresentation = string.Empty;

            if (modRM.Mod == 0b_00 && modRM.Rm == 0b_101)
            {
                var displacement = reader.ReadInt32();
                i += 4;
                var codes = BitConverter.GetBytes(displacement);
                displacementPresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);
            }
            else if (modRM.Mod == 0b_01)
            {
                var displacement = reader.ReadByte();
                i += 1;
                displacementPresentation = string.Format("{0:x2} ", displacement);
            }
            else if (modRM.Mod == 0b_10)
            {
                var displacement = reader.ReadInt32();
                i += 4;
                var codes = BitConverter.GetBytes(displacement);
                displacementPresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2} ", codes[0], codes[1], codes[2], codes[3]);
            }

            var offsetPresentation = prefix != null
                ? string.Format("{0:x8} ", offset)
                : string.Format("{0:x8} ", offset);

            var prefixPresentation = prefix != null
                ? string.Format("{0:x2} ", prefix.Code)
                : string.Empty;

            var sibPresentation = sib != null
                ? string.Format("{0:x2} ", sib.Value)
                : string.Empty;

            var opCodePresentation = opCodePrefix == -1
                ? string.Format("{0:x2}", opCode)
                : string.Format("{0:x2} {1:x2}", opCodePrefix, opCode);

            Console.WriteLine("{0}{1}{2} {3:x2} {4}{5}{6}", offsetPresentation, prefixPresentation, opCodePresentation, modRM.Value, sibPresentation, displacementPresentation, name);
        }

        internal static void InternalParse(ImageReader reader, long offset, ref int i, RexPrefix prefix, byte opCode, Func<ModRM, string> nameResolver)
        {
            InternalParse(reader, offset, ref i, prefix, -1, opCode, nameResolver);
        }

        internal static void InternalParse(ImageReader reader, long offset, ref int i, RexPrefix prefix, int opCodePrefix, byte opCode, Func<ModRM, string> nameResolver)
        {
            var modRM = new ModRM(reader.ReadByte());
            i += 1;

            var mnemonic = nameResolver(modRM);

            var sib = (SIB)null;

            if (modRM.Mod != 0b_11 && modRM.Rm == 0b_100)
            {
                sib = new SIB(reader.ReadByte());
                i += 1;
            }

            var displacementPresentation = string.Empty;

            if (modRM.Mod == 0b_00 && modRM.Rm == 0b_101)
            {
                var displacement = reader.ReadInt32();
                i += 4;
                var codes = BitConverter.GetBytes(displacement);
                displacementPresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2}", codes[0], codes[1], codes[2], codes[3]);
            }
            else if (modRM.Mod == 0b_01)
            {
                var displacement = reader.ReadByte();
                i += 1;
                displacementPresentation = string.Format("{0:x2} ", displacement);
            }
            else if (modRM.Mod == 0b_10)
            {
                var displacement = reader.ReadInt32();
                i += 4;
                var codes = BitConverter.GetBytes(displacement);
                displacementPresentation = string.Format("{0:x2} {1:x2} {2:x2} {3:x2} ", codes[0], codes[1], codes[2], codes[3]);
            }

            var immediate = reader.ReadByte();
            i += 1;

            var offsetPresentation = prefix != null
                ? string.Format("{0:x8} ", offset)
                : string.Format("{0:x8} ", offset);

            var prefixPresentation = prefix != null
                ? string.Format("{0:x2} ", prefix.Code)
                : string.Empty;

            var sibPresentation = sib != null
                ? string.Format("{0:x2} ", sib.Value)
                : string.Empty;

            var opCodePresentation = opCodePrefix == -1
                ? string.Format("{0:x2}", opCode)
                : string.Format("{0:x2} {1:x2}", opCodePrefix, opCode);

            Console.WriteLine("{0}{1}{2} {3:x2} {4}{5}{6:x2} {7} 0x{8:x}", offsetPresentation, prefixPresentation, opCodePresentation, modRM.Value, sibPresentation, displacementPresentation, immediate, mnemonic, immediate);
        }
    }
}