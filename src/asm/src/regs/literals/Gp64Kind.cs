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
/// Defines classifiers for <see cref='GP'/> registers of width <see cref='W64'/>
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum Gp64Kind : ushort
{
    RAX = r0 | (GP << ClassField) | (W64 << WidthField),

    RCX = r1 | (GP << ClassField) | (W64 << WidthField),

    RDX = r2 | (GP << ClassField) | (W64 << WidthField),

    RBX = r3 | (GP << ClassField) | (W64 << WidthField),

    RSP = r4 | (GP << ClassField) | (W64 << WidthField),

    RBP = r5 | (GP << ClassField) | (W64 << WidthField),

    RSI = r6 | (GP << ClassField) | (W64 << WidthField),

    RDI = r7 | (GP << ClassField) | (W64 << WidthField),

    R8Q = r8 | (GP << ClassField) | (W64 << WidthField),

    R9Q = r9 | (GP << ClassField) | (W64 << WidthField),

    R10Q = r10 | (GP << ClassField) | (W64 << WidthField),

    R11Q = r11| (GP << ClassField) | (W64 << WidthField),

    R12Q = r12 | (GP << ClassField) | (W64 << WidthField),

    R13Q = r13 | (GP << ClassField) | (W64 << WidthField),

    R14Q = r14 | (GP << ClassField) | (W64 << WidthField),

    R15Q = r15 | (GP << ClassField) | (W64 << WidthField),
}
