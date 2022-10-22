//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitMatrix
    {
        /// <summary>
        /// Computes the logical And between two generic bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <typeparam name="T">The primal type over which the matrices are constructed</typeparam>
        [MethodImpl(Inline), And, Closures(Closure)]
        public static BitMatrix<T> and<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => BitMatrixA.and(A,B);

        /// <summary>
        /// Computes the logical and and between two generic bitmatrices, depositing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="dst">The target matrix</param>
        /// <typeparam name="T">The primal type over which the matrices are constructed</typeparam>
        [MethodImpl(Inline), And, Closures(Closure)]
        public static ref readonly BitMatrix<T> and<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> dst)
            where T : unmanaged
        {
            vlogic.and(in A.Head, in B.Head, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Computes the bitwise AND between two square bitmatrices of common natural order and stores the
        /// result a caller-supplied target matrix
        /// </summary>
        /// <param name="A">The first source operand</param>
        /// <param name="B">The second source operand</param>
        /// <param name="C">The target</param>
        /// <typeparam name="N">The matrix order</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly BitMatrix<N,T> and<N,T>(in BitMatrix<N,T> A, in BitMatrix<N,T> B, in BitMatrix<N,T> C)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            Calcs.and(A.Content, B.Content, C.Content);
            return ref C;
        }

        /// <summary>
        /// Computes the logical And between two source bitmatrices and returns the allocated result to the caller
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), And]
        public static BitMatrix4 and(in BitMatrix4 A, in BitMatrix4 B)
            => BitMatrix4.From(math.and((ushort)A,(ushort)B));

        /// <summary>
        /// Computes the logical And between two source bitmatrices and returns the allocated result to the caller
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), And]
        public static BitMatrix8 and(in BitMatrix8 A, in BitMatrix8 B)
            => (BitMatrix8)(@u64(A) & u64(B));

        /// <summary>
        /// Computes the logical and btween two source bitmatrices and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="dst">The target matrix</param>
        [MethodImpl(Inline), And]
        public static ref readonly BitMatrix8 and(in BitMatrix8 A, in BitMatrix8 B, in BitMatrix8 dst)
        {
            vlogic.and(in A.Head, in B.Head, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Computes the logical And between two primal bitmatrices and returns the allocated result to the caller
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), And]
        public static BitMatrix16 and(in BitMatrix16 A, in BitMatrix16 B)
        {
            var Z = BitMatrix.alloc(n16);
            vlogic.and(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical And btween two source bitmatrices and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="dst">The target matrix</param>
        [MethodImpl(Inline), And]
        public static ref readonly BitMatrix16 and(in BitMatrix16 A, in BitMatrix16 B, in BitMatrix16 dst)
        {
            vlogic.and(in A.Head, in B.Head, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Computes the logical And between two primal bitmatrices and returns the allocated result to the caller
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), And]
        public static BitMatrix32 and(in BitMatrix32 A, in BitMatrix32 B)
        {
            var Z = BitMatrix.alloc(n32);
            vlogic.and(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical and btween two source bitmatrices and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), And]
        public static ref readonly BitMatrix32 and(in BitMatrix32 A, in BitMatrix32 B, in BitMatrix32 Z)
        {
            vlogic.and(in A.Head, in B.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the logical And between two priaml bitmatrices and returns the allocated result to the caller
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), And]
        public static BitMatrix64 and(in BitMatrix64 A, in BitMatrix64 B)
        {
            var Z = BitMatrix.alloc(n64);
            vlogic.and(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical and btween two source bitmatrices and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="dst">The target matrix</param>
        [MethodImpl(Inline), And]
        public static ref readonly BitMatrix64 and(in BitMatrix64 A, in BitMatrix64 B, in BitMatrix64 dst)
        {
            vlogic.and(in A.Head, in B.Head, ref dst.Head);
            return ref dst;
        }
    }
}