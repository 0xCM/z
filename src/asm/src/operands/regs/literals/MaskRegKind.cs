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

/// <summary>
/// Defines classifiers for <see cref='MASK'/> registers of width <see cref='W64'/>
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum MaskRegKind : ushort
{
    K0 = r0 | MASK << ClassField | W64 << WidthField,

    K1 = r1 | MASK << ClassField | W64 << WidthField,

    K2 = r2 | MASK << ClassField | W64 << WidthField,

    K3 = r3 | MASK << ClassField | W64 << WidthField,

    K4 = r4 | MASK << ClassField | W64 << WidthField,

    K5 = r5 | MASK << ClassField | W64 << WidthField,

    K6 = r6 | MASK << ClassField | W64 << WidthField,

    K7 = r7 | MASK << ClassField | W64 << WidthField,
}
