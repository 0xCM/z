//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static DataWidth;
using static NumericBaseKind;

/// <summary>
/// Defines an equivalence class that partitions the set of x86-64 registers
/// </summary>
[SymSource("asm.regs.bits", Base16), DataWidth(6)]
public enum RegClassCode : byte
{
    /// <summary>
    /// A general-purpose register of width <see cref='W8'/>, <see cref='W16'/>, <see cref='W32'/> or <see cref='W64'/>
    /// </summary>
    [Symbol("gp", "A general purpose register")]
    GP = 0,

    /// <summary>
    /// Classifies a 64-bit mask register
    /// </summary>
    [Symbol("mask", "A 64-bit avx512 mask register")]
    MASK = 1,

    /// <summary>
    /// Classifies an xmm vector register of width <see cref='W128'/>
    /// </summary>
    [Symbol("xmm", "An xmm register")]
    XMM = 2,

    /// <summary>
    /// Classifies a ymm vector register of width <see cref='W256'/>
    /// </summary>
    [Symbol("ymm", "A ymm register")]
    YMM = 3,

    /// <summary>
    /// Classifies a zmm vector register of width <see cref='W512'/>
    /// </summary>
    [Symbol("zmm", "A zmm register")]
    ZMM = 4,

    /// <summary>
    /// Classifies a 64-bit mmx register
    /// </summary>
    [Symbol("mmx", "An mmx register")]
    MMX = 5,

    /// <summary>
    /// Identifies a segment register
    /// </summary>
    [Symbol("seg", "A segment regitser")]
    SEG = 6,

    /// <summary>
    /// An flag register of width <see cref='W16'/>, <see cref='W32'/> or <see cref='W64'/>
    /// </summary>
    [Symbol("flags", "A system flags register")]
    FLAG = 7,

    /// <summary>
    /// Class identifier control registers
    /// </summary>
    [Symbol("cr", "A control register")]
    CR = 8,

    /// <summary>
    /// Classifies a 64-bit extended control register
    /// </summary>
    [Symbol("xcr", "An extended control register")]
    XCR = 9,

    /// <summary>
    /// Class identifier for debug registers
    /// </summary>
    [Symbol("db", "A debug register")]
    DB = 10,

    /// <summary>
    /// Classifies an 80-bit fpu register
    /// </summary>
    [Symbol("st", "An 80-bit fpu register")]
    ST = 11,

    /// <summary>
    /// Classifies a bounds register
    /// </summary>
    [Symbol("bnd", "A bounds register")]
    BND = 12,

    /// <summary>
    /// Class identifier for pointer table registers
    /// </summary>
    [Symbol("sptr", "A table-pointer register")]
    SPTR = 13,

    /// <summary>
    /// Classifies an instruction-pointer register of width <see cref='W16'/>, <see cref='W32'/> or <see cref='W64'/>
    /// </summary>
    [Symbol("iptr", "An instruction-pointer register")]
    IPTR = 14,

    /// <summary>
    /// Classifies a hi byte register
    /// </summary>
    [Symbol("gp8hi", "A hi gp8 register")]
    GP8HI = 15,

    /// <summary>
    /// Classifies test registers
    /// </summary>
    [Symbol("tr", "A test register")]
    TR = 16,

    /// <summary>
    /// Classifies tile maxtrix multiplication registers
    /// </summary>
    [Symbol("tmm", "An amx register")]
    TMM = 17,
}
