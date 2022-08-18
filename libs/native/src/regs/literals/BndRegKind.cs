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
    public enum BndRegKind : ushort
    {
        BND0 = r0 | BND << ClassField | W128 << WidthField,

        BND1 = r1 | BND << ClassField | W128 << WidthField,

        BND2 = r2 | BND << ClassField | W128 << WidthField,

        BND3 = r3 | BND << ClassField | W128 << WidthField,
    }
}