//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline)]
        public static ref T kseek<K,T>(T[] src, K count)
            where K : unmanaged
                => ref seek(src, bw64(count));

        [MethodImpl(Inline)]
        public static ref T kseek<K,T>(Span<T> src, K count)
            where K : unmanaged
                => ref seek(src, bw64(count));

        [MethodImpl(Inline)]
        public unsafe static ref T kseek<K,T>(T* pSrc, K count)
            where T : unmanaged
            where K : unmanaged
                => ref seek(pSrc, bw64(count));

        [MethodImpl(Inline)]
        public static ref T kseek<K,T>(in T src, K count)
            where K : unmanaged
                => ref seek(src, bw64(count));
    }
}