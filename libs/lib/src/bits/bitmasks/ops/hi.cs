//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Numeric;

    partial class BitMasks
    {
        /// <summary>
        /// Produces a sequence of enabled hi bits
        /// </summary>
        /// <param name="n">The number of bits to enable</param>
        [MethodImpl(Inline), Op]
        public static ulong hi64(int n)
            => lo64(n) << (64 - n);

        /// <summary>
        /// Produces a sequence of enabled hi bits
        /// </summary>
        /// <param name="n">The number of bits to enable</param>
        [MethodImpl(Inline), Op]
        public static ulong hi64(byte n)
            => lo64(n) << (64 - n);

        /// <summary>
        /// Produces a sequence of n enabled bits in the index range [bitsize[T] - n, bitsize[T] - 1]
        /// </summary>
        /// <param name="n">The number of bits to enable</param>
        /// <param name="t">A mask type representative</param>
        /// <typeparam name="T">The mask type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T hi<T>(int n)
            where T : unmanaged
                => force<T>(lo64(n) << ((int)width<T>() - n));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T hi<T>(byte n)
            where T : unmanaged
                => force<T>(lo64(n) << ((int)width<T>() - n));

        /// <summary>
        /// Produces a sequence of N enabled hi bits
        /// </summary>
        /// <param name="n">The number of bits to enable</param>
        /// <typeparam name="N">The bit count type</typeparam>
        [MethodImpl(Inline)]
        public static ulong hi<N>(N n = default)
            where N : unmanaged, ITypeNat
                => hi<ulong>((int)nat64u(n));

        /// <summary>
        /// Produces a sequence of n enabled hi bits
        /// </summary>
        /// <param name="n">The number of bits to enable</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static T hi<N,T>(N n = default, T t = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => hi<T>((int)nat64u(n));
    }
}