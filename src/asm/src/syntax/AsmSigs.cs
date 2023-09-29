//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;
using static AsmSigTokens;

[ApiHost]
public partial class AsmSigs
{
    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(Rel8 src)
        => new (AsmSigTokenKind.Rel, (byte)RelToken.rel8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(Rel16 src)
        => new (AsmSigTokenKind.Rel, (byte)RelToken.rel16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(Rel32 src)
        => new (AsmSigTokenKind.Rel, (byte)RelToken.rel32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(Imm8 src)
        => new (AsmSigTokenKind.Imm, (byte)ImmToken.imm8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(Imm16 src)
        => new (AsmSigTokenKind.Imm, (byte)ImmToken.imm16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(Imm32 src)
        => new (AsmSigTokenKind.Imm, (byte)ImmToken.imm32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(Imm64 src)
        => new (AsmSigTokenKind.Imm, (byte)ImmToken.imm64);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(r8 src)
        => new (AsmSigTokenKind.GpReg, (byte)GpRegToken.r8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(r16 src)
        => new (AsmSigTokenKind.GpReg, (byte)GpRegToken.r16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(r32 src)
        => new (AsmSigTokenKind.GpReg, (byte)GpRegToken.r32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(r64 src)
        => new (AsmSigTokenKind.GpReg, (byte)GpRegToken.r64);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(xmm src)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.xmm);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(ymm src)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.ymm);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(zmm src)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.zmm);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(m8 src)
        => new (AsmSigTokenKind.Mem, (byte)MemToken.m8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(m16 src)
        => new (AsmSigTokenKind.Mem, (byte)MemToken.m16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(m32 src)
        => new (AsmSigTokenKind.Mem, (byte)MemToken.m32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(m64 src)
        => new (AsmSigTokenKind.Mem, (byte)MemToken.m64);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(m128 src)
        => new (AsmSigTokenKind.Mem, (byte)MemToken.m128);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(m256 src)        
        => new (AsmSigTokenKind.Mem, (byte)MemToken.m256);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(m512 src)
        => new (AsmSigTokenKind.Mem, (byte)MemToken.m512);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(al src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.AL);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(ax src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.AX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(dx src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.DX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(eax src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.EAX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(edx src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.EDX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(rax src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.RAX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(ds src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.DS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(es src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.ES);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(fs src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.FS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(gs src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.GS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(ss src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.SS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(cs src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.CS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp sig(cl src)
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.CL);

}
