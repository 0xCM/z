//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Heaps
    {
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
    }
}