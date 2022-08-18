//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        [MethodImpl(Inline)]
        public static ref readonly T kskip<K,T>(T[] src, K count)
            where K : unmanaged
                => ref skip(src, bw64(count));

        [MethodImpl(Inline)]
        public static ref readonly T kskip<K,T>(ReadOnlySpan<T> src, K count)
            where K : unmanaged
                => ref skip(src, bw64(count));

        [MethodImpl(Inline)]
        public unsafe static ref readonly T kskip<K,T>(T* pSrc, K count)
            where T : unmanaged
            where K : unmanaged
                => ref skip(pSrc, bw64(count));

        [MethodImpl(Inline)]
        public static ref readonly T kskip<K,T>(in T src, K count)
            where K : unmanaged
                => ref skip(src, bw64(count));
    }
}