//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Numerics;
using static System.Runtime.Intrinsics.X86.Bmi1;
using static System.Runtime.Intrinsics.X86.Bmi1.X64;

partial class bits
{
    /// <summary>
    /// Extracts the lowest set bit from the source operand and set the corresponding bit in the destination register.
    /// All other bits in the destination operand are zeroed. If no bits are set in the source operand, BLSI sets all
    /// the bits in the destination to 0 and sets ZF and CF.
    /// unsigned int _blsi_u32 (unsigned int a)
    /// BLSI reg, reg/m32
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="pos">The position of the first bit</param>
    /// <param name="width">The number of bits that should be extracted</param>
    [MethodImpl(Inline), Op]
    public static sbyte blsi(sbyte src)
        => (sbyte)ExtractLowestSetBit((uint)src);

    /// <summary>
    /// Extracts the lowest set bit from the source operand and set the corresponding bit in the destination register.
    /// All other bits in the destination operand are zeroed. If no bits are set in the source operand, BLSI sets all
    /// the bits in the destination to 0 and sets ZF and CF.
    /// unsigned int _blsi_u32 (unsigned int a)
    /// BLSI reg, reg/m32
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="pos">The bit position within the source where extraction should benin</param>
    /// <param name="width">The number of bits that should be extracted</param>
    [MethodImpl(Inline), Op]
    public static byte blsi(byte src)
        => (byte)ExtractLowestSetBit((uint)src);

    /// <summary>
    /// Extracts the lowest set bit from the source operand and set the corresponding bit in the destination register.
    /// All other bits in the destination operand are zeroed. If no bits are set in the source operand, BLSI sets all
    /// the bits in the destination to 0 and sets ZF and CF.
    /// unsigned int _blsi_u32 (unsigned int a)
    /// BLSI reg, reg/m32
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="pos">The bit position within the source where extraction should benin</param>
    /// <param name="width">The number of bits that should be extracted</param>
    [MethodImpl(Inline), Op]
    public static short blsi(short src)
        => (short)ExtractLowestSetBit((uint)src);

    /// <summary>
    /// Extracts the lowest set bit from the source operand and set the corresponding bit in the destination register.
    /// dst := src & ~src
    /// All other bits in the destination operand are zeroed. If no bits are set in the source operand, BLSI sets all
    /// the bits in the destination to 0 and sets ZF and CF.
    /// unsigned int _blsi_u32 (unsigned int a)
    /// BLSI reg, reg/m32
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="pos">The bit position within the source where extraction should benin</param>
    /// <param name="width">The number of bits that should be extracted</param>
    [MethodImpl(Inline), Op]
    public static ushort blsi(ushort src)
        => (ushort)ExtractLowestSetBit((uint)src);

    /// <summary>
    /// Extracts the lowest set bit from the source operand and set the corresponding bit in the destination register.
    /// All other bits in the destination operand are zeroed. If no bits are set in the source operand, BLSI sets all
    /// the bits in the destination to 0 and sets ZF and CF.
    /// unsigned int _blsi_u32 (unsigned int a)
    /// BLSI reg, reg/m32
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="pos">The bit position within the source where extraction should benin</param>
    /// <param name="width">The number of bits that should be extracted</param>
    [MethodImpl(Inline), Op]
    public static int blsi(int src)
        => (int)ExtractLowestSetBit((uint)src);

    /// <summary>
    /// Extracts the lowest set bit from the source operand and set the corresponding bit in the destination register.
    /// All other bits in the destination operand are zeroed. If no bits are set in the source operand, BLSI sets all
    /// the bits in the destination to 0 and sets ZF and CF.
    /// unsigned int _blsi_u32 (unsigned int a)
    /// BLSI reg, reg/m32
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="pos">The bit position within the source where extraction should benin</param>
    /// <param name="width">The number of bits that should be extracted</param>
    [MethodImpl(Inline), Op]
    public static uint blsi(uint src)
        => ExtractLowestSetBit((uint)src);

    /// <summary>
    /// Extracts the lowest set bit from the source operand and set the corresponding bit in the destination register.
    /// All other bits in the destination operand are zeroed. If no bits are set in the source operand, BLSI sets all
    /// the bits in the destination to 0 and sets ZF and CF.
    /// unsigned int _blsi_u32 (unsigned int a)
    /// BLSI reg, reg/m32
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="pos">The bit position within the source where extraction should benin</param>
    /// <param name="width">The number of bits that should be extracted</param>
    [MethodImpl(Inline), Op]
    public static long blsi(long src)
        => (long)ExtractLowestSetBit((uint)src);

    /// <summary>
    /// Extracts the lowest set bit from the source operand and set the corresponding bit in the destination register.
    /// All other bits in the destination operand are zeroed. If no bits are set in the source operand, BLSI sets all
    /// the bits in the destination to 0 and sets ZF and CF.
    /// unsigned __int64 _blsi_u64 (unsigned __int64 a)
    /// BLSI reg, reg/m64
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="pos">The bit position within the source where extraction should benin</param>
    /// <param name="width">The number of bits that should be extracted</param>
    [MethodImpl(Inline), Op]
    public static ulong blsi(ulong src)
        => ExtractLowestSetBit(src);
}
