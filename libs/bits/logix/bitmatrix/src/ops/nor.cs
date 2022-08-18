//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using BL = math;

    partial class BitMatrix
    {
        /// <summary>
        /// Computes the converse implication for generic bitmatrices, depositing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="B">The target matrix</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static ref readonly BitMatrix<T> nor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
        {
            vlogic.nor(in A.Head, in B.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the converse implication for primal bitmatrices, depositing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="B">The target matrix</param>
        [MethodImpl(Inline), Nor]
        public static ref readonly BitMatrix8 nor(in BitMatrix8 A, in BitMatrix8 B, in BitMatrix8 Z)
        {
             vlogic.nor(in A.Head, in B.Head, ref Z.Head);
             return ref Z;
        }

        /// <summary>
        /// Computes the logical Nor between two bitmatrices and returns the allocated result to the caller
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Nor]
        public static BitMatrix4 nor(in BitMatrix4 A, in BitMatrix4 B)
        {
            var a = (ushort)A;
            var b = (ushort)B;
            return BL.nor(a,b);
        }

        /// <summary>
        /// Computes the logical Nor between two bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Nor]
        public static BitMatrix8 nor(in BitMatrix8 A, in BitMatrix8 B)
        {
            var Z = BitMatrix.alloc(n8);
            vlogic.nor(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical Nor between bitmatrices and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="B">The target matrix</param>
        [MethodImpl(Inline), Nor]
        public static ref readonly BitMatrix16 nor(in BitMatrix16 A, in BitMatrix16 B, in BitMatrix16 Z)
        {
            vlogic.nor(A.Head, B.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the logical Nor between two bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Nor]
        public static BitMatrix16 nor(in BitMatrix16 A, in BitMatrix16 B)
        {
            var Z = BitMatrix.alloc(n16);
            vlogic.nor(A.Head, B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the logical Nor between bitmatrices and deposits the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="B">The target matrix</param>
        [MethodImpl(Inline), Nor]
        public static ref readonly BitMatrix32 nor(in BitMatrix32 A, in BitMatrix32 B, in BitMatrix32 Z)
        {
            vlogic.nor(A.Head, B.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the converse implication for primal bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Nor]
        public static BitMatrix32 nor(in BitMatrix32 A, in BitMatrix32 B)
        {
            var Z = BitMatrix.alloc(n32);
            vlogic.nor(A.Head, B.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Computes the converse implication for primal bitmatrices, depositing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="B">The target matrix</param>
        [MethodImpl(Inline), Nor]
        public static ref readonly BitMatrix64 nor(in BitMatrix64 A, in BitMatrix64 B, in BitMatrix64 Z)
        {
            vlogic.nor(A.Head, B.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Computes the converse implication for primal bitmatrices, returning the allocated result
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Nor]
        public static BitMatrix64 nor(in BitMatrix64 A, in BitMatrix64 B)
        {
            var Z = BitMatrix.alloc(n64);
            vlogic.nor(A.Head, B.Head, ref Z.Head);
            return Z;
        }
    }
}