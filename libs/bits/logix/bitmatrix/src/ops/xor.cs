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
        /// Computes the logical Xor between two generic bitmatrices, depositing the result to a caller-allocated target
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        /// <param name="Z">The target matrix</param>
        /// <typeparam name="T">The primal type over which the matrices are constructed</typeparam>
        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static ref readonly BitMatrix<T> xor<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
        {
            vlogic.xor(in A.Head,in B.Head, ref Z.Head);
            return ref Z;
        }

        [MethodImpl(Inline)]
        public static ref readonly BitMatrix<N,T> xor<N,T>(in BitMatrix<N,T> A, in BitMatrix<N,T> B, in BitMatrix<N,T> C)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            Calcs.xor(A.Content, B.Content, C.Content);
            return ref C;
        }

        /// <summary>
        /// Computes the logical Xor between two bitmatrices and returns the allocated result to the caller
        /// </summary>
        /// <param name="A">The left matrix</param>
        /// <param name="B">The right matrix</param>
        [MethodImpl(Inline), Xor]
        public static BitMatrix4 xor(in BitMatrix4 A, in BitMatrix4 B)
            => math.xor((ushort)A,(ushort)B);

        /// <summary>
        /// Computes the logical Xor btween two primal bitmatrices, depositing the result to a caller-allocated target
        /// </summary>
        /// <param name="a">The left matrix</param>
        /// <param name="b">The right matrix</param>
        /// <param name="dst">The target matrix</param>
        [MethodImpl(Inline), Xor]
        public static ref readonly BitMatrix8 xor(in BitMatrix8 a, in BitMatrix8 b, in BitMatrix8 dst)
        {
            vlogic.xor(a.Head, b.Head, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Computes the logical Xor btween two primal bitmatrices, depositing the result to a caller-allocated target
        /// </summary>
        /// <param name="a">The left matrix</param>
        /// <param name="b">The right matrix</param>
        /// <param name="dst">The target matrix</param>
        [MethodImpl(Inline), Xor]
        public static ref readonly BitMatrix16 xor(in BitMatrix16 a, in BitMatrix16 b, in BitMatrix16 dst)
        {
            vlogic.xor(a.Head, b.Head, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Computes the logical Xor btween two primal bitmatrices, depositing the result to a caller-allocated target
        /// </summary>
        /// <param name="a">The left matrix</param>
        /// <param name="b">The right matrix</param>
        /// <param name="dst">The target matrix</param>
        [MethodImpl(Inline), Xor]
        public static ref readonly BitMatrix32 xor(in BitMatrix32 a, in BitMatrix32 b, in BitMatrix32 dst)
        {
            vlogic.xor(a.Head, b.Head, ref dst.Head);
            return ref dst;
        }

        /// <summary>
        /// Computes the logical Xor btween two primal bitmatrices, depositing the result to a caller-allocated target
        /// </summary>
        /// <param name="a">The left matrix</param>
        /// <param name="b">The right matrix</param>
        /// <param name="dst">The target matrix</param>
        [MethodImpl(Inline), Xor]
        public static ref readonly BitMatrix64 xor(in BitMatrix64 a, in BitMatrix64 b, in BitMatrix64 dst)
        {
            vlogic.xor(a.Head, b.Head, ref dst.Head);
            return ref dst;
        }
    }
}