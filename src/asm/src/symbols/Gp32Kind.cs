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
/// Defines classifiers for <see cref='GP'/> registers of width <see cref='W32'/>
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum Gp32Kind : ushort
{
    EAX = r0 | (GP << ClassField) | (W32 << WidthField),

    ECX = r1 | (GP << ClassField) | (W32 << WidthField),

    EDX = r2 | (GP << ClassField) | (W32 << WidthField),

    EBX = r3 | (GP << ClassField) | (W32 << WidthField),

    ESP = r4 | (GP << ClassField) | (W32 << WidthField),

    EBP = r5 | (GP << ClassField) | (W32 << WidthField),

    ESI = r6 | (GP << ClassField) | (W32 << WidthField),

    EDI = r7 | (GP << ClassField) | (W32 << WidthField),

    R8D = r8 | (GP << ClassField) | (W32 << WidthField),

    R9D = r9 | (GP << ClassField) | (W32 << WidthField),

    R10D = r10 | (GP << ClassField) | (W32 << WidthField),

    R11D = r11 | (GP << ClassField) | (W32 << WidthField),

    R12D = r12 | (GP << ClassField) | (W32 << WidthField),

    R13D = r13 | (GP << ClassField) | (W32 << WidthField),

    R14D = r14 | (GP << ClassField) | (W32 << WidthField),

    R15D = r15 | (GP << ClassField) | (W32 << WidthField),
}
