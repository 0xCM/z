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
        /// <summary>
        /// Applies the ternary select operator to generic source matrices, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        /// <typeparam name="T">The primal type over which the matrices are constructed</typeparam>
        [MethodImpl(Inline), Select, Closures(UnsignedInts)]
        public static BitMatrix<T> select<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> C)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Applies the ternary select operator to primal source matrices, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        [MethodImpl(Inline), Select]
        public static BitMatrix8 select(in BitMatrix8 A, in BitMatrix8 B, in BitMatrix8 C)
        {
            var Z = BitMatrix.alloc(n8);
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Applies the ternary select operator to primal source matrices, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        [MethodImpl(Inline), Select]
        public static BitMatrix16 select(in BitMatrix16 A, in BitMatrix16 B, in BitMatrix16 C)
        {
            var Z = BitMatrix.alloc(n16);
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Applies the ternary select operator to primal source matrices, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        [MethodImpl(Inline), Select]
        public static BitMatrix32 select(in BitMatrix32 A, in BitMatrix32 B, in BitMatrix32 C)
        {
            var Z = BitMatrix.alloc(n32);
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return Z;
        }

        /// <summary>
        /// Applies the ternary select operator to primal source matrices, returning the allocated result to the caller
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        [MethodImpl(Inline), Select]
        public static BitMatrix64 select(in BitMatrix64 A, in BitMatrix64 B, in BitMatrix64 C)
        {
            var Z = BitMatrix.alloc(n64);
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return Z;
        }
    }
}