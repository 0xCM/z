//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MemoryCells<T>
        where T : unmanaged
    {
        readonly MemoryRange Range;

        [MethodImpl(Inline)]
        public MemoryCells(MemoryRange range)
        {
            Range = range;
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref Range.Min.Ref<T>();
        }

        public Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => sys.cover(First, CellCount);
        }

        public ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Edit;
        }

        public ref T this[long index]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(First,index);
        }

        public ref T this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(First,index);
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Range.ByteCount/sys.size<T>();
        }

        [MethodImpl(Inline)]
        public uint Copy(uint offset, uint cells, Span<T> dst)
            => core.copy(this, offset, cells, dst);
    }
}