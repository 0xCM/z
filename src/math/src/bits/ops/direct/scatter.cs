//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.X86.Bmi2;
using static System.Runtime.Intrinsics.X86.Bmi2.X64;

using x64 = System.Runtime.Intrinsics.X86.Bmi2.X64;

partial class bits
{
    /// <summary>
    /// Deposits contiguous low bits from the source across a target according to a mask
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="mask">The mask</param>
    [MethodImpl(Inline), Scatter]
    public static byte scatter(byte src, byte mask)
        => (byte)ParallelBitDeposit(src, mask);

    /// <summary>
    /// Deposits contiguous low bits from the source across a target according to a mask
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="mask">The mask</param>
    [MethodImpl(Inline), Scatter]
    public static ushort scatter(ushort src, ushort mask)
        => (ushort)ParallelBitDeposit(src,mask);

    /// <summary>
    /// unsigned int _pdep_u32 (unsigned int a, unsigned int mask) PDEP r32a, r32b, reg/m32
    /// Deposits contiguous low bits from the source across a target according to a mask
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="mask">The mask</param>
    [MethodImpl(Inline), Scatter]
    public static uint scatter(uint src, uint mask)
        => ParallelBitDeposit(src, mask);

    /// <summary>
    /// unsigned __int64 _pdep_u64 (unsigned __int64 a, unsigned __int64 mask) PDEP r64a, r64b, reg/m64
    /// Deposits contiguous low bits from the source across a target according to a mask
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="mask">The mask</param>
    [MethodImpl(Inline), Scatter]
    public static ulong scatter(ulong src, ulong mask)
        => x64.ParallelBitDeposit(src,mask);
}
