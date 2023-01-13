//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Heaps
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanHeap<T> create<T>(Span<T> src, ReadOnlySpan<uint> offsets)
            => new SpanHeap<T>(src, offsets);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlyHeap<T> create<T>(ReadOnlySpan<T> src, uint[] offsets)
            => new ReadOnlyHeap<T>(src, offsets);
   }
}