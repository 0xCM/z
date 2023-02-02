//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMatrix
    {
        /// <summary>
        /// Computes the logical negation of a generic bitmatrix, returning the allocated result to the caller
        /// </summary>
        /// <param name="a">The source matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Not, Closures(Closure)]
        public static BitMatrix<T> not<T>(BitMatrix<T> a)
            where T : unmanaged
                => BitMatrixA.not(a);

        /// <summary>
        /// Computes the logical negation of a generic bitmatrix, depositing the result to the caller-supplied target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <param name="Z">The target matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Not, Closures(Closure)]
        public static ref readonly BitMatrix<T> not<T>(in BitMatrix<T> A, in BitMatrix<T> Z)
            where T : unmanaged
        {
            vlogic.not(in A.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the logical negation of the source matrix, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Not]
        public static BitMatrix4 not(in BitMatrix4 A)
            => math.not((ushort)A);

        /// <summary>
        /// Computes the logical negation of a primal bitmatrix, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Not]
        public static BitMatrix8 not(in BitMatrix8 A)
        {
            var Z = BitMatrix.alloc(n8);
            vlogic.not(in A.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical negation of a primal bitmatrix, depositing the result to the caller-supplied target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Not]
        public static ref BitMatrix8 not(in BitMatrix8 A, ref BitMatrix8 Z)
        {
            vlogic.not(in A.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the logical negation of a primal bitmatrix, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Not]
        public static BitMatrix16 not(in BitMatrix16 A)
        {
            var Z = BitMatrix.alloc(n16);
            vlogic.not(in A.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical negation of a primal bitmatrix, depositing the result to the caller-supplied target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Not]
        public static ref BitMatrix16 not(in BitMatrix16 A, ref BitMatrix16 Z)
        {
            vlogic.not(in A.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the logical negation of a primal bitmatrix, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Not]
        public static BitMatrix32 not(in BitMatrix32 A)
        {
            var Z = BitMatrix.alloc(n32);
            vlogic.not(in A.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical negation of a primal bitmatrix, depositing the result to the caller-supplied target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Not]
        public static ref BitMatrix32 not(in BitMatrix32 A, ref BitMatrix32 Z)
        {
            vlogic.not(in A.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the logical negation of a primal bitmatrix, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The source matrix</param>
        [MethodImpl(Inline), Not]
        public static BitMatrix64 not(BitMatrix64 A)
        {
            var Z = BitMatrix.alloc(n64);
            vlogic.not(A.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical negation of a primal bitmatrix, depositing the result to the caller-supplied target
        /// </summary>
        /// <param name="A">The source matrix</param>
        /// <param name="Z">The target matrix</param>
        [MethodImpl(Inline), Not]
        public static ref BitMatrix64 not(BitMatrix64 A, ref BitMatrix64 Z)
        {
            vlogic.not(A.Head, ref Z.Head);
            return ref Z;
        }
    }
}