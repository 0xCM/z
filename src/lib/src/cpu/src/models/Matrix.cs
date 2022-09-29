//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines the matrix api surface
    /// </summary>
    public static class Matrix
    {
        /// <summary>
        /// Loads a natural block from blocked storage
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="n">The length representative</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static NatSpan<N,T> natspan<N,T>(in SpanBlock256<T> src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => NatSpans.load(src.Storage,n);

        /// <summary>
        /// Allocates a memory span of specified length
        /// </summary>
        /// <param name="len">The data length</param>
        /// <param name="fill">An optional fill value</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        static T[] array<T>(int len, T? fill = default)
            where T : unmanaged
        {
            var dst = new T[len];
            if(fill != null)
                dst.AsSpan().Fill(fill.Value);
            return dst;
        }

        /// <summary>
        /// Allocates a square matrix of natual dimension
        /// </summary>
        /// <param name="n">The square dimension; specified, if desired, to aid type inference</param>
        /// <param name="fill">A value to which each cell is initialized</param>
        /// <typeparam name="N">The natural dimension type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix<N,T> alloc<N,T>(N n = default, T fill = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new Matrix<N, T>(
                    sys.alloc((int)(nat64u<N>()* nat64u<N>()), fill));

        /// <summary>
        /// Allocates a blocked square matrix of natual dimension
        /// </summary>
        /// <param name="n">The square dimension; specified, if desired, to aid type inference</param>
        /// <param name="t">An example value; specified, if desired, to aid type inference</param>
        /// <typeparam name="N">The natural dimension type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix256<N,T> blockalloc<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => SpanBlocks.alloc<T>(n256, nat64u(n), nat64u(n));

        /// <summary>
        /// Allocates a blocked matrix of natual dimensions
        /// </summary>
        /// <param name="m">The row count, specified if desired to aid type inference</param>
        /// <param name="n">The column count, specified if desired to aid type inference</param>
        /// <param name="t">An example value, specified if desired to aid type inference</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix256<M,N,T> blockalloc<M,N,T>(M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => SpanBlocks.alloc<T>(n256, nat64u(m), nat64u(n));

        /// <summary>
        /// Allocates a matrix of natual dimensions
        /// </summary>
        /// <param name="m">The row count, specified if desired to aid type inference</param>
        /// <param name="n">The column count, specified if desired to aid type inference</param>
        /// <param name="fill">A value to which each cell is initialized</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix<M,N,T> alloc<M,N,T>(M m = default, N n = default, T fill = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new Matrix<M,N,T>(array<T>((int)(nat64u<M>() * nat64u<N>()),fill));

        /// <summary>
        /// Loads a matrix of natural dimensions from an array
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix<M,N,T> load<M,N,T>(T[] src, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new Matrix<M, N, T>(src);

        [MethodImpl(Inline)]
        public static Matrix<M,N,T> load<M,N,T>(Span<T> src, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new Matrix<M,N,T>(src.ToArray());

        /// <summary>
        /// Loads a matrix of natural dimensions from a blocked span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix256<M,N,T> blockload<M,N,T>(SpanBlock256<T> src, M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new Matrix256<M,N,T>(src);

        /// <summary>
        /// Loads a square matrix of natural dimensions from a blocked span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix256<N,T> blockload<N,T>(SpanBlock256<T> src,  N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new Matrix256<N, T>(src);

        [MethodImpl(Inline)]
        public static Matrix256<M,N,T> blockload<M,N,T>(Span<T> src,M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => SpanBlocks.safeload(n256,src);

        /// <summary>
        /// Defines a square matrix
        /// </summary>
        /// <param name="src">The source data </param>
        /// <param name="n">The order</param>
        /// <typeparam name="N">The square dimension type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix256<N,T> blockload<N,T>(T[] src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var dst = Matrix.blockalloc<N,T>();
            src.CopyTo(dst.Unblocked);
            return dst;
        }

        /// <summary>
        /// Defines a square matrix
        /// </summary>
        /// <param name="src">The source data </param>
        /// <param name="n">The order</param>
        /// <typeparam name="N">The square dimension type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix256<N,T> blockload<N,T>(N n, params T[] src )
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => blockload<N,T>(src,n);

        /// <summary>
        /// Loads a square matrix of natural order from an array
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col count type</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static Matrix<N,T> load<N,T>(N n, params T[] src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new Matrix<N, T>(src);

        public static ref Matrix<N,T> mul<N,T>(Matrix<N,T> A, Matrix<N,T> B, ref Matrix<N,T> C)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var tB = B.Transpose();
            for(var i=0; i<A.RowCount; i++)
            for(var j=0; j<B.ColCount; j++)
                C[i,j] = A[i] * tB[j];
            return ref C;
        }

        public static ref Matrix<M,N,T> mul<M,P,N,T>(Matrix<M,P,T> A, Matrix<P,N,T> B, ref Matrix<M,N,T> C)
            where M : unmanaged, ITypeNat
            where P : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var tB = B.Transpose();
            for(var i=0; i<A.RowCount; i++)
            for(var j=0; j<B.ColCount; j++)
                C[i,j] = A[i] * tB[j];
            return ref C;
        }

        public static void mul<M,K,N,T>(in Matrix256<M,K,T> A, in Matrix256<K,N,T> B, ref Matrix256<M,N,T> X)
            where M : unmanaged, ITypeNat
            where K : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var m = (int)nat64u<M>();
            var n = (int)nat64u<N>();
            var tB = B.Transpose();

            for(var i=0; i< m; i++)
            {
                var r = A.GetRow(i);
                for(var j = 0; j< n; j++)
                {
                    var c = tB.GetRow(j);
                    X[i,j] = r * c;
                }
            }
        }
   }
}