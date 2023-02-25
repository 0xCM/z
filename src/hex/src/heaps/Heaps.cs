//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Heaps
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static MemoryHeap memory(MemoryAddress @base, Span<byte> data, Span<Address32> offsets)
            => new MemoryHeap(@base, data,offsets);

        [MethodImpl(Inline)]
        public static Span<T> cells<T>(in MemoryHeap src)
            where T : unmanaged
                => recover<T>(src.Data);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanHeap<T> create<T>(Span<T> src, ReadOnlySpan<uint> offsets)
            where T : unmanaged
                => new SpanHeap<T>(src, offsets);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlyHeap<T> create<T>(ReadOnlySpan<T> src, uint[] offsets)
            where T : unmanaged
            => new ReadOnlyHeap<T>(src, offsets);

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


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(in BinaryHeap src, uint index)
            where T : unmanaged
        {
            if(index > src.Capacity - 1)
                return Span<T>.Empty;
            ref readonly var i0 = ref src.Offset(index);
            if(index < src.Capacity - 1)
                return slice(src.Cells<T>(), i0, src.Offset(index + 1) - i0);
            else
                return slice(src.Cells<T>(), i0);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(in BinaryHeap<T> src, uint index)
            where T : unmanaged
        {
            if(index > src.Capacity - 1)
                return Span<T>.Empty;
            ref readonly var i0 = ref src.Offset(index);
            if(index < src.Capacity - 1)
                return slice(src.Cells, i0, src.Offset(index + 1) - i0);
            else
                return slice(src.Cells, i0);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(in SpanHeap<T> src, uint index)
        {
            if(index > src.SegCount - 1)
                return Span<T>.Empty;
            ref readonly var i0 = ref skip(src.Offsets,index);
            if(index < src.LastSegment)
                return slice(src.Segments, i0, skip(src.Offsets,index + 1) - i0);
            else
                return slice(src.Segments, i0);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> segment<T>(in ReadOnlyHeap<T> src, uint index)
        {
            if(index > src.LastSegment + 1)
                return ReadOnlySpan<T>.Empty;
            ref readonly var i0 = ref skip(src.Offsets,index);
            if(index < src.LastSegment)
                return slice(src.Segments, i0, skip(src.Offsets,index + 1) - i0);
            else
                return slice(src.Segments, i0);
        }

        [MethodImpl(Inline)]
        internal static Span<T> segment<K,T>(Heap<K,T> src, K index)
            where K : unmanaged
        {
            var _index = bw32(index);
            var _next = @as<uint,K>(_index + 1);
            if(_index > src.LastSegment + 1)
                return Span<T>.Empty;
            var start = src.Offset(index);
            if(_index < src.LastSegment)
                return slice(src.Cells, start, src.Offset(_next) - start);
            else
                return slice(src.Cells, start);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static Span<T> segment<T>(Heap<T> src, uint index)
        {
            if(index > src.CellCount - 1)
                return Span<T>.Empty;
            ref readonly var i0 = ref src.Offset(index);
            if(index < src.CellCount - 1)
                return slice(src.Cells, i0, src.Offset(index + 1) - i0);
            else
                return slice(src.Cells, i0);
        }

        [MethodImpl(Inline)]
        public static ReadOnlySpan<byte> serialize<K,O,L>(in HeapEntry<K,O,L> src)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
                => bytes(src);

        [MethodImpl(Inline)]
        public static HeapEntry<K,O,L> convert<K,O,L>(ReadOnlySpan<byte> src, out HeapEntry<K,O,L> dst)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
        {
            dst = @as<HeapEntry<K,O,L>>(src);
            return dst;
        }
    }
}