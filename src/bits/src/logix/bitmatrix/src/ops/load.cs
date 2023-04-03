//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMatrix
    {
        /// <summary>
        /// Loads a generic bitmatrix from a span
        /// </summary>
        /// <param name="src">The row content</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitMatrix<T> load<T>(T[] src)
            where T : unmanaged
                => new BitMatrix<T>(src);

        /// <summary>
        /// Loads a generic bitmatrix from a span
        /// </summary>
        /// <param name="src">The row content</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitMatrix<T> load<T>(Span<T> src)
            where T : unmanaged
                => new BitMatrix<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitMatrix<T> load<T>(SpanBlock256<T> src)
            where T : unmanaged
                => new BitMatrix<T>(src);

        /// <summary>
        /// Loads a square bitmatrix of natural order from an span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="n">The matrix order</param>
        /// <typeparam name="N">The matrix order type</typeparam>
        /// <typeparam name="T">The matrix cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<N,T> load<N,T>(N n, Span<T> src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitMatrix<N,T>(src);

        /// <summary>
        /// Loads a square bitmatrix of natural order from an span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="N">The matrix order type</typeparam>
        /// <typeparam name="T">The matrix cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<N,T> load<N,T>(Span<T> src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitMatrix<N,T>(src);

        /// <summary>
        /// Loads an MxN natural bitmatrix from an array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="n">The matrix order</param>
        /// <typeparam name="N">The matrix order type</typeparam>
        /// <typeparam name="T">The matrix cell type</typeparam>
        public static BitMatrix<M,N,T> load<M,N,T>(M m, N n, Span<T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitMatrix<M,N,T>.Load(src);

        /// <summary>
        /// Loads an MxN natural bitmatrix from an array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="n">The matrix order</param>
        /// <typeparam name="N">The matrix order type</typeparam>
        /// <typeparam name="T">The matrix cell type</typeparam>
        public static BitMatrix<M,N,T> load<M,N,T>(Span<T> src)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitMatrix<M,N,T>.Load(src);
    }
}