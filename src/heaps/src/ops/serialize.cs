//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class Heaps
    {
        [MethodImpl(Inline)]
        public static ReadOnlySpan<byte> serialize<K,O,L>(in HeapEntry<K,O,L> src)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
                => bytes(src);
    }
}