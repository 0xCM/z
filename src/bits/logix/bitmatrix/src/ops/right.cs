//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMatrix
    {
        [MethodImpl(Inline), RProject, Closures(Closure)]
        public static BitMatrix<T> right<T>(in BitMatrix<T> A, in BitMatrix<T> B)
            where T : unmanaged
                => B;

        [MethodImpl(Inline), RProject, Closures(Closure)]
        public static BitMatrix<T> right<T>(in BitMatrix<T> A, in BitMatrix<T> B, in BitMatrix<T> Z)
            where T : unmanaged
        {
            Z.Update(B);
            return Z;
        }
    }
}