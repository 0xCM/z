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
        /// Determines whether two generic bitmatrices are identical, returning an enabled bit if so and a disabled bit otherwise
        /// </summary>
        /// <param name="a">The left matrix</param>
        /// <param name="b">The right matrix</param>
        /// <typeparam name="T">The primal type over which the matrices are constructed</typeparam>
        [MethodImpl(Inline)]
        public static bit same<T>(in BitMatrix<T> a, in BitMatrix<T> b)
            where T : unmanaged
        {
            var Z = BitMatrix.alloc<T>();
            vlogic.xnor(a.Head, b.Head, ref Z.Head);
            return vlogic.testc(in Z.Head);
        }

        /// <summary>
        /// Determines whether two primal bitmatrices are identical, returning an enabled bit if so and a disabled bit otherwise
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline)]
        public static bit same(BitMatrix4 A, BitMatrix4 B)
            => (ushort)A == (ushort)B;

        /// <summary>
        /// Determines whether two primal bitmatrices are identical, returning an enabled bit if so and a disabled bit otherwise
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline)]
        public static bit same(in BitMatrix8 A, in BitMatrix8 B)
        {
            var Z = BitMatrix.alloc(n8);
            vlogic.xnor(in A.Head, in B.Head, ref Z.Head);
            return vlogic.testc(in Z.Head);
        }

        /// <summary>
        /// Determines whether two primal bitmatrices are identical, returning an enabled bit if so and a disabled bit otherwise
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline)]
        public static bit same(in BitMatrix16 A, in BitMatrix16 B)
        {
            var Z = BitMatrix.alloc(n16);
            vlogic.xnor(in A.Head, in B.Head, ref Z.Head);
            return vlogic.testc(in Z.Head);
        }

        /// <summary>
        /// Determines whether two primal bitmatrices are identical, returning an enabled bit if so and a disabled bit otherwise
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline)]
        public static bit same(in BitMatrix32 A, in BitMatrix32 B)
        {
            var Z = BitMatrix.alloc(n32);
            vlogic.xnor(in A.Head, in B.Head, ref Z.Head);
            return vlogic.testc(in Z.Head);
        }

        /// <summary>
        /// Determines whether two primal bitmatrices are identical, returning an enabled bit if so and a disabled bit otherwise
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline)]
        public static bit same(in BitMatrix64 A, in BitMatrix64 B)
        {
            var Z = BitMatrix.alloc(n64);
            vlogic.xnor(in A.Head, in B.Head, ref Z.Head);
            return vlogic.testc(in Z.Head);
        }
    }
}