//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// void _mm_prefetch(char* p, int i) PREFETCHT0 m8
        /// </summary>
        /// <param name="pSrc"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void prefectch(N0 n, void* pSrc)
            => Prefetch0(pSrc);

        /// <summary>
        /// void _mm_prefetch(char* p, int i) PREFETCHT1 m8
        /// </summary>
        /// <param name="n"></param>
        /// <param name="pSrc"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void prefectch(N1 n, void* pSrc)
            => Prefetch1(pSrc);

        /// <summary>
        /// _mm_prefetch(char* p, int i) PREFETCHT2 m8
        /// </summary>
        /// <param name="n"></param>
        /// <param name="pSrc"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void prefectch(N2 n, void* pSrc)
            => Prefetch2(pSrc);

        /// <summary>
        /// void _mm_prefetch(char* p, int i) PREFETCHNTA m8
        /// </summary>
        /// <param name="pSrc"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void prefectch(void* pSrc)
            => PrefetchNonTemporal(pSrc);
    }
}