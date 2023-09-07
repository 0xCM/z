//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.X86.Bmi2;
using static System.Runtime.Intrinsics.X86.Bmi2.X64;

partial class bits
{
    /// <summary>
    /// unsigned int _bzhi_u32 (unsigned int a, unsigned int index) BZHI r32a, reg/m32, r32b
    /// Replicates the source bits to the target and disables the high target bits starting at a specified index.
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), MsbOff]
    public static byte zhi(byte src, byte offset)
        => (byte)ZeroHighBits((uint)src, offset);

    /// <summary>
    /// unsigned int _bzhi_u32 (unsigned int a, unsigned int index) BZHI r32a, reg/m32, r32b
    /// Replicates the source bits to the target and disables the high target bits starting at a specified index.
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), MsbOff]
    public static ushort zhi(ushort src, byte offset)
        => (ushort)ZeroHighBits((uint)src, offset);

    /// <summary>
    /// unsigned int _bzhi_u32 (unsigned int a, unsigned int index) BZHI r32a, reg/m32, r32b
    /// Replicates the source bits to the target and disables the high target bits starting at a specified index.
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), MsbOff]
    public static uint zhi(uint src, byte offset)
        => ZeroHighBits(src, offset);

    /// <summary>
    /// unsigned __int64 _bzhi_u64 (unsigned __int64 a, unsigned int index) BZHI r64a,reg/m32, r64b
    /// Disables the high target bits starting at a specified index.
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="offset">The index at which to begin disabling bits</param>
    [MethodImpl(Inline), MsbOff]
    public static ulong zhi(ulong src, byte offset)
        => ZeroHighBits(src, offset);

    [MethodImpl(Inline), MsbOff]
    public static uint zhi(uint src, uint offset)
        => ZeroHighBits(src, offset);

    [MethodImpl(Inline), MsbOff]
    public static ulong zhi(ulong src, ulong offset)
        => ZeroHighBits(src, offset);
}
