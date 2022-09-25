// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Z0
{
    using static MsilCodeModels;

    [Record(TableId), StructLayout(StructLayout,Pack=1)]
    public struct MsilOpCode
    {
        public const string TableId ="cil.opcodes";

        [Render(16)]
        public ILOpCode OpCode;

        [Render(10)]
        public Hex16 CodeValue;

        [Render(16)]
        public asci16 Name;

        [Render(12)]
        public OpCodeType CodeType;

        [Render(24)]
        public OperandType ArgType;

        [Render(10)]
        public byte ArgCount;

        [Render(16)]
        public StackBehaviour Sb1;

        [Render(16)]
        public StackBehaviour Sb2;

        [MethodImpl(Inline)]
        public MsilOpCode(ILOpCode id, Hex16 value, asci16 name, OpCodeType type, OperandType optype, byte opcount, StackBehaviour sb1, StackBehaviour sb2)
        {
            OpCode = id;
            CodeValue = value;
            Name = name;
            CodeType = type;
            ArgType =  optype;
            ArgCount = opcount;
            Sb1 = sb1;
            Sb2 = sb2;
        }
    }
}