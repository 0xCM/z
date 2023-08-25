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
/// Defines <see cref='XMM'/> register classifiers
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum XmmRegKind : ushort
{
    XMM0 = r0 | XMM << ClassField | W128 << WidthField,

    XMM1 = r1 | XMM << ClassField | W128 << WidthField,

    XMM2 = r2 | XMM << ClassField | W128 << WidthField,

    XMM3 = r3 | XMM << ClassField | W128 << WidthField,

    XMM4 = r4 | XMM << ClassField | W128 << WidthField,

    XMM5 = r5 | XMM << ClassField | W128 << WidthField,

    XMM6 = r6 | XMM << ClassField | W128 << WidthField,

    XMM7 = r7 | XMM << ClassField | W128 << WidthField,

    XMM8 = r8 | XMM << ClassField | W128 << WidthField,

    XMM9 = r9 | XMM << ClassField | W128 << WidthField,

    XMM10 = r10 | XMM << ClassField | W128 << WidthField,

    XMM11 = r11 | XMM << ClassField | W128 << WidthField,

    XMM12 = r12 | XMM << ClassField | W128 << WidthField,

    XMM13 = r13 | XMM << ClassField | W128 << WidthField,

    XMM14 = r14 | XMM << ClassField | W128 << WidthField,

    XMM15 = r15 | XMM << ClassField | W128 << WidthField,

    XMM16 = r16 | XMM << ClassField | W128 << WidthField,

    XMM17 = r17 | XMM << ClassField | W128 << WidthField,

    XMM18 = r18 | XMM << ClassField | W128 << WidthField,

    XMM19 = r19 | XMM << ClassField | W128 << WidthField,

    XMM20 = r20 | XMM << ClassField | W128 << WidthField,

    XMM21 = r21 | XMM << ClassField | W128 << WidthField,

    XMM22 = r22 | XMM << ClassField | W128 << WidthField,

    XMM23 = r23 | XMM << ClassField | W128 << WidthField,

    XMM24 = r24 | XMM << ClassField | W128 << WidthField,

    XMM25 = r25 | XMM << ClassField | W128 << WidthField,

    XMM26 = r26 | XMM << ClassField | W128 << WidthField,

    XMM27 = r27 | XMM << ClassField | W128 << WidthField,

    XMM28 = r28 | XMM << ClassField | W128 << WidthField,

    XMM29 = r29 | XMM << ClassField | W128 << WidthField,

    XMM30 = r30 | XMM << ClassField | W128 << WidthField,

    XMM31 = r31 | XMM << ClassField | W128 << WidthField,
}
