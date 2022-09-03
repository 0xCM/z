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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static T* pseek<T>(T* pSrc, long count)
            where T : unmanaged
                => gptr(seek(pSrc, count));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static T* pseek<T>(T* pSrc, ulong count)
            where T : unmanaged
                => gptr(seek(pSrc, count));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static T* pseek<T>(Span<T> src, long count)
            where T : unmanaged
                => gptr(seek(src, count));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static T* pseek<T>(Span<T> src, ulong count)
            where T : unmanaged
                => gptr(seek(src, count));

    }
}