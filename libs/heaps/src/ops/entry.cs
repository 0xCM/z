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
        public static Span<T> entry<T>(in MemoryHeap src, uint index)
            where T : unmanaged
        {
            if(index > src.EntryCount - 1)
                return Span<T>.Empty;
            ref readonly var i0 = ref src.Offset(index);
            if(index < src.EntryCount - 1)
                return slice(cells<T>(src), (uint)i0, (uint)(src.Offset(index + 1) - i0));
            else
                return slice(cells<T>(src), (uint)i0);
        }

        [MethodImpl(Inline), Op]
        public static HeapEntry entry(uint index, uint offset, uint length)
            => new HeapEntry(index, offset, length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HeapEntry<K> entry<K>(K index, uint offset, uint length)
            where K : unmanaged
                => new HeapEntry<K>(index, offset, length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HeapEntry<K,L> entry<K,L>(K index, uint offset, L length)
            where K : unmanaged
            where L : unmanaged
                => new HeapEntry<K,L>(index, offset, length);

        [MethodImpl(Inline)]
        public static HeapEntry<K,V,L> entry<K,V,L>(K index, V offset, L length)
            where K : unmanaged
            where V : unmanaged
            where L : unmanaged
                => new HeapEntry<K,V,L>(index, offset, length);
    }
}