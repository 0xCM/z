//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = Heaps;

    public ref struct MemoryHeap
    {
        public readonly MemoryAddress Base;

        internal readonly Span<byte> Data;

        readonly Span<Address32> Offsets;

        public readonly uint EntryCount;

        [MethodImpl(Inline)]
        public MemoryHeap(MemoryAddress @base, Span<byte> data, Span<Address32> offsets)
        {
            Base = @base;
            Data = data;
            Offsets = offsets;
            EntryCount = (uint)offsets.Length;
       }

        [MethodImpl(Inline)]
        public MemoryAddress Address(uint index)
            => Base + Offset(index);

        [MethodImpl(Inline)]
        public MemoryAddress Address(ByteSize size)
            => Base + size;

        [MethodImpl(Inline)]
        public ref Address32 Offset(uint index)
            => ref seek(Offsets, index);

        [MethodImpl(Inline)]
        public ref Address32 Offset(int index)
            => ref seek(Offsets, index);

        [MethodImpl(Inline)]
        public ref byte Cell(Address32 offset)
            => ref seek(Data,(uint)offset);

        [MethodImpl(Inline)]
        public Span<byte> Segment(Address32 offset, uint size)
            => Algs.cover(Cell(offset),size);

        [MethodImpl(Inline)]
        public Span<byte> Entry(uint index)
            => api.entry<byte>(this,index);

        [MethodImpl(Inline)]
        public Span<T> Entry<T>(uint index)
            where T : unmanaged
                => api.entry<T>(this, index);

        [MethodImpl(Inline)]
        public Span<T> Entry<T>(int index)
            where T : unmanaged
                => api.entry<T>(this, (uint)index);
    }

}