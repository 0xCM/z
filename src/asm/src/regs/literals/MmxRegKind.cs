//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static RegFacets;
using static RegIndexCode;
using static RegClassCode;
using static NativeSizeCode;
using static NumericBaseKind;

[SymSource("asm.regs.bits", Base16)]
public enum MmxRegKind : ushort
{
    MM0 = r0 | MMX << ClassField | W64 << WidthField,

    MM1 = r1 | MMX << ClassField | W64 << WidthField,

    MM2 = r2 | MMX << ClassField | W64 << WidthField,

    MM3 = r3 | MMX << ClassField | W64 << WidthField,

    MM4 = r4 | MMX << ClassField | W64 << WidthField,

    MM5 = r5 | MMX << ClassField | W64 << WidthField,

    MM6 = r6 | MMX << ClassField | W64 << WidthField,

    MM7 = r7 | MMX << ClassField | W64 << WidthField,
}
