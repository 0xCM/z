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
    /// int _mm_tzcnt_32 (unsigned int a) TZCNT reg, reg/m32
    /// Counts the number of trailing zero bits in the source
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Ntz]
    public static byte tzcnt(byte src)
        => src == 0 ? (byte)8 : (byte)tzcnt((uint)src);

    /// <summary>
    /// int _mm_tzcnt_32 (unsigned int a) TZCNT reg, reg/m32
    /// Counts the number of trailing zero bits in the source
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Ntz]
    public static ushort tzcnt(ushort src)
        => src == 0 ? (ushort)16 : (ushort)tzcnt((uint)src);

    /// <summary>
    /// int _mm_tzcnt_32 (unsigned int a)
    /// TZCNT reg, reg/m32
    /// Counts the number of trailing zero bits in the source
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Ntz]
    public static uint tzcnt(uint src)
        => TrailingZeroCount(src);

    /// <summary>
    /// __int64 _mm_tzcnt_64 (unsigned __int64 a)
    /// TZCNT reg, reg/m64
    /// Counts the number of trailing zero bits in the source
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Ntz]
    public static ulong tzcnt(ulong src)
        => TrailingZeroCount(src);
}
