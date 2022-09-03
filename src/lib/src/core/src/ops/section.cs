//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static Span<T> section<T>(Span<T> src, uint i0, uint i1)
        {
            var count = i1 - i0 + 1;
            ref readonly var first = ref skip(src, (uint)i0);
            return CreateSpan(ref edit(first), (int)count);
        }

        [MethodImpl(Inline)]
        public static Span<T> section<S,T>(Span<S> src, uint i0, uint i1)
        {
            var count = i1 - i0 + 1;
            ref readonly var first = ref skip(src, (uint)i0);
            return recover<S,T>(CreateSpan(ref edit(first), (int)count));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ReadOnlySpan<T> section<T>(ReadOnlySpan<T> src, uint i0, uint i1)
        {
            var count = i1 - i0 + 1;
            ref readonly var first = ref skip(src, (uint)i0);
            return CreateReadOnlySpan(ref edit(first), (int)count);
        }

        [MethodImpl(Inline)]
        public static ReadOnlySpan<T> section<S,T>(ReadOnlySpan<S> src, uint i0, uint i1)
        {
            var count = i1 - i0 + 1;
            ref readonly var first = ref skip(src, (uint)i0);
            return recover<S,T>(CreateReadOnlySpan(ref edit(first), (int)count));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ReadOnlySpan<T> section<T>(T* pSrc, uint i0, uint i1)
            where T : unmanaged
        {
            var count = i1 - i0 + 1;
            var pFirst = Add<T>(pSrc, (int)count);
            ref var first = ref AsRef<T>(pFirst);
            return CreateReadOnlySpan<T>(ref first, (int)count);
        }
    }
}