//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static RegFacets;
    using static RegIndexCode;
    using static RegClassCode;
    using static NativeSizeCode;
    using static NumericBaseKind;

    [SymSource("asm.regs.bits", Base16)]
    public enum XControlRegKind : ushort
    {
        XCR0 = r0 | XCR << ClassField | W64 << WidthField,
    }
}