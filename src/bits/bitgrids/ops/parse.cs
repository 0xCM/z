//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitGrid
    {
        /// <summary>
        /// Hydrates a fixed-width 32-bit dimensionless grid from a bitstring
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <param name="w">The number of bitstring bits to parse</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Parse, Closures(UInt8x16k)]
        public static BitGrid16<T> parse<T>(BitString bs, W16 w)
            where T : unmanaged
                => init16<T>(bs.TakeUInt16());

        /// <summary>
        /// Hydrates a fixed-width 32-bit dimensionless grid from a bitstring
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <param name="n">The number of bitstring bits to parse</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Parse, Closures(UInt8x16x32k)]
        public static BitGrid32<T> parse<T>(BitString bs, N32 n, int rows, int cols, T t = default)
            where T : unmanaged
                => init32<T>(bs.TakeUInt32());

        /// <summary>
        /// Hydrates a fixed-width 64-bit dimensionless grid from a bitstring
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <param name="n">The number of bitstring bits to parse</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Parse, Closures(UnsignedInts)]
        public static BitGrid64<T> parse<T>(BitString bs, N64 n, int rows, int cols, T t = default)
            where T : unmanaged
                => init64<T>(bs.TakeUInt64());

        /// <summary>
        /// Hydrates a fixed-width natural bitgrid from a bitstring
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <param name="w">The number of bitstring bits to parse</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid16<M,N,T> parse<M,N,T>(BitString bs, N16 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => bs.TakeUInt16();

        /// <summary>
        /// Hydrates a fixed-width natural bitgrid from a bitstring
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <param name="w">The number of bitstring bits to parse</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid32<M,N,T> parse<M,N,T>(BitString bs, N32 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => bs.TakeUInt32();

        /// <summary>
        /// Hydrates a 64-bit natural bitgrid from a bitstring
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <param name="w">The number of bitstring bits to parse</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid64<M,N,T> parse<M,N,T>(BitString bs, N64 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => bs.TakeUInt64();

        /// <summary>
        /// Hydrates a 128-bit natural bitgrid from a bitstring
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <param name="w">The number of bitstring bits to parse</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> parse<M,N,T>(BitString bs, N128 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => gcpu.vload(w, bs.Pack(0,w));

        /// <summary>
        /// Hydrates a 256-bit natural bitgrid from a bitstring
        /// </summary>
        /// <param name="bs">The source bitstring</param>
        /// <param name="w">The number of bitstring bits to parse</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> parse<M,N,T>(BitString bs, N256 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => gcpu.vload(w, bs.Pack(0,w));
    }
}