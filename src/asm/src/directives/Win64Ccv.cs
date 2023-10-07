//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static AsmRegTokens;

[ApiHost("ccv.win64")]
public readonly record struct Win64Ccv : ICallCv<Win64Ccv>
{

    public CcvKind Kind => CcvKind.Win64;

    [MethodImpl(Inline)]
    public static implicit operator Win64Ccv(CcvKind src)
        => default;

    [MethodImpl(Inline)]
    public static implicit operator CcvKind(Win64Ccv src)
        => src.Kind;

    [MethodImpl(Inline), Op]
    public static ReadOnlySpan<Gp8LoReg> regs(W8 w)
        => recover<Gp8LoReg>(slice(Data,0,Win64MaxReg + 1));

    [MethodImpl(Inline), Op]
    public static ReadOnlySpan<Gp16Reg> regs(W16 w)
        => recover<Gp16Reg>(slice(Data,0,Win64MaxReg + 1));

    [MethodImpl(Inline), Op]
    public static ReadOnlySpan<Gp32Reg> regs(W32 w)
        => recover<Gp32Reg>(slice(Data,0,Win64MaxReg + 1));

    [MethodImpl(Inline), Op]
    public static ReadOnlySpan<Gp64Reg> regs(W64 w)
        => recover<Gp64Reg>(slice(Data,0,Win64MaxReg + 1));

    [MethodImpl(Inline), Op]
    public static ref readonly Gp8LoReg reg(W8 w, byte index)
        => ref skip(regs(w), index);

    [MethodImpl(Inline), Op]
    public static ref readonly Gp16Reg reg(W16 w, byte index)
        => ref skip(regs(w), index);

    [MethodImpl(Inline), Op]
    public static ref readonly Gp32Reg reg(W32 w, byte index)
        => ref skip(regs(w), index);

    [MethodImpl(Inline), Op]
    public static ref readonly Gp64Reg reg(W64 w, byte index)
        => ref skip(regs(w), index);

    [MethodImpl(Inline), Op]
    public static bit slot(byte index, out Gp8LoReg dst)
    {
        var i = math.and(index,Win64MaxReg);
        bit valid = i <= Win64MaxReg;
        dst = reg(w8,i);
        return valid;
    }

    [MethodImpl(Inline), Op]
    public static bit slot(byte index, out Gp16Reg dst)
    {
        var i = math.and(index,Win64MaxReg);
        bit valid = i <= Win64MaxReg;
        dst = reg(w16,i);
        return valid;
    }

    [MethodImpl(Inline), Op]
    public static bit slot(byte index, out Gp32Reg dst)
    {
        var i = math.and(index,Win64MaxReg);
        bit valid = i <= Win64MaxReg;
        dst = reg(w32,i);
        return valid;
    }

    [MethodImpl(Inline), Op]
    public static bit slot(byte index, out Gp64Reg dst)
    {
        var i = math.and(index,Win64MaxReg);
        bit valid = i <= Win64MaxReg;
        dst = reg(w64,i);
        return valid;
    }

    const byte CcvSize = 64;

    const byte Win64MaxReg = 3;

    // rax=0, rcx=1, rdx=2, rbx=3, rsp=4, rbp=5, rsi=6, rdi=7, r8=8, r9=9, r10=10, r11, r12, r13, r14, r15
    static ReadOnlySpan<byte> Data
        => new byte[CcvSize]{
            1,2,8,9,0,0,0,0,
            0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,
            32,33,34,35,36,37,38,39,
            40,41,42,43,44,45,46,47,
            48,49,50,51,52,53,54,56,
            57,58,59,60,61,62,63,64};
}
