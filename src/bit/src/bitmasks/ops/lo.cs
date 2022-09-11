//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Bmi1;
    using static System.Runtime.Intrinsics.X86.Bmi1.X64;

    partial class BitMasks
    {
        /// <summary>
        /// Produces a sequence of n enabled bits, starting from index 0 and extending to index n - 1
        /// </summary>
        /// <typeparam name="N">The enabled bit count type</typeparam>
        [MethodImpl(Inline),Op]
        public static ulong lo64(int n)
            => lomask(Pow2.pow((byte)n));

        /// <summary>
        /// unsigned int _blsmsk_u32 (unsigned int a) BLSMSK reg, reg/m32
        /// Logically equivalent to the composite operation (src-1) ^ src that enables the lower bits of the source up to and including the least set bit
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline)]
        public static byte lomask(byte src)
            => (byte)GetMaskUpToLowestSetBit(src);

        /// <summary>
        /// unsigned int _blsmsk_u32 (unsigned int a) BLSMSK reg, reg/m32
        /// Logically equivalent to the composite operation (src-1) ^ src that enables the lower bits of the source up to and including the least set bit
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline)]
        public static ushort lomask(ushort src)
            => (ushort)GetMaskUpToLowestSetBit(src);

        /// <summary>
        /// unsigned int _blsmsk_u32 (unsigned int a) BLSMSK reg, reg/m32
        /// Logically equivalent to the composite operation (src-1) ^ src that enables the lower bits of the source up to and including the least set bit
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline)]
        public static uint lomask(uint src)
            => GetMaskUpToLowestSetBit(src);

        /// <summary>
        /// unsigned __int64 _blsmsk_u64 (unsigned __int64 a) BLSMSK reg, reg/m6
        /// Logically equivalent to the composite operation (src-1) ^ src that enables the lower bits of the source up to and including the least set bit
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline)]
        public static ulong lomask(ulong src)
            => GetMaskUpToLowestSetBit(src);

        /// <summary>
        /// Produces a sequence of N enabled bits, starting from index 0 and extending to index n - 1
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T lo<T>(byte n)
            where T : unmanaged
                => Numeric.force<ulong,T>(lo64(n));

        /// <summary>
        /// Produces a sequence of N enabled bits, starting from index 0 and extending to index n - 1
        /// </summary>
        /// <param name="n">The bit count type representative</param>
        /// <typeparam name="N">The enabled bit count type</typeparam>
        [MethodImpl(Inline)]
        public static ulong lo<N>(N n = default)
            where N : unmanaged, ITypeNat
                => Pow2.m1<N>();

        /// <summary>
        /// Produces a sequence of N enabled bits, starting from index 0 and extending to index n - 1
        /// </summary>
        /// <param name="n">The number of bits to enable</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="N">The enabled bit count type</typeparam>
        /// <typeparam name="T">The mask type</typeparam>
        [MethodImpl(Inline)]
        public static T lo<N,T>(N n = default, T t = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => Numeric.force<ulong,T>(lo(n));
    }
}