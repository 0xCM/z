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
        [MethodImpl(Inline)]
        public static ref readonly BitMatrix<T> xornot<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
        {
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return ref Z;
        }

        [MethodImpl(Inline)]
        public static ref readonly BitMatrix8 xornot(in BitMatrix8 A, in BitMatrix8 B, ref BitMatrix8 Z)
        {
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return ref Z;
        }

        [MethodImpl(Inline)]
        public static BitMatrix8 xornot(in BitMatrix8 A, in BitMatrix8 B)
        {
            var Z = BitMatrix.alloc(n8);
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        [MethodImpl(Inline)]
        public static BitMatrix16 xornot(in BitMatrix16 A, in BitMatrix16 B)
        {
            var Z = BitMatrix.alloc(n16);
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        [MethodImpl(Inline)]
        public static ref readonly BitMatrix16 xornot(in BitMatrix16 A, in BitMatrix16 B, ref BitMatrix16 Z)
        {
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return ref Z;
        }

        [MethodImpl(Inline)]
        public static BitMatrix32 xornot(in BitMatrix32 A, in BitMatrix32 B)
        {
            var Z = BitMatrix.alloc(n32);
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        [MethodImpl(Inline)]
        public static ref readonly BitMatrix32 xornot(in BitMatrix32 A, in BitMatrix32 B, ref BitMatrix32 Z)
        {
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return ref Z;
        }

         [MethodImpl(Inline)]
        public static BitMatrix64 xornot(in BitMatrix64 A, in BitMatrix64 B)
        {
            var Z = BitMatrix.alloc(n64);
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return Z;
        }

        [MethodImpl(Inline)]
        public static ref readonly BitMatrix64 xornot(in BitMatrix64 A, in BitMatrix64 B, ref BitMatrix64 Z)
        {
            vlogic.xornot(in A.Head, in B.Head, ref Z.Head);
            return ref Z;
        }
   }
}