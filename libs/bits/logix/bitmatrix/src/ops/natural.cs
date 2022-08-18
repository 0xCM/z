//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitMatrix
    {
        /// <summary>
        /// Projects, without allocation, a primal bitmatrix onto a generic bitmatrix of natural order
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix<N8,byte> natural(in BitMatrix8 A)
            => new BitMatrix<N8,byte>(A.Bytes.Replicate());

        /// <summary>
        /// Projects, without allocation, a primal bitmatrix onto a generic bitmatrix of natural order
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix<N16,byte> natural(in BitMatrix16 A)
            => new BitMatrix<N16,byte>(A.Bytes);

        /// <summary>
        /// Projects, without allocation, a primal bitmatrix onto a generic bitmatrix of natural order
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix<N32,byte> natural(in BitMatrix32 A)
            => new BitMatrix<N32,byte>(A.Bytes);

        /// <summary>
        /// Projects, without allocation, a primal bitmatrix onto a generic bitmatrix of natural order
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Op]
        public static BitMatrix<N64,byte> natural(in BitMatrix64 A)
            => new BitMatrix<N64,byte>(A.Bytes);

        /// <summary>
        /// Creates a square bitmatrix of natural order from a single cell
        /// </summary>
        /// <param name="data">The data cell</param>
        /// <param name="n">The order representative</param>
        /// <typeparam name="N">The order type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<N,T> natural<N,T>(T data, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitMatrix<N,T>(data);

        /// <summary>
        /// Creates a square bitmatrix of natural order from a span
        /// </summary>
        /// <param name="data">The data source</param>
        /// <param name="n">The order representative</param>
        /// <typeparam name="N">The column count type</typeparam>
        /// <typeparam name="T">The order type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<N,T> natural<N,T>(Span<T> data, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitMatrix<N, T>(data);

        /// <summary>
        /// Creates a bitmatrix of natural dimensions from a single cell
        /// </summary>
        /// <param name="data">The data cell</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The column count representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The column count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<M,N,T> natural<M,N,T>(T data, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitMatrix<M,N,T>(data);

        /// <summary>
        /// Creates a bitmatrix of natural dimensions from a span
        /// </summary>
        /// <param name="data">The data source</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The column count representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The column count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<M,N,T> natural<M,N,T>(Span<T> data, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitMatrix<M,N,T>(data);


    }
}