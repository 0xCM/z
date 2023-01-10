//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    using C = AsmOpClass;
    using SZ = NativeSizeCode;

    [Flags,SymSource(asm)]
    public enum AsmOpKind : ushort
    {
        None,

        Reg = C.Reg,

        Mem = C.Mem,

        Imm = C.Imm,

        RegMask = C.RegMask,

        Disp = C.Disp,

        Rel = C.Rel,

        GpReg8 = Reg | (SZ.W8 << 8),

        GpReg16 = Reg | (SZ.W16 << 8),

        GpReg32 = Reg | (SZ.W32 << 8),

        GpReg64 = Reg | (SZ.W64 << 8),

        VReg128 = Reg | (SZ.W128 << 8),

        VReg256 = Reg | (SZ.W256 << 8),

        VReg512 = Reg | (SZ.W512 << 8),

        FpuReg = Reg | (SZ.W80 << 8),

        RegMask8 = RegMask | (SZ.W8 << 8),

        RegMask16 = RegMask | (SZ.W16 << 8),

        RegMask32 = RegMask | (SZ.W32 << 8),

        RegMask64 = RegMask | (SZ.W64 << 8),

        RegMask128 = RegMask | (SZ.W128 << 8),

        RegMask256 = RegMask | (SZ.W256 << 8),

        RegMask512 = RegMask | (SZ.W512 << 8),

        Mem8 = Mem | (SZ.W8 << 8),

        Mem16 = Mem | (SZ.W16 << 8),

        Mem32 = Mem | (SZ.W32 << 8),

        Mem64 = Mem | (SZ.W64 << 8),

        Mem128 = Mem | (SZ.W128 << 8),

        Mem256 = Mem | (SZ.W256 << 8),

        Mem512 = Mem | (SZ.W512 << 8),

        Mem80 = Mem | (SZ.W80 << 8),

        Imm8 = Imm | (SZ.W8 << 8),

        Imm16 = Imm | (SZ.W16 << 8),

        Imm32 = Imm | (SZ.W32 << 8),

        Imm64 = Imm | (SZ.W64 << 8),

        Disp8 = Disp | (SZ.W8 << 8),

        Disp16 = Disp | (SZ.W16 << 8),

        Disp32 = Disp | (SZ.W32 << 8),

        Disp64 = Disp | (SZ.W64 << 8),

        Rel8 = Rel | (SZ.W8 << 8),

        Rel16 = Rel | (SZ.W16 << 8),

        Rel32 = Rel | (SZ.W32 << 8),
    }
}