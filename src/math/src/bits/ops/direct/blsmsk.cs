//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.X86.Bmi1;
using static System.Runtime.Intrinsics.X86.Bmi1.X64;

partial class bits
{
    /// <summary>
    /// Enables the lower bits of the source up to and including the least set bit, dst =: (src-1) ^ src
    /// unsigned int _blsmsk_u32 (unsigned int a)
    /// BLSMSK reg, reg/m32
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static byte blsmsk(byte src)
        => (byte)GetMaskUpToLowestSetBit((uint)src);

    /// <summary>
    /// Enables the lower bits of the source up to and including the least set bit, dst =: (src-1) ^ src
    /// unsigned int _blsmsk_u32 (unsigned int a)
    /// BLSMSK reg, reg/m32
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static sbyte blsmsk(sbyte src)
        => (sbyte)GetMaskUpToLowestSetBit((uint)src);

    /// <summary>
    /// Enables the lower bits of the source up to and including the least set bit, dst =: (src-1) ^ src
    /// unsigned int _blsmsk_u32 (unsigned int a)
    /// BLSMSK reg, reg/m32
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static ushort blsmsk(ushort src)
        => (ushort)GetMaskUpToLowestSetBit((uint)src);

    /// <summary>
    /// Enables the lower bits of the source up to and including the least set bit, dst =: (src-1) ^ src
    /// unsigned int _blsmsk_u32 (unsigned int a)
    /// BLSMSK reg, reg/m32
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static short blsmsk(short src)
        => (short)GetMaskUpToLowestSetBit((uint)src);

    /// <summary>
    /// Enables the lower bits of the source up to and including the least set bit, dst =: (src-1) ^ src
    /// unsigned int _blsmsk_u32 (unsigned int a)
    /// BLSMSK reg, reg/m32
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static uint blsmsk(uint src)
        => GetMaskUpToLowestSetBit(src);

    /// <summary>
    /// Enables the lower bits of the source up to and including the least set bit, dst =: (src-1) ^ src
    /// unsigned int _blsmsk_u32 (unsigned int a)
    /// BLSMSK reg, reg/m32
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static int blsmsk(int src)
        => (int)GetMaskUpToLowestSetBit((uint)src);

    /// <summary>
    /// Enables the lower bits of the source up to and including the least set bit, dst =: (src-1) ^ src
    /// unsigned int _blsmsk_u32 (unsigned int a)
    /// BLSMSK reg, reg/m32
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static ulong blsmsk(ulong src)
        => GetMaskUpToLowestSetBit(src);

    /// <summary>
    /// Enables the lower bits of the source up to and including the least set bit, dst =: (src-1) ^ src
    /// unsigned int _blsmsk_u32 (unsigned int a)
    /// BLSMSK reg, reg/m32
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static long blsmsk(long src)
        => (long)GetMaskUpToLowestSetBit((ulong)src);
}
