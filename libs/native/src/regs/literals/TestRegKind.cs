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
    public enum TestRegKind : ushort
    {
        TR0 = r0 | TR << ClassField | W64 << WidthField,

        TR1 = r1 | TR << ClassField | W64 << WidthField,

        TR2 = r2 | TR << ClassField | W64 << WidthField,

        TR3 = r3 | TR << ClassField | W64 << WidthField,

        TR4 = r4 | TR << ClassField | W64 << WidthField,

        TR5 = r5 | TR << ClassField | W64 << WidthField,

        TR6 = r6 | TR << ClassField | W64 << WidthField,

        TR7 = r7 | TR << ClassField | W64 << WidthField,
    }
}