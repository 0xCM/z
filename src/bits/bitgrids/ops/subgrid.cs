//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static BitMaskLiterals;

    partial class BitGrid
    {
        [MethodImpl(Inline), Init]
        public static SubGrid32<N8,N3,uint> subgrid(Perm8L p)
            => (uint)p;

        [MethodImpl(Inline), Init]
        public static SubGrid32<N8,N3,uint> subgrid(NatPerm<N8> p)
            => subgrid(p.ToLiteral());

        [Init]
        public static SubGrid256<N32,N5,ulong> subgrid(NatPerm<N32> p)
        {
            var m = n32;
            var n = n5;
            var w = n256;
            var dst = SpanBlocks.single<ulong>(w);
            var mask = Lsb64x8x5;
            var bs = BitStrings.alloc(w);
            for(int i=0, j=0 ; i< p.Length; i++, j+=5)
                bs.BitMap(p[i].ToBitString(),j, 5);
            return BitGrid.subgrid(bs.ToCpuVector<ulong>(w), m,n);
        }

        /// <summary>
        /// Allocates a 0-filled 16-bit subgrid
        /// </summary>
        /// <param name="w">The total bit-width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid16<M,N,T> subgrid<M,N,T>(N16 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid16<M,N,T>(Root.z16);

        /// <summary>
        /// Allocates a populated 16-bit subgrid
        /// </summary>
        /// <param name="w">The total bit-width selector</param>
        /// <param name="data">The data with which to populate the grid</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid16<M,N,T> subgrid<M,N,T>(N16 w, T data, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid16<M, N, T>(Numeric.force<T,ushort>(data));

        /// <summary>
        /// Allocates a 0-filled 32-bit subgrid
        /// </summary>
        /// <param name="w">The total bit-width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid32<M,N,T> subgrid<M,N,T>(N32 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid32<M,N,T>(Root.z32);

        /// <summary>
        /// Allocates a populated 32-bit subgrid
        /// </summary>
        /// <param name="w">The total bit-width selector</param>
        /// <param name="data">The data with which to populate the grid</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid32<M,N,T> subgrid<M,N,T>(N32 w, T data, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid32<M,N,T>(Numeric.force<T,uint>(data));

        /// <summary>
        /// Allocates a 0-filled 64-bitsubgrid
        /// </summary>
        /// <param name="w">The total bit-width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid64<M,N,T> subgrid<M,N,T>(N64 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid64<M,N,T>(Root.z64);

        /// <summary>
        /// Allocates a populated 64-bit subgrid
        /// </summary>
        /// <param name="w">The total bit-width selector</param>
        /// <param name="data">The data with which to populate the grid</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid64<M,N,T> subgrid<M,N,T>(N64 w, T data, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid64<M,N,T>(Numeric.force<T,ulong>(data));

        /// <summary>
        /// Allocates a 0-filled 128-bit subgrid
        /// </summary>
        /// <param name="w">The total bit-width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid128<M,N,T> subgrid<M,N,T>(N128 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid128<M,N,T>(default);

        /// <summary>
        /// Allocates a populated 128-bit subgrid
        /// </summary>
        /// <param name="data">The data with which to populate the grid</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid128<M,N,T> subgrid<M,N,T>(Vector128<T> data, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid128<M,N,T>(data);

        [MethodImpl(Inline)]
        public static SubGrid128<M,N,T> subgrid<M,N,T>(BitGrid128<M,N,T> data)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid128<M,N,T>(data);

        /// <summary>
        /// Allocates a 0-filled 256-bit subgrid
        /// </summary>
        /// <param name="w">The total bit-width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid256<M,N,T> subgrid<M,N,T>(N256 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid256<M,N,T>(default);

        /// <summary>
        /// Allocates a populated 256-bit subgrid
        /// </summary>
        /// <param name="data">The data with which to populate the grid</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static SubGrid256<M,N,T> subgrid<M,N,T>(Vector256<T> data, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new SubGrid256<M,N,T>(data);
    }
}