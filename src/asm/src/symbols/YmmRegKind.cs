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
/// Defines <see cref='YMM'/> register classifiers
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum YmmRegKind : ushort
{
    YMM0 = r0 | YMM << ClassField | W256 << WidthField,

    YMM1 = r1 | YMM << ClassField | W256 << WidthField,

    YMM2 = r2 | YMM << ClassField | W256 << WidthField,

    YMM3 = r3 | YMM << ClassField | W256 << WidthField,

    YMM4 = r4 | YMM << ClassField | W256 << WidthField,

    YMM5 = r5 | YMM << ClassField | W256 << WidthField,

    YMM6 = r6 | YMM << ClassField | W256 << WidthField,

    YMM7 = r7 | YMM << ClassField | W256 << WidthField,

    YMM8 = r8 | YMM << ClassField | W256 << WidthField,

    YMM9 = r9 | YMM << ClassField | W256 << WidthField,

    YMM10 = r10 | YMM << ClassField | W256 << WidthField,

    YMM11 = r11 | YMM << ClassField | W256 << WidthField,

    YMM12 = r12 | YMM << ClassField | W256 << WidthField,

    YMM13 = r13 | YMM << ClassField | W256 << WidthField,

    YMM14 = r14 | YMM << ClassField | W256 << WidthField,

    YMM15 = r15 | YMM << ClassField | W256 << WidthField,

    YMM16 = r16 | YMM << ClassField | W256 << WidthField,

    YMM17 = r17 | YMM << ClassField | W256 << WidthField,

    YMM18 = r18 | YMM << ClassField | W256 << WidthField,

    YMM19 = r19 | YMM << ClassField | W256 << WidthField,

    YMM20 = r20 | YMM << ClassField | W256 << WidthField,

    YMM21 = r21 | YMM << ClassField | W256 << WidthField,

    YMM22 = r22 | YMM << ClassField | W256 << WidthField,

    YMM23 = r23 | YMM << ClassField | W256 << WidthField,

    YMM24 = r24 | YMM << ClassField | W256 << WidthField,

    YMM25 = r25 | YMM << ClassField | W256 << WidthField,

    YMM26 = r26 | YMM << ClassField | W256 << WidthField,

    YMM27 = r27 | YMM << ClassField | W256 << WidthField,

    YMM28 = r28 | YMM << ClassField | W256 << WidthField,

    YMM29 = r29 | YMM << ClassField | W256 << WidthField,

    YMM30 = r30 | YMM << ClassField | W256 << WidthField,

    YMM31 = r31 | YMM << ClassField | W256 << WidthField,
}
