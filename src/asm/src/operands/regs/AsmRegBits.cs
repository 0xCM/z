//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static Asm.RegFacets;

[ApiHost]
public class AsmRegBits
{
    [MethodImpl(Inline), Op]
    public static RegOp reg(NativeSizeCode size, RegClassCode @class, RegIndexCode index)
        => new (AsmRegs.kind(size, @class, index));
    
    /// <summary>
    /// Determines the register code from the kind
    /// </summary>
    /// <param name="src">The source kind</param>
    [MethodImpl(Inline), Op]
    public static RegIndexCode index(RegKind src)
        => (RegIndexCode)bits.slice((uint)src, (byte)RegFieldIndex.C, (byte)RegFieldWidth.RegIndex);

    /// <summary>
    /// Determines the register index from the operand
    /// </summary>
    /// <param name="src">The register operand</param>
    [MethodImpl(Inline), Op]
    public static RegIndexCode index(RegOp src)
        => index(src.RegKind);

    /// <summary>
    /// Determines the register class from the kind
    /// </summary>
    /// <param name="src">The source kind</param>
    [MethodImpl(Inline), Op]
    public static RegClassCode @class(RegKind src)
        => (RegClassCode)bits.slice((uint)src, (byte)RegFieldIndex.K, (byte)RegFieldWidth.RegClass);

    /// <summary>
    /// Determines the register class from the operand
    /// </summary>
    /// <param name="src">The register operand</param>
    [MethodImpl(Inline), Op]
    public static RegClassCode @class(RegOp src)
        => @class(src.RegKind);

    /// <summary>
    /// Determines the width of the register represented by a specified kind
    /// </summary>
    /// <param name="src">The source kind</param>
    [MethodImpl(Inline), Op]
    public static NativeSizeCode width(RegKind src)
        => (NativeSizeCode)bits.slice((uint)src, (byte)RegFieldIndex.W, (byte)RegFieldWidth.RegWidth);

    /// <summary>
    /// Determines the width of a specified operand
    /// </summary>
    /// <param name="src">The source operand</param>
    [MethodImpl(Inline), Op]
    public static NativeSizeCode width(RegOp src)
        => width(src.RegKind);


    [SymSource("asm.regs.bits")]
    public enum RegFieldIndex : byte
    {
        /// <summary>
        /// [4:0]
        /// </summary>
        C = IndexField,

        /// <summary>
        /// [10:5]
        /// </summary>
        K = ClassField,

        /// <summary>
        /// [14:11]
        /// </summary>
        W = WidthField,
    }

    [SymSource("asm.regs.bits")]
    public enum RegFieldWidth : byte
    {
        RegIndex = 5,

        RegClass = 5,

        RegWidth = 3,
    }
}
