//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMatrix
    {
        [MethodImpl(Inline), LProject, Closures(Closure)]
        public static BitMatrix<T> left<T>(BitMatrix<T> A, BitMatrix<T> B)
            where T : unmanaged
                => A;

        [MethodImpl(Inline), LProject, Closures(Closure)]
        public static BitMatrix<T> left<T>(BitMatrix<T> A, BitMatrix<T> B, BitMatrix<T> Z)
            where T : unmanaged
        {
            Z.Update(A);
            return Z;
        }
    }
}