//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMatrixA
    {
        /// <summary>
        /// Computes the converse implication for generic bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), CImpl, Closures(UnsignedInts)]
        public static BitMatrix<T> cimpl<T>(BitMatrix<T> A, BitMatrix<T> B)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.cimpl(A.Head, B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the converse implication for primal bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Impl]
        public static BitMatrix8 impl(BitMatrix8 A, BitMatrix8 B)
        {
            var Z = BitMatrix.alloc(n8);
            vlogic.impl(A.Head, B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the converse implication for primal bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Impl]
        public static BitMatrix16 impl(in BitMatrix16 A, in BitMatrix16 B)
        {
            var Z = BitMatrix.alloc(n16);
            vlogic.impl(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the converse implication for primal bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Impl]
        public static BitMatrix32 impl(in BitMatrix32 A, in BitMatrix32 B)
        {
            var Z = BitMatrix.alloc(n32);
            vlogic.impl(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the converse implication for primal bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Impl]
        public static BitMatrix64 impl(in BitMatrix64 A, in BitMatrix64 B)
        {
            var Z = BitMatrix.alloc(n64);
            vlogic.impl(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }
    }
}