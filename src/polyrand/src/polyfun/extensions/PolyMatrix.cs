//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the matrix api surface
    /// </summary>
    public static class PolyMatrix
    {
        /// <summary>
        /// Allocates and fills a matrix of natural dimensions with random values
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="domain">The range of potential random values</param>
        /// <param name="m">The natural number of rows</param>
        /// <param name="n">The natural number of columns</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The column Type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix<M,N,T> Matrix<M,N,T>(this ISource random, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Z0.Matrix.load<M,N,T>(random.Array<T>(Z0.Matrix<M,N,T>.Cells));

        /// <summary>
        /// Allocates and fills a matrix of natural dimensions with random values
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="domain">The range of potential random values</param>
        /// <param name="m">The natural number of rows</param>
        /// <param name="n">The natural number of columns</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The column Type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix<M,N,T> Matrix<M,N,T>(this IBoundSource random, Interval<T> domain, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Z0.Matrix.load<M,N,T>(random.Array<T>(Z0.Matrix<M,N,T>.Cells, domain));

        /// <summary>
        /// Samples a square matrix of natural order
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="min">The min random value</param>
        /// <param name="max">The max random value</param>
        /// <param name="transformer">The max random value</param>
        /// <typeparam name="N">The dimension type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix<N,T> Matrix<N,T>(this IBoundSource random, N n, T min, T max)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Z0.Matrix.load(n, random.Array<T>(Z0.Matrix<N,T>.Cells, (min,max)));

        /// <summary>
        /// Samples a blocked matrix of natural dimensions where the entries are constrained to a specified domain
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="m">The number of matrix rows</param>
        /// <param name="n">The number of matrix columns</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The column Type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
         public static Matrix256<M,N,T> MatrixBlock<M,N,T>(this ISource random)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Z0.Matrix.blockload<M,N,T>(random.SpanBlocks<T>(n256, CellCalcs.blockcount<M,N,T>(n256)));

        /// <summary>
        /// Samples a blocked matrix of natural dimensions where the entries are constrained to a specified domain
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="domain">The domain to which the entry values are constrained</param>
        /// <param name="m">The number of matrix rows</param>
        /// <param name="n">The number of matrix columns</param>
        /// <typeparam name="M">The row type</typeparam>
        /// <typeparam name="N">The column Type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        public static Matrix256<M,N,T> MatrixBlock<M,N,T>(this IBoundSource random, Interval<T> domain, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => Z0.Matrix.blockload<M,N,T>(random.SpanBlocks(n256, domain, CellCalcs.blockcount<M,N,T>(n256)));

        /// <summary>
        /// Samples a square matrix of natural order
        /// </summary>
        /// <param name="random">The random source</param>
        /// <typeparam name="N">The dimension type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
         public static Matrix256<N,T> MatrixBlock<N,T>(this IBoundSource random, Interval<T>? domain = null)
            where N : unmanaged, ITypeNat
            where T : unmanaged, IEquatable<T>
                => Z0.Matrix.blockload<N,T>(random.SpanBlocks(n256, domain.ValueOrElse(() => ClosedInterval<T>.Full), CellCalcs.blockcount<N,N,T>(n256)));

         /// <summary>
         /// Samples values over an S-domain, transforms the sample into a T-domain and from this transformed
         /// sample constructs a matrix of natural dimensions
         /// </summary>
         /// <param name="random">The random source</param>
         /// <param name="domain">The sample domain</param>
         /// <param name="m">The row count</param>
         /// <param name="n">The column count</param>
         /// <param name="rep">A scalar representative</param>
         /// <typeparam name="M">The row type</typeparam>
         /// <typeparam name="N">The column type</typeparam>
         /// <typeparam name="S">The sample type</typeparam>
         /// <typeparam name="T">The matrix element type</typeparam>
          public static Matrix256<M,N,T> MatrixBlock<M,N,S,T>(this ISource random, M m = default, N n = default,  T rep = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
            where S : unmanaged
                => random.MatrixBlock<M,N,S>().Convert<T>();

          static Matrix256<N,T> MatrixBlock<N,S,T>(this IBoundSource random, Interval<S>? domain = null, N n = default,  T rep = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
            where S : unmanaged, IEquatable<S>
                => random.MatrixBlock<N,S>(domain).Convert<T>();

         /// <summary>
         /// Samples 32-bit integers that are converted to 32-bit floats to populate a square matrix
         /// </summary>
         /// <param name="random">The random source</param>
         /// <param name="n">The matrix order</param>
         /// <param name="min">The minimum entry value</param>
         /// <param name="min">The maximum entry value</param>
         /// <typeparam name="N">The matrix order type</typeparam>
         /// <typeparam name="S">The sample type</typeparam>
         /// <typeparam name="T">The matrix element type</typeparam>
         [MethodImpl(Inline)]
         public static Matrix256<N,float> MatrixBlockF32<N,S,T>(this IBoundSource random, int? min = null, int? max = null, N n = default)
            where T : unmanaged
            where S : unmanaged
            where N : unmanaged, ITypeNat
                => random.MatrixBlock<N,int, float>(Intervals.closed(min ?? -25, max ?? 25));

        /// <summary>
        /// Samples 64-bit integers that are converted to 64-bit floats to populate a square matrix
        /// </summary>
        /// <param name="random">The random source</param>
        /// <param name="n">The matrix order</param>
        /// <param name="min">The minimum entry value</param>
        /// <param name="min">The maximum entry value</param>
        /// <typeparam name="N">The matrix order type</typeparam>
        /// <typeparam name="S">The sample type</typeparam>
        /// <typeparam name="T">The matrix element type</typeparam>
        [MethodImpl(Inline)]
        public static  Matrix256<N,double> MatrixBlockF64<N,S,T>(this IBoundSource random, long? min = null, long? max = null, N n = default)
            where T : unmanaged
            where S : unmanaged
            where N : unmanaged, ITypeNat
                => random.MatrixBlock<N,long, double>(Intervals.closed(min ?? -25L, max ?? 25L));
    }
}