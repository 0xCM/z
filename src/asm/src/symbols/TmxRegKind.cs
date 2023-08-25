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
public enum TmmRegKind : ushort
{
    TMM0 = r0 | TMM << ClassField | W512 << WidthField,

    TMM1 = r1 | TMM << ClassField | W512 << WidthField,

    TMM2 = r2 | TMM << ClassField | W512 << WidthField,

    TMM3 = r3 | TMM << ClassField | W512 << WidthField,

    TMM4 = r4 | TMM << ClassField | W512 << WidthField,

    TMM5 = r5 | TMM << ClassField | W512 << WidthField,

    TMM6 = r6 | TMM << ClassField | W512 << WidthField,

    TMM7 = r7 | TMM << ClassField | W512 << WidthField,
}
