//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitMatrixA
    {
        /// <summary>
        /// Allocates a 1-filled generic bitmatrix
        /// </summary>
        /// <typeparam name="T">The matrix primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<T> ones<T>()
            where T : unmanaged
                => BitMatrix.init<T>(ScalarBits.ones<T>());

        /// <summary>
        /// Allocates a 0-filled generic bitmatrix
        /// </summary>
        /// <typeparam name="T">The matrix primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<T> zero<T>()
            where T : unmanaged
                => BitMatrix.alloc<T>();

        /// <summary>
        /// Allocates a generic identity matrix
        /// </summary>
        /// <typeparam name="T">The matrix primal type</typeparam>
        public static BitMatrix<T> identity<T>()
            where T : unmanaged
        {
            var dst = zero<T>();
            var len = width<T>();
            var one = core.one<T>();
            for(var i=0; i < len; i++)
                dst[i] = gmath.sll(one,(byte)i);
            return dst;
        }

        /// <summary>
        /// Allocates an identity bitmatrix of natural order
        /// </summary>
        /// <typeparam name="N">The column/row dimension</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        public static BitMatrix<N,T> identity<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
       {
            var dst = BitMatrix.alloc(n, t);
            var order  = (int)nat64u(n);
            for(var i = 0; i<order; i++)
                dst[i,i] = true;
            return dst;
        }

        /// <summary>
        /// Allocates a 1-filled natural bitmatrix
        /// </summary>
        /// <typeparam name="M">The row dimension</typeparam>
        /// <typeparam name="N">The column dimension</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<M,N,T> ones<M,N,T>(M m = default, N n = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitMatrix.init(Limits.maxval<T>(),m,n);

        /// <summary>
        /// Allocates a 1-filled bitmatrix of natural order
        /// </summary>
        /// <typeparam name="M">The row dimension</typeparam>
        /// <typeparam name="N">The column dimension</typeparam>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<N,T> ones<N,T>(N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitMatrix.init(Limits.maxval<T>(),n);
    }
}