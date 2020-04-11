using System;

namespace Disassembler
{
    internal sealed class ILInstruction
    {
        internal ILInstruction(string name, byte opCode, int offset)
        {
            Name   = name;
            OpCode = new[] { opCode };
            Offset = offset;
        }

        internal ILInstruction(string name, byte opCode1, byte opCode2, int offset)
        {
            Name = name;
            OpCode = new[] { opCode1, opCode2 };
            Offset = offset;
        }

        internal string Name   { get; }
        internal byte[] OpCode { get; }
        internal int    Offset { get; }
    }
}