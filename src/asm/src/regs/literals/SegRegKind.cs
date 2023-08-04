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
/// Defines <see cref='SEG'/> register classifiers
/// </summary>
[SymSource("asm.regs.bits", Base16)]
public enum SegRegKind : ushort
{
    /// <summary>
    /// Code segment register; contains the segment offset address of the executing instruction in a code segment
    /// </summary>
    CS = r0 | SEG << ClassField | W16 << WidthField,

    /// <summary>
    /// Data segment register; contains offset address of data/variables
    /// </summary>
    DS = r1 | SEG << ClassField | W16 << WidthField,

    /// <summary>
    /// Stack segment register; contains the offset address of the stack segment
    /// </summary>
    SS = r2 | SEG << ClassField | W16 << WidthField,

    /// <summary>
    /// Extra segment (1); contains offset address of arbitrary kind
    /// </summary>
    ES = r3 | SEG << ClassField | W16 << WidthField,

    /// <summary>
    /// Extra segment (2); contains offset address of arbitrary kind
    /// </summary>
    FS = r4 | SEG << ClassField | W16 << WidthField,

    /// <summary>
    /// Extra segment (3); contains offset address of arbitrary kind
    /// </summary>
    GS = r5 | SEG << ClassField | W16 << WidthField,
}
