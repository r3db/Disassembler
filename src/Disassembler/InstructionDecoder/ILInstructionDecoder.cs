using System;
using System.Collections.Generic;

namespace Disassembler
{
    internal sealed class ILInstructionDecoder
    {
        // Todo: Extract Metadata and Values!
        // Todo: Refactor!
        internal static IList<ILInstruction> Decode(MetadataStreamReader reader, uint rva)
        {
            var result = new List<ILInstruction>();

            reader.BaseReader.Save();
            reader.BaseReader.ToRva(rva);

            var a0 = reader.ReadByte();
            uint codeSize;

            var headerFormat = (CliMethodHeaderFormat)(a0 & 0b_0000_0011);

            switch (headerFormat)
            {
                case CliMethodHeaderFormat.CorILMethod_TinyFormat:
                {
                    codeSize = (uint)(a0 >> 2);
                    break;
                }
                case CliMethodHeaderFormat.CorILMethod_FatFormat:
                {
                    var a1             = reader.ReadByte();
                    var a2             = a1 & 0b_1111_0000;
                    var flags          = (CliMethodHeaderFormat)(a0 | a2);
                    var size           = a2 >> 4;
                    var maxStack       = reader.ReadUInt16();
                    codeSize       = reader.ReadUInt32();
                    var localVarSigTok = reader.ReadUInt32();

                    break;
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }

            for (int i = 0; i < codeSize; i++)
            {
                var offset = i;
                var opCode = reader.ReadByte();

                switch(opCode)
                {
                    case 0x00:
                    {
                        result.Add(new ILInstruction("nop", opCode, offset));
                        break;
                    }
                    case 0x01:
                    {
                        result.Add(new ILInstruction("break", opCode, offset));
                        break;
                    }
                    case 0x02:
                    {
                        result.Add(new ILInstruction("ldarg.0", opCode, offset));
                        break;
                    }
                    case 0x03:
                    {
                        result.Add(new ILInstruction("ldarg.1", opCode, offset));
                        break;
                    }
                    case 0x04:
                    {
                        result.Add(new ILInstruction("ldarg.2", opCode, offset));
                        break;
                    }
                    case 0x05:
                    {
                        result.Add(new ILInstruction("ldarg.3", opCode, offset));
                        break;
                    }
                    case 0x06:
                    {
                        result.Add(new ILInstruction("ldloc.0", opCode, offset));
                        break;
                    }
                    case 0x07:
                    {
                        result.Add(new ILInstruction("ldloc.1", opCode, offset));
                        break;
                    }
                    case 0x08:
                    {
                        result.Add(new ILInstruction("ldloc.2", opCode, offset));
                        break;
                    }
                    case 0x09:
                    {
                        result.Add(new ILInstruction("ldloc.3", opCode, offset));
                        break;
                    }
                    case 0x0a:
                    {
                        result.Add(new ILInstruction("stloc.0", opCode, offset));
                        break;
                    }
                    case 0x0b:
                    {
                        result.Add(new ILInstruction("stloc.1", opCode, offset));
                        break;
                    }
                    case 0x0c:
                    {
                        result.Add(new ILInstruction("stloc.2", opCode, offset));
                        break;
                    }
                    case 0x0d:
                    {
                        result.Add(new ILInstruction("stloc.3", opCode, offset));
                        break;
                    }
                    case 0x0e:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("stloc.s", opCode, offset));
                        break;
                    }
                    case 0x0f:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("ldarga.s", opCode, offset));
                        break;
                    }
                    case 0x10:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("starg.s", opCode, offset));
                        break;
                    }
                    case 0x11:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("ldloc.s", opCode, offset));
                        break;
                    }
                    case 0x12:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("ldloca.s", opCode, offset));
                        break;
                    }
                    case 0x13:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("stloc.s", opCode, offset));
                        break;
                    }
                    case 0x14:
                    {
                        result.Add(new ILInstruction("ldnull", opCode, offset));
                        break;
                    }
                    case 0x15:
                    {
                        result.Add(new ILInstruction("ldc.i4.m1", opCode, offset));
                        break;
                    }
                    case 0x16:
                    {
                        result.Add(new ILInstruction("ldc.i4.0", opCode, offset));
                        break;
                    }
                    case 0x17:
                    {
                        result.Add(new ILInstruction("ldc.i4.1", opCode, offset));
                        break;
                    }
                    case 0x18:
                    {
                        result.Add(new ILInstruction("ldc.i4.2", opCode, offset));
                        break;
                    }
                    case 0x19:
                    {
                        result.Add(new ILInstruction("ldc.i4.3", opCode, offset));
                        break;
                    }
                    case 0x1a:
                    {
                        result.Add(new ILInstruction("ldc.i4.4", opCode, offset));
                        break;
                    }
                    case 0x1b:
                    {
                        result.Add(new ILInstruction("ldc.i4.5", opCode, offset));
                        break;
                    }
                    case 0x1c:
                    {
                        result.Add(new ILInstruction("ldc.i4.6", opCode, offset));
                        break;
                    }
                    case 0x1d:
                    {
                        result.Add(new ILInstruction("ldc.i4.7", opCode, offset));
                        break;
                    }
                    case 0x1e:
                    {
                        result.Add(new ILInstruction("ldc.i4.8", opCode, offset));
                        break;
                    }
                    case 0x1f:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("ldc.i4.s", opCode, offset));
                        break;
                    }
                    case 0x20:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldc.i4", opCode, offset));
                        break;
                    }
                    case 0x21:
                    {
                        var op = reader.ReadUInt64();
                        i += 8;
                        result.Add(new ILInstruction("ldc.i8", opCode, offset));
                        break;
                    }
                    case 0x22:
                    {
                        var op = reader.ReadSingle();
                        i += 4;
                        result.Add(new ILInstruction("ldc.r4", opCode, offset));
                        break;
                    }
                    case 0x23:
                    {
                        var op = reader.ReadDouble();
                        i += 8;
                        result.Add(new ILInstruction("ldc.r8", opCode, offset));
                        break;
                    }
                    case 0x25:
                    {
                        result.Add(new ILInstruction("dup", opCode, offset));
                        break;
                    }
                    case 0x26:
                    {
                        result.Add(new ILInstruction("pop", opCode, offset));
                        break;
                    }
                    case 0x27:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("jmp", opCode, offset));
                        break;
                    }
                    case 0x28:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("call", opCode, offset));
                        break;
                    }

                    case 0x2a:
                    {
                        result.Add(new ILInstruction("ret", opCode, offset));
                        break;
                    }
                    case 0x2b:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("br.s", opCode, offset));
                        break;
                    }
                    case 0x2c:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("brfalse.s", opCode, offset));
                        break;
                    }
                    case 0x2d:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("brtrue.s", opCode, offset));
                        break;
                    }
                    case 0x2e:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("beq.s", opCode, offset));
                        break;
                    }
                    case 0x2f:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("bge.s", opCode, offset));
                        break;
                    }
                    case 0x30:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("bgt.s", opCode, offset));
                        break;
                    }
                    case 0x31:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("ble.s", opCode, offset));
                        break;
                    }
                    case 0x32:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("blt.s", opCode, offset));
                        break;
                    }
                    case 0x33:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("bne.un.s", opCode, offset));
                        break;
                    }
                    case 0x34:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("bge.un.s", opCode, offset));
                        break;
                    }
                    case 0x35:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("bgt.un.s", opCode, offset));
                        break;
                    }
                    case 0x36:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("ble.un.s", opCode, offset));
                        break;
                    }
                    case 0x37:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("blt.un.s", opCode, offset));
                        break;
                    }
                    case 0x38:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("br", opCode, offset));
                        break;
                    }
                    case 0x39:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("brfalse", opCode, offset));
                        break;
                    }
                    case 0x3a:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("brtrue", opCode, offset));
                        break;
                    }
                    case 0x3b:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("beq", opCode, offset));
                        break;
                    }
                    case 0x3c:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("bge", opCode, offset));
                        break;
                    }
                    case 0x3d:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("bgt", opCode, offset));
                        break;
                    }
                    case 0x3e:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ble", opCode, offset));
                        break;
                    }
                    case 0x3f:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("blt", opCode, offset));
                        break;
                    }
                    case 0x40:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("bne.un", opCode, offset));
                        break;
                    }
                    case 0x41:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("bge.un", opCode, offset));
                        break;
                    }
                    case 0x42:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("bgt.un", opCode, offset));
                        break;
                    }
                    case 0x43:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ble.un", opCode, offset));
                        break;
                    }
                    case 0x44:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("blt.un", opCode, offset));
                        break;
                    }
                    case 0x45:
                    {
                        var op1 = reader.ReadUInt32();
                        var op2 = reader.ReadBytes(4 * op1);
                        i += (4 + op2.Length);
                        result.Add(new ILInstruction("switch", opCode, offset));
                        break;
                    }
                    case 0x46:
                    {
                        result.Add(new ILInstruction("ldind.il", opCode, offset));
                        break;
                    }
                    case 0x47:
                    {
                        result.Add(new ILInstruction("ldind.ul", opCode, offset));
                        break;
                    }
                    case 0x48:
                    {
                        result.Add(new ILInstruction("ldind.i2", opCode, offset));
                        break;
                    }
                    case 0x49:
                    {
                        result.Add(new ILInstruction("ldind.u2", opCode, offset));
                        break;
                    }
                    case 0x4a:
                    {
                        result.Add(new ILInstruction("ldind.i4", opCode, offset));
                        break;
                    }
                    case 0x4b:
                    {
                        result.Add(new ILInstruction("ldind.u4", opCode, offset));
                        break;
                    }
                    case 0x4c:
                    {
                        result.Add(new ILInstruction("ldind.i8", opCode, offset));
                        break;
                    }
                    case 0x4d:
                    {
                        result.Add(new ILInstruction("ldind.i", opCode, offset));
                        break;
                    }
                    case 0x4e:
                    {
                        result.Add(new ILInstruction("ldind.r4", opCode, offset));
                        break;
                    }
                    case 0x4f:
                    {
                        result.Add(new ILInstruction("ldind.r8", opCode, offset));
                        break;
                    }
                    case 0x50:
                    {
                        result.Add(new ILInstruction("ldind.ref", opCode, offset));
                        break;
                    }
                    case 0x51:
                    {
                        result.Add(new ILInstruction("stind.ref", opCode, offset));
                        break;
                    }
                    case 0x52:
                    {
                        result.Add(new ILInstruction("stind.il", opCode, offset));
                        break;
                    }
                    case 0x53:
                    {
                        result.Add(new ILInstruction("stind.i2", opCode, offset));
                        break;
                    }
                    case 0x54:
                    {
                        result.Add(new ILInstruction("stind.i4", opCode, offset));
                        break;
                    }
                    case 0x55:
                    {
                        result.Add(new ILInstruction("stind.i8", opCode, offset));
                        break;
                    }
                    case 0x56:
                    {
                        result.Add(new ILInstruction("stind.r4", opCode, offset));
                        break;
                    }
                    case 0x57:
                    {
                        result.Add(new ILInstruction("stind.r8", opCode, offset));
                        break;
                    }
                    case 0x58:
                    {
                        result.Add(new ILInstruction("add", opCode, offset));
                        break;
                    }
                    case 0x59:
                    {
                        result.Add(new ILInstruction("sub", opCode, offset));
                        break;
                    }
                    case 0x5a:
                    {
                        result.Add(new ILInstruction("mul", opCode, offset));
                        break;
                    }
                    case 0x5b:
                    {
                        result.Add(new ILInstruction("div", opCode, offset));
                        break;
                    }
                    case 0x5c:
                    {
                        result.Add(new ILInstruction("div.un", opCode, offset));
                        break;
                    }
                    case 0x5d:
                    {
                        result.Add(new ILInstruction("rem", opCode, offset));
                        break;
                    }
                    case 0x5e:
                    {
                        result.Add(new ILInstruction("rem.un", opCode, offset));
                        break;
                    }
                    case 0x5f:
                    {
                        result.Add(new ILInstruction("and", opCode, offset));
                        break;
                    }
                    case 0x60:
                    {
                        result.Add(new ILInstruction("or", opCode, offset));
                        break;
                    }
                    case 0x61:
                    {
                        result.Add(new ILInstruction("xor", opCode, offset));
                        break;
                    }
                    case 0x62:
                    {
                        result.Add(new ILInstruction("shl", opCode, offset));
                        break;
                    }
                    case 0x63:
                    {
                        result.Add(new ILInstruction("shr", opCode, offset));
                        break;
                    }
                    case 0x64:
                    {
                        result.Add(new ILInstruction("shr.un", opCode, offset));
                        break;
                    }
                    case 0x65:
                    {
                        result.Add(new ILInstruction("neg", opCode, offset));
                        break;
                    }
                    case 0x66:
                    {
                        result.Add(new ILInstruction("not", opCode, offset));
                        break;
                    }
                    case 0x67:
                    {
                        result.Add(new ILInstruction("conv.i1", opCode, offset));
                        break;
                    }
                    case 0x68:
                    {
                        result.Add(new ILInstruction("conv.i2", opCode, offset));
                        break;
                    }
                    case 0x69:
                    {
                        result.Add(new ILInstruction("conv.i4", opCode, offset));
                        break;
                    }
                    case 0x6a:
                    {
                        result.Add(new ILInstruction("conv.i8", opCode, offset));
                        break;
                    }
                    case 0x6b:
                    {
                        result.Add(new ILInstruction("conv.r4", opCode, offset));
                        break;
                    }
                    case 0x6c:
                    {
                        result.Add(new ILInstruction("conv.r8", opCode, offset));
                        break;
                    }
                    case 0x6d:
                    {
                        result.Add(new ILInstruction("conv.u4", opCode, offset));
                        break;
                    }
                    case 0x6e:
                    {
                        result.Add(new ILInstruction("conv.i8", opCode, offset));
                        break;
                    }
                    case 0x6f:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("callvirt", opCode, offset));
                        break;
                    }
                    case 0x70:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("cpobj", opCode, offset));
                        break;
                    }
                    case 0x71:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("cldobj", opCode, offset));
                        break;
                    }
                    case 0x72:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldstr", opCode, offset));
                        break;
                    }
                    case 0x73:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("newobj", opCode, offset));
                        break;
                    }
                    case 0x74:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("castclass", opCode, offset));
                        break;
                    }
                    case 0x75:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("isinst", opCode, offset));
                        break;
                    }
                    case 0x76:
                    {
                        result.Add(new ILInstruction("conv.r.un", opCode, offset));
                        break;
                    }
                    case 0x79:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("unbox", opCode, offset));
                        break;
                    }
                    case 0x7a:
                    {
                        result.Add(new ILInstruction("throw", opCode, offset));
                        break;
                    }
                    case 0x7b:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldfld", opCode, offset));
                        break;
                    }
                    case 0x7c:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldflda", opCode, offset));
                        break;
                    }
                    case 0x7d:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("stfld", opCode, offset));
                        break;
                    }
                    case 0x7e:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldsfld", opCode, offset));
                        break;
                    }
                    case 0x7f:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldsflda", opCode, offset));
                        break;
                    }
                    case 0x80:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("stsfld", opCode, offset));
                        break;
                    }
                    case 0x81:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("stobj", opCode, offset));
                        break;
                    }
                    case 0x82:
                    {
                        result.Add(new ILInstruction("conv.ovf.i1.un", opCode, offset));
                        break;
                    }
                    case 0x83:
                    {
                        result.Add(new ILInstruction("conv.ovf.i2.un", opCode, offset));
                        break;
                    }
                    case 0x84:
                    {
                        result.Add(new ILInstruction("conv.ovf.i4.un", opCode, offset));
                        break;
                    }
                    case 0x85:
                    {
                        result.Add(new ILInstruction("conv.ovf.i8.un", opCode, offset));
                        break;
                    }
                    case 0x86:
                    {
                        result.Add(new ILInstruction("conv.ovf.u1.un", opCode, offset));
                        break;
                    }
                    case 0x87:
                    {
                        result.Add(new ILInstruction("conv.ovf.u2.un", opCode, offset));
                        break;
                    }
                    case 0x88:
                    {
                        result.Add(new ILInstruction("conv.ovf.u4.un", opCode, offset));
                        break;
                    }
                    case 0x89:
                    {
                        result.Add(new ILInstruction("conv.ovf.u8.un", opCode, offset));
                        break;
                    }
                    case 0x8a:
                    {
                        result.Add(new ILInstruction("conv.ovf.i.un", opCode, offset));
                        break;
                    }
                    case 0x8b:
                    {
                        result.Add(new ILInstruction("conv.ovf.u.un", opCode, offset));
                        break;
                    }
                    case 0x8c:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("box", opCode, offset));
                        break;
                    }
                    case 0x8d:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("newarray", opCode, offset));
                        break;
                    }
                    case 0x8e:
                    {
                        result.Add(new ILInstruction("ldlen", opCode, offset));
                        break;
                    }
                    case 0x8f:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldelema", opCode, offset));
                        break;
                    }
                    case 0x90:
                    {
                        result.Add(new ILInstruction("ldelema.il", opCode, offset));
                        break;
                    }
                    case 0x91:
                    {
                        result.Add(new ILInstruction("ldelema.ul", opCode, offset));
                        break;
                    }
                    case 0x92:
                    {
                        result.Add(new ILInstruction("ldelema.i2", opCode, offset));
                        break;
                    }
                    case 0x93:
                    {
                        result.Add(new ILInstruction("ldelema.u2", opCode, offset));
                        break;
                    }
                    case 0x94:
                    {
                        result.Add(new ILInstruction("ldelema.i4", opCode, offset));
                        break;
                    }
                    case 0x95:
                    {
                        result.Add(new ILInstruction("ldelema.u2", opCode, offset));
                        break;
                    }
                    case 0x96:
                    {
                        result.Add(new ILInstruction("ldelema.i8", opCode, offset));
                        break;
                    }
                    case 0x97:
                    {
                        result.Add(new ILInstruction("ldelema.i", opCode, offset));
                        break;
                    }
                    case 0x98:
                    {
                        result.Add(new ILInstruction("ldelema.r4", opCode, offset));
                        break;
                    }
                    case 0x99:
                    {
                        result.Add(new ILInstruction("ldelema.r8", opCode, offset));
                        break;
                    }
                    case 0x9a:
                    {
                        result.Add(new ILInstruction("ldelema.ref", opCode, offset));
                        break;
                    }
                    case 0x9b:
                    {
                        result.Add(new ILInstruction("stelem.i", opCode, offset));
                        break;
                    }
                    case 0x9c:
                    {
                        result.Add(new ILInstruction("stelem.il", opCode, offset));
                        break;
                    }
                    case 0x9d:
                    {
                        result.Add(new ILInstruction("stelem.i2", opCode, offset));
                        break;
                    }
                    case 0x9e:
                    {
                        result.Add(new ILInstruction("stelem.i4", opCode, offset));
                        break;
                    }
                    case 0x9f:
                    {
                        result.Add(new ILInstruction("stelem.i8", opCode, offset));
                        break;
                    }
                    case 0xa0:
                    {
                        result.Add(new ILInstruction("stelem.r4", opCode, offset));
                        break;
                    }
                    case 0xa1:
                    {
                        result.Add(new ILInstruction("stelem.r8", opCode, offset));
                        break;
                    }
                    case 0xa2:
                    {
                        result.Add(new ILInstruction("stelem.ref", opCode, offset));
                        break;
                    }
                    case 0xa3:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldelem.r4", opCode, offset));
                        break;
                    }
                    case 0xa4:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("stelem.r4", opCode, offset));
                        break;
                    }
                    case 0xa5:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("unbox.any", opCode, offset));
                        break;
                    }
                    case 0xb3:
                    {
                        result.Add(new ILInstruction("conv.ovf.il", opCode, offset));
                        break;
                    }
                    case 0xb4:
                    {
                        result.Add(new ILInstruction("conv.ovf.ul", opCode, offset));
                        break;
                    }
                    case 0xb5:
                    {
                        result.Add(new ILInstruction("conv.ovf.i2", opCode, offset));
                        break;
                    }
                    case 0xb6:
                    {
                        result.Add(new ILInstruction("conv.ovf.u2", opCode, offset));
                        break;
                    }
                    case 0xb7:
                    {
                        result.Add(new ILInstruction("conv.ovf.i4", opCode, offset));
                        break;
                    }
                    case 0xb8:
                    {
                        result.Add(new ILInstruction("conv.ovf.u4", opCode, offset));
                        break;
                    }
                    case 0xb9:
                    {
                        result.Add(new ILInstruction("conv.ovf.i8", opCode, offset));
                        break;
                    }
                    case 0xba:
                    {
                        result.Add(new ILInstruction("conv.ovf.u8", opCode, offset));
                        break;
                    }
                    case 0xc2:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("refanyval", opCode, offset));
                        break;
                    }
                    case 0xc3:
                    {
                        result.Add(new ILInstruction("ckfinite", opCode, offset));
                        break;
                    }
                    case 0xc6:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("mkrefany", opCode, offset));
                        break;
                    }

                    case 0xd0:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("ldtoken", opCode, offset));
                        break;
                    }
                    case 0xd1:
                    {
                        result.Add(new ILInstruction("conv.u2", opCode, offset));
                        break;
                    }
                    case 0xd2:
                    {
                        result.Add(new ILInstruction("conv.u1", opCode, offset));
                        break;
                    }
                    case 0xd3:
                    {
                        result.Add(new ILInstruction("conv.i", opCode, offset));
                        break;
                    }
                    case 0xd4:
                    {
                        result.Add(new ILInstruction("conv.ovf.i", opCode, offset));
                        break;
                    }
                    case 0xd5:
                    {
                        result.Add(new ILInstruction("conv.ovf.u", opCode, offset));
                        break;
                    }
                    case 0xd6:
                    {
                        result.Add(new ILInstruction("add.ovf", opCode, offset));
                        break;
                    }
                    case 0xd7:
                    {
                        result.Add(new ILInstruction("add.ovf.un", opCode, offset));
                        break;
                    }
                    case 0xd8:
                    {
                        result.Add(new ILInstruction("mul.ovf", opCode, offset));
                        break;
                    }
                    case 0xd9:
                    {
                        result.Add(new ILInstruction("mul.ovf.un", opCode, offset));
                        break;
                    }
                    case 0xda:
                    {
                        result.Add(new ILInstruction("sub.ovf", opCode, offset));
                        break;
                    }
                    case 0xdb:
                    {
                        result.Add(new ILInstruction("sub.ovf.un", opCode, offset));
                        break;
                    }
                    case 0xdc:
                    {
                        result.Add(new ILInstruction("endfinally", opCode, offset));
                        break;
                    }
                    case 0xdd:
                    {
                        var op = reader.ReadUInt32();
                        i += 4;
                        result.Add(new ILInstruction("leave", opCode, offset));
                        break;
                    }
                    case 0xde:
                    {
                        var op = reader.ReadByte();
                        i += 1;
                        result.Add(new ILInstruction("leave.s", opCode, offset));
                        break;
                    }
                    case 0xdf:
                    {
                        result.Add(new ILInstruction("stind.i", opCode, offset));
                        break;
                    }
                    case 0xe0:
                    {
                        result.Add(new ILInstruction("conv.u", opCode, offset));
                        break;
                    }

                    case 0xfe:
                    {
                        var opCode2 = reader.ReadByte();
                        i += 1;

                        switch (opCode2)
                        {
                            case 0x00:
                            {
                                result.Add(new ILInstruction("arglist", opCode, opCode2, offset));
                                break;
                            }
                            case 0x01:
                            {
                                result.Add(new ILInstruction("ceq", opCode, opCode2, offset));
                                break;
                            }
                            case 0x02:
                            {
                                result.Add(new ILInstruction("cgt", opCode, opCode2, offset));
                                break;
                            }
                            case 0x03:
                            {
                                result.Add(new ILInstruction("cgt.un", opCode, opCode2, offset));
                                break;
                            }
                            case 0x04:
                            {
                                result.Add(new ILInstruction("clt", opCode, opCode2, offset));
                                break;
                            }
                            case 0x05:
                            {
                                result.Add(new ILInstruction("clt.un", opCode, opCode2, offset));
                                break;
                            }
                            case 0x06:
                            {
                                var op = reader.ReadUInt32();
                                i += 4;
                                result.Add(new ILInstruction("ldftn", opCode, opCode2, offset));
                                break;
                            }
                            case 0x16:
                            {
                                var op = reader.ReadUInt32();
                                i += 4;
                                result.Add(new ILInstruction("constrained.", opCode, opCode2, offset));
                                break;
                            }
                            default:
                            {
                                throw new NotSupportedException(string.Format("0x{0:x2} 0x{1:x2}", opCode, opCode2));
                            }
                        }

                        break;
                    }

                    default:
                    {
                        throw new NotSupportedException(string.Format("0x{0:x2}", opCode));
                    }
                }
            }
            
            reader.BaseReader.Resume();

            return result;
        }
    }
}