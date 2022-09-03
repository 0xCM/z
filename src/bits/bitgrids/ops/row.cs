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
    using static core;
    using static cpu;

    partial class BitGrid
    {
        /// <summary>
        /// Extracts an index-identified row from a 16-bit grid
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The row index, which must be an integer in the range[0...M-1]</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> row<M,N,T>(BitGrid16<M,N,T> g, int index)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => generic<T>(bits.slice(g.Content, ScalarCast.uint8(nat32i<N>()*index),(byte)nat32i<N>()));

        /// <summary>
        /// Extracts an index-identified row from a 32-bit grid
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The row index, which must be an integer in the range[0...M-1]</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> row<M,N,T>(BitGrid32<M,N,T> g, int index)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => generic<T>(bits.slice(g.Content, ScalarCast.uint8(nat32i<N>()*index),(byte)nat32i<N>()));

        /// <summary>
        /// Extracts an index-identified row from a 64-bit grid
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The row index, which must be an integer in the range[0...M-1]</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> row<M,N,T>(BitGrid64<M,N,T> g, int index)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => generic<T>(gbits.slice(g.Content, (byte)(index*nat32i<N>()), nat8u<N>()));

        /// <summary>
        /// Extracts an index-identified row from a 16-bit subgrid
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The row index, which must be an integer in the range[0...M-1]</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> row<M,N,T>(SubGrid16<M,N,T> g, int index, N width = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => generic<T>(bits.slice(g.Content, ScalarCast.uint8(index* nat32i<N>()), (byte)nat32i<N>()));

        /// <summary>
        /// Extracts an index-identified row from a 32-bit subgrid
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The row index, which must be an integer in the range[0...M-1]</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> row<N,M,T>(SubGrid32<M,N,T> g, int index, N width = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => generic<T>(bits.slice(g.Content, ScalarCast.uint8(index* nat32i<N>()), (byte)nat32i<N>()));

        /// <summary>
        /// Extracts an index-identified row from a 64-bit subgrid
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The row index, which must be an integer in the range[0...M-1]</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> row<M,N,T>(SubGrid64<M,N,T> g, int index, N width = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => generic<T>(bits.slice(g.Content, ScalarCast.uint8(index*nat32i<N>()), (byte)nat32i<N>()));

        /// <summary>
        /// Extracts an index-identifed 64-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index, either 0 or 1</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N64,ulong> row<T>(in BitGrid128<N2,N64,T> g, int index)
            where T : unmanaged
                => v64u(g.Content).GetElement(index);

        /// <summary>
        /// Extracts an index-identifed 32-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index in the range [0...3]</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N32,uint> row<T>(in BitGrid128<N4,N32,T> g, int index)
            where T : unmanaged
                => v32u(g.Content).GetElement(index);

        /// <summary>
        /// Extracts an index-identifed 16-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index in the range [0...7]</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N16,ushort> row<T>(in BitGrid128<N8,N16,T> g, int index)
            where T : unmanaged
                => v16u(g.Content).GetElement(index);

        /// <summary>
        /// Extracts an index-identifed 8-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index in the range [0...15]</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N8,byte> row<T>(in BitGrid128<N16,N8,T> g, int index)
            where T : unmanaged
                => v8u(g.Content).GetElement(index);

        /// <summary>
        /// Extracts an index-identifed 4-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index in the range [0...31]</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N4,byte> row<T>(in BitGrid128<N32,N4,T> g, int index)
            where T : unmanaged
        {
            uint cell = v8u(g.Content).GetElement(index/2);
            return Numeric.force<byte>((gmath.odd(index) ? cell >> 4 : 0xF & cell));
        }

        /// <summary>
        /// Extracts an index-identifed 32-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index in the range [0...7]</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N32,uint> row<T>(in BitGrid256<N8,N32,T> g, int index)
            where T : unmanaged
                => v32u(g.Content).GetElement(index);

        /// <summary>
        /// Extracts an index-identifed 8-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index in the range [0...31]</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N8,byte> row<T>(in BitGrid256<N32,N8,T> g, int index)
            where T : unmanaged
                => v8u(g.Content).GetElement(index);

        /// <summary>
        /// Extracts an index-identifed 16-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index in the range [0...15]</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N16,ushort> row<T>(in BitGrid256<N16,N16,T> g, int index)
            where T : unmanaged
                => v16u(g.Content).GetElement(index);

        [MethodImpl(Inline)]
        public static BitGrid256<N16,N16,T> row<T>(in BitGrid256<N16,N16,T> g, int index, ScalarBits<N16,ushort> data)
            where T : unmanaged
                => v16u(g.Content).WithElement(index, data);

        /// <summary>
        /// Extracts an index-identifed 64-bit grid row
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The zero-based column index in the range [0...3]</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N64,ulong> row<T>(in BitGrid256<N4,N64,T> g, int index)
            where T : unmanaged
                => v64u(g.Content).GetElement(index);
    }
}