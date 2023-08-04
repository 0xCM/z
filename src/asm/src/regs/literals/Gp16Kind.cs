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
/// Defines classifiers for <see cref='GP'/> registers of width <see cref='W16'/>
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum Gp16Kind : ushort
{
    AX = r0 | (GP << ClassField) | (W16 << WidthField),

    CX = r1 | (GP << ClassField) | (W16 << WidthField),

    DX = r2 | (GP << ClassField) | (W16 << WidthField),

    BX = r3 | (GP << ClassField) | (W16 << WidthField),

    SP = r4 | (GP << ClassField) | (W16 << WidthField),

    BP = r5 | (GP << ClassField) | (W16 << WidthField),

    SI = r6 | (GP << ClassField) | (W16 << WidthField),

    DI = r7 | (GP << ClassField) | (W16 << WidthField),

    R8W = r8 | (GP << ClassField) | (W16 << WidthField),

    R9W = r9 | (GP << ClassField) | (W16 << WidthField),

    R10W = r10 | (GP << ClassField) | (W16 << WidthField),

    R11W = r11 | (GP << ClassField) | (W16 << WidthField),

    R12W = r12 | (GP << ClassField) | (W16 << WidthField),

    R13W = r13 | (GP << ClassField) | (W16 << WidthField),

    R14W = r14 | (GP << ClassField) | (W16 << WidthField),

    R15W = r15 | (GP << ClassField) | (W16 << WidthField),
}
