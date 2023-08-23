// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Z0;

using static CilModels;

[Record(TableId), StructLayout(StructLayout,Pack=1)]
public readonly record struct CilOpCode
{
    public const string TableId ="cil.opcodes";

    [Render(16)]
    public readonly ILOpCode OpCode;

    [Render(10)]
    public readonly Hex16 CodeValue;

    [Render(16)]
    public readonly OpCodeName Name;

    [Render(12)]
    public readonly OpCodeType CodeType;

    [Render(24)]
    public readonly OperandType ArgType;

    [Render(10)]
    public readonly byte ArgCount;

    [Render(16)]
    public readonly StackBehaviour Sb1;

    [Render(16)]
    public readonly StackBehaviour Sb2;

    [MethodImpl(Inline)]
    public CilOpCode(ILOpCode id, Hex16 value, OpCodeName name, OpCodeType type, OperandType optype, byte opcount, StackBehaviour sb1, StackBehaviour sb2)
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
