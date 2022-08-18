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
        /// Fills a target block with replicated cell data
        /// </summary>
        /// <param name="data">The data used to fill the block</param>
        /// <param name="dst">The target block</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline),Op, Closures(AllNumeric)]
        public static void broadcast<T>(T data, in SpanBlock256<T> dst)
            where T : unmanaged
                => dst.Fill(data);

        /// <summary>
        /// Creates a dynamically-sized grid of natural dimensions filled with specified data
        /// </summary>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid<M,N,T> init<M,N,T>(M m = default, N n = default, T d = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var blocksize = n256;
            var blocks = SpanBlocks.alloc<T>(blocksize, CellCalcs.blockcount(blocksize, m,n,d));
            broadcast(d, blocks);
            return new BitGrid<M,N,T>(blocks);
        }

        /// <summary>
        /// Initializes a 128-bit grid of natural dimensions
        /// </summary>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        static BitGrid16<M,N,T> init16<M,N,T>(M m = default, N n = default, T d = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid16<M,N,T>(gcpu.broadcast<T,ushort>(d));

        /// <summary>
        /// Initializes a 32-bit grid of natural dimensions
        /// </summary>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        static BitGrid32<M,N,T> init32<M,N,T>(M m = default, N n = default, T d = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid32<M,N,T>(gcpu.broadcast<T,uint>(d));

        /// <summary>
        /// Initializes a 64-bit grid of natural dimensions
        /// </summary>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        static BitGrid64<M,N,T> init64<M,N,T>(M m = default, N n = default, T d = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid64<M,N,T>(gcpu.broadcast<T,ulong>(d));

        /// <summary>
        /// Initializes a 128-bit grid of natural dimensions
        /// </summary>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        static BitGrid128<M,N,T> init128<M,N,T>(M m = default, N n = default, T d = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid128<M,N,T>(gcpu.vbroadcast(n128, d));

        /// <summary>
        /// Initializes a 256-bit grid of natural dimensions
        /// </summary>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        static BitGrid256<M,N,T> init256<M,N,T>(M m = default, N n = default, T d = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid256<M,N,T>(gcpu.vbroadcast(n256, d));
    }
}