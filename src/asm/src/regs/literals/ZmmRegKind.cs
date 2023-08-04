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
/// Defines <see cref='ZMM'/> register classifiers
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum ZmmRegKind : ushort
{
    ZMM0 = r0 | ZMM << ClassField | W512 << WidthField,

    ZMM1 = r1 | ZMM << ClassField | W512 << WidthField,

    ZMM2 = r2 | ZMM << ClassField | W512 << WidthField,

    ZMM3 = r3 | ZMM << ClassField | W512 << WidthField,

    ZMM4 = r4 | ZMM << ClassField | W512 << WidthField,

    ZMM5 = r5 | ZMM << ClassField | W512 << WidthField,

    ZMM6 = r6 | ZMM << ClassField | W512 << WidthField,

    ZMM7 = r7 | ZMM << ClassField | W512 << WidthField,

    ZMM8 = r8 | ZMM << ClassField | W512 << WidthField,

    ZMM9 = r9 | ZMM << ClassField | W512 << WidthField,

    ZMM10 = r10 | ZMM << ClassField | W512 << WidthField,

    ZMM11 = r11 | ZMM << ClassField | W512 << WidthField,

    ZMM12 = r12 | ZMM << ClassField | W512 << WidthField,

    ZMM13 = r13 | ZMM << ClassField | W512 << WidthField,

    ZMM14 = r14 | ZMM << ClassField | W512 << WidthField,

    ZMM15 = r15 | ZMM << ClassField | W512 << WidthField,

    ZMM16 = r16 | ZMM << ClassField | W512 << WidthField,

    ZMM17 = r17 | ZMM << ClassField | W512 << WidthField,

    ZMM18 = r18 | ZMM << ClassField | W512 << WidthField,

    ZMM19 = r19 | ZMM << ClassField | W512 << WidthField,

    ZMM20 = r20 | ZMM << ClassField | W512 << WidthField,

    ZMM21 = r21 | ZMM << ClassField | W512 << WidthField,

    ZMM22 = r22 | ZMM << ClassField | W512 << WidthField,

    ZMM23 = r23 | ZMM << ClassField | W512 << WidthField,

    ZMM24 = r24 | ZMM << ClassField | W512 << WidthField,

    ZMM25 = r25 | ZMM << ClassField | W512 << WidthField,

    ZMM26 = r26 | ZMM << ClassField | W512 << WidthField,

    ZMM27 = r27 | ZMM << ClassField | W512 << WidthField,

    ZMM28 = r28 | ZMM << ClassField | W512 << WidthField,

    ZMM29 = r29 | ZMM << ClassField | W512 << WidthField,

    ZMM30 = r30 | ZMM << ClassField | W512 << WidthField,

    ZMM31 = r31 | ZMM << ClassField | W512 << WidthField,
}
