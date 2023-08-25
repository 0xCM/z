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
/// Defines classifiers for <see cref='GP'/> registers of width <see cref='W8'/>
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum Gp8Kind : ushort
{
    AL = r0 | (GP << ClassField) | (W8 << WidthField),

    AH = r4 | (GP8HI << ClassField) | (W8 << WidthField),

    CL = r1 | (GP << ClassField) | (W8 << WidthField),

    CH = r5 | (GP8HI << ClassField) | (W8 << WidthField),

    DL = r2 | (GP << ClassField) | (W8 << WidthField),

    DH = r6 | (GP8HI << ClassField) | (W8 << WidthField),

    BL = r3 | (GP << ClassField) | (W8 << WidthField),

    BH = r7 | (GP8HI << ClassField) | (W8 << WidthField),

    SPL = r4 | (GP << ClassField) | (W8 << WidthField),

    BPL = r5 | (GP << ClassField) | (W8 << WidthField),

    SIL = r6 | (GP << ClassField) | (W8 << WidthField),

    DIL = r7 | (GP << ClassField) | (W8 << WidthField),

    R8B = r8 | (GP << ClassField) | (W8 << WidthField),

    R9B = r9 | (GP << ClassField) | (W8 << WidthField),

    R10B = r10 | (GP << ClassField) | (W8 << WidthField),

    R11B = r11 | (GP << ClassField) | (W8 << WidthField),

    R12B = r12 | (GP << ClassField) | (W8 << WidthField),

    R13B = r13 | (GP << ClassField) | (W8 << WidthField),

    R14B = r14 | (GP << ClassField) | (W8 << WidthField),

    R15B = r15 | (GP << ClassField) | (W8 << WidthField),
}
