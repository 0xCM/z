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
    public static AsmSigOp m8()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.m8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp m16()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.m16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp m32()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.m32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp m64()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.m64);

    [MethodImpl(Inline), Op]
    public static AsmSigOp m128()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.m128);

    [MethodImpl(Inline), Op]
    public static AsmSigOp m256()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.m256);

    [MethodImpl(Inline), Op]
    public static AsmSigOp m512()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.m512);

    [MethodImpl(Inline), Op]
    public static AsmSigOp rm8()
        => new (AsmSigTokenKind.GpRm,(byte)GpRmToken.rm8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp rm16()
        => new (AsmSigTokenKind.GpRm,(byte)GpRmToken.rm16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp rm32()
        => new (AsmSigTokenKind.GpRm,(byte)GpRmToken.rm32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp rm64()
        => new (AsmSigTokenKind.GpRm,(byte)GpRmToken.rm64);

    [MethodImpl(Inline), Op]
    public static AsmSigOp r16m16()
        => new (AsmSigTokenKind.GpRm,(byte)GpRmToken.r16m16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp r32m8()
        => new (AsmSigTokenKind.GpRm,(byte)GpRmToken.r32m8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp imm8()
        => new (AsmSigTokenKind.Imm, (byte)ImmToken.imm8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp imm16()
        => new (AsmSigTokenKind.Imm, (byte)ImmToken.imm16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp imm32()
        => new (AsmSigTokenKind.Imm, (byte)ImmToken.imm32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp imm64()
        => new (AsmSigTokenKind.Imm, (byte)ImmToken.imm64);

    [MethodImpl(Inline), Op]
    public static AsmSigOp r8()
        => new (AsmSigTokenKind.GpReg, (byte)GpRegToken.r8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp r16()
        => new (AsmSigTokenKind.GpReg, (byte)GpRegToken.r16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp r32()
        => new (AsmSigTokenKind.GpReg, (byte)GpRegToken.r32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp r64()
        => new (AsmSigTokenKind.GpReg, (byte)GpRegToken.r64);

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
    public static AsmSigOp al()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.AL);

    [MethodImpl(Inline), Op]
    public static AsmSigOp ax()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.AX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp dx()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.DX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp eax()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.EAX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp edx()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.EDX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp rax()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.RAX);

    [MethodImpl(Inline), Op]
    public static AsmSigOp ds()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.DS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp es()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.ES);

    [MethodImpl(Inline), Op]
    public static AsmSigOp fs()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.FS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp gs()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.GS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp ss()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.SS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp cs()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.CS);

    [MethodImpl(Inline), Op]
    public static AsmSigOp cl()
        => new (AsmSigTokenKind.RegLiteral, (byte)RegLiteralToken.CL);

}
