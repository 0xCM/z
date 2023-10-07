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
    public static AsmSigOp m()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.m);

    [MethodImpl(Inline), Op]
    public static AsmSigOp mib()
        => new (AsmSigTokenKind.Mem,(byte)MemToken.mib);

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
    public static AsmSigOp xmm()
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.xmm);

    [MethodImpl(Inline), Op]
    public static AsmSigOp xmm(N1 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.xmm1);

    [MethodImpl(Inline), Op]
    public static AsmSigOp xmm(N2 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.xmm2);

    [MethodImpl(Inline), Op]
    public static AsmSigOp xmm(N3 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.xmm3);

    [MethodImpl(Inline), Op]
    public static AsmSigOp ymm()
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.ymm);

    [MethodImpl(Inline), Op]
    public static AsmSigOp ymm(N1 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.ymm1);

    [MethodImpl(Inline), Op]
    public static AsmSigOp ymm(N2 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.ymm2);

    [MethodImpl(Inline), Op]
    public static AsmSigOp ymm(N3 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.ymm3);

    [MethodImpl(Inline), Op]
    public static AsmSigOp zmm()
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.zmm);

    [MethodImpl(Inline), Op]
    public static AsmSigOp zmm(N1 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.zmm1);

    [MethodImpl(Inline), Op]
    public static AsmSigOp zmm(N2 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.zmm2);

    [MethodImpl(Inline), Op]
    public static AsmSigOp zmm(N3 n)
        => new (AsmSigTokenKind.VReg, (byte)VRegToken.zmm3);

    [MethodImpl(Inline), Op]
    public static AsmSigOp k()
        => new (AsmSigTokenKind.KReg, (byte)KRegToken.k);

    [MethodImpl(Inline), Op]
    public static AsmSigOp rk()
        => new (AsmSigTokenKind.KReg, (byte)KRegToken.rK);

    [MethodImpl(Inline), Op]
    public static AsmSigOp k(N1 n)
        => new (AsmSigTokenKind.KReg, (byte)KRegToken.k1);
    
    [MethodImpl(Inline), Op]
    public static AsmSigOp k(N2 n)
        => new (AsmSigTokenKind.KReg, (byte)KRegToken.k2);

    [MethodImpl(Inline), Op]
    public static AsmSigOp k(N3 n)
        => new (AsmSigTokenKind.KReg, (byte)KRegToken.k3);

    [MethodImpl(Inline), Op]
    public static AsmSigOp mask(N1 n)
        => new (AsmSigTokenKind.OpMask, (byte)OpMaskToken.k1);

    [MethodImpl(Inline), Op]
    public static AsmSigOp mask(N2 n)
        => new (AsmSigTokenKind.OpMask, (byte)OpMaskToken.k2);

    [MethodImpl(Inline), Op]
    public static AsmSigOp zmask()
        => new (AsmSigTokenKind.OpMask, (byte)OpMaskToken.z);

    [MethodImpl(Inline), Op]
    public static AsmSigOp k1z()
        => new (AsmSigTokenKind.OpMask, (byte)OpMaskToken.k1z);

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

    [MethodImpl(Inline), Op]
    public static AsmSigOp rel8()
        => new (AsmSigTokenKind.Rel, (byte)RelToken.rel8);

    [MethodImpl(Inline), Op]
    public static AsmSigOp rel16()
        => new (AsmSigTokenKind.Rel, (byte)RelToken.rel16);

    [MethodImpl(Inline), Op]
    public static AsmSigOp rel32()
        => new (AsmSigTokenKind.Rel, (byte)RelToken.rel32);

    [MethodImpl(Inline), Op]
    public static AsmSigOp vm32x()
        => new (AsmSigTokenKind.Vsib, (byte)VsibToken.vm32x);

    [MethodImpl(Inline), Op]
    public static AsmSigOp vm32y()
        => new (AsmSigTokenKind.Vsib, (byte)VsibToken.vm32y);

    [MethodImpl(Inline), Op]
    public static AsmSigOp vm32z()
        => new (AsmSigTokenKind.Vsib, (byte)VsibToken.vm32z);

    [MethodImpl(Inline), Op]
    public static AsmSigOp vm64x()
        => new (AsmSigTokenKind.Vsib, (byte)VsibToken.vm64x);

    [MethodImpl(Inline), Op]
    public static AsmSigOp vm64y()
        => new (AsmSigTokenKind.Vsib, (byte)VsibToken.vm64y);

    [MethodImpl(Inline), Op]
    public static AsmSigOp vm64z()
        => new (AsmSigTokenKind.Vsib, (byte)VsibToken.vm64z);
}
