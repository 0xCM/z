//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial class Heaps
    {
        [MethodImpl(Inline)]
        public static Span<T> cells<T>(in MemoryHeap src)
            where T : unmanaged
                => recover<T>(src.Data);
    }
}