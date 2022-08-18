//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitMatrix
    {
        /// <summary>
        /// Applies the ternary select operator to generic source matrices, writing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        /// <typeparam name="T">The primal type over which the matrices are constructed</typeparam>
        [MethodImpl(Inline), Select, Closures(UnsignedInts)]
        public static ref readonly BitMatrix<T> select<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> C, in BitMatrix<T> Z)
            where T : unmanaged
        {
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Applies the ternary select operator to primal source matrices, writing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        [MethodImpl(Inline), Select]
        public static ref readonly BitMatrix8 select(in BitMatrix8 A, in BitMatrix8 B, in BitMatrix8 C, in BitMatrix8 Z)
        {
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Applies the ternary select operator to primal source matrices, writing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        [MethodImpl(Inline), Select]
        public static ref readonly BitMatrix16 select(in BitMatrix16 A, in BitMatrix16 B, in BitMatrix16 C, in BitMatrix16 Z)
        {
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Applies the ternary select operator to primal source matrices, writing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        [MethodImpl(Inline), Select]
        public static ref readonly BitMatrix32 select(in BitMatrix32 A, in BitMatrix32 B, in BitMatrix32 C, in BitMatrix32 Z)
        {
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return ref Z;
        }

        /// <summary>
        /// Applies the ternary select operator to primal source matrices, writing the result to a caller-supplied target
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <param name="C">The third matrix</param>
        [MethodImpl(Inline), Select]
        public static ref readonly BitMatrix64 select(in BitMatrix64 A, in BitMatrix64 B, in BitMatrix64 C, in BitMatrix64 Z)
        {
            vlogic.select(in A.Head, in B.Head, in C.Head, ref Z.Head);
            return ref Z;
        }
    }
}