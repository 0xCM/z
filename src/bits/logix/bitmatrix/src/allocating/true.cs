//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMatrixA
    {
        [MethodImpl(Inline), True, NumericClosures(UnsignedInts)]
        public static BitMatrix<T> @true<T>()
            where T:unmanaged
                => ones<T>();

        [MethodImpl(Inline), True, NumericClosures(UnsignedInts)]
        public static BitMatrix<T> @true<T>(BitMatrix<T> A)
            where T:unmanaged
                => @true<T>();

        [MethodImpl(Inline), True, NumericClosures(UnsignedInts)]
        public static BitMatrix<T> @true<T>(BitMatrix<T> A, BitMatrix<T> B)
            where T:unmanaged
                => @true<T>();
    }
}