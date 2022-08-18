//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitMatrixA
    {
        [MethodImpl(Inline), LNot, Closures(UnsignedInts)]
        public static BitMatrix<T> lnot<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => not(A);

        [MethodImpl(Inline), False, Closures(UnsignedInts)]
        public static BitMatrix<T> @false<T>()
            where T:unmanaged
                => BitMatrixA.zero<T>();

        [MethodImpl(Inline), False, Closures(UnsignedInts)]
        public static BitMatrix<T> @false<T>(in BitMatrix<T> A)
            where T:unmanaged
                => @false<T>();

        [MethodImpl(Inline), False, Closures(UnsignedInts)]
        public static BitMatrix<T> @false<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T:unmanaged
                => @false<T>();

        /// <summary>
        /// Computes the logical And between two generic bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <typeparam name="T">The primal type over which the matrices are constructed</typeparam>
        [MethodImpl(Inline), And, Closures(UnsignedInts)]
        public static BitMatrix<T> and<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.and(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the converse implication for generic bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Or, NumericClosures(UnsignedInts)]
        public static BitMatrix<T> or<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.or(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the converse implication for generic bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), NonImpl, Closures(UnsignedInts)]
        public static BitMatrix<T> nonimpl<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.nonimpl(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical negation of a generic bitmatrix, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Not, Closures(UnsignedInts)]
        public static BitMatrix<T> not<T>(in BitMatrix<T> A)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.not(in A.Head, ref Z.Head);
            return Z;
        }

        [MethodImpl(Inline)]
        public static BitMatrix<T> xornot<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        [MethodImpl(Inline), RNot, NumericClosures(UnsignedInts)]
        public static BitMatrix<T> rnot<T>(in BitMatrix<T> a, in BitMatrix<T> b)
            where T : unmanaged
                => BitMatrix.not(b);

        /// <summary>
        /// Computes the converse implication for generic bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitMatrix<T> cnonimpl<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.cnonimpl(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the bitwise AND between two square bitmatrices of common order
        /// </summary>
        /// <param name="A">The first source operand</param>
        /// <param name="B">The second source operand</param>
        /// <typeparam name="N">The matrix order</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<N,T> and<N,T>(in BitMatrix<N,T> A, in BitMatrix<N,T> B)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => BitMatrix.and(A, B, BitMatrix.alloc<N,T>());

        /// <summary>
        /// Computes the converse implication for generic bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Nor, Closures(UnsignedInts)]
        public static BitMatrix<T> nor<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.nor(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the converse implication for generic bitmatrices, depositing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="B">The target matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Nor, Closures(UnsignedInts)]
        public static ref readonly BitMatrix<T> nor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
        {
            vlogic.nor(in A.Head, in B.Head, ref Z.Head);
            return ref Z;
        }
    }
}