//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static NativeSizeCode;
    using static RegFacets;
    using static RegClassCode;
    using static NumericBaseKind;
    using static RegIndexCode;

    /// <summary>
    /// Classifies instruction pointer registers
    /// </summary>
    [SymSource("asm.regs.bits", Base16)]
    public enum IpRegKind : ushort
    {
        IP =  r0 | IPTR << ClassField | W16 << WidthField,

        EIP = r0 | IPTR << ClassField | W32 << WidthField,

        RIP = r0 | IPTR << ClassField | W64 << WidthField,
    }
}