//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = MemorySections;

    partial struct MemorySections
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct Section : IMemorySection<Section>
        {
            readonly Descriptor _D;

            [MethodImpl(Inline)]
            internal Section(ushort id, MemoryAddress @base, Capacity capacity)
            {
                _D = new Descriptor(id, @base, capacity);
            }

            public ushort Index
            {
                [MethodImpl(Inline)]
                get => _D.Index;
            }

            public ByteSize SegSize
            {
                [MethodImpl(Inline)]
                get => _D.SegSize;
            }

            public byte SegScale
            {
                [MethodImpl(Inline)]
                get => _D.SegScale;
            }

            public uint BlockCount
            {
                [MethodImpl(Inline)]
                get => _D.BlockCount;
            }

            public ByteSize BlockSize
            {
                [MethodImpl(Inline)]
                get => _D.BlockSize;
            }

            public ByteSize TotalSize
            {
                [MethodImpl(Inline)]
                get => _D.Capacity.TotalSize;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => _D.IsNonEmpty;
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => TotalSize;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => _D.IsEmpty;
            }

            [MethodImpl(Inline)]
            public MemoryAddress Base()
                => _D.BaseAddress;

            [MethodImpl(Inline)]
            public Capacity Capacity()
                => _D.Capacity;

            [MethodImpl(Inline)]
            public Descriptor Descriptor()
                => api.descriptor(this);

            [MethodImpl(Inline)]
            public Span<byte> Storage()
                => api.cells(this);

            [MethodImpl(Inline)]
            public Span<byte> Segment(uint index)
                => api.segment(this, index);

            [MethodImpl(Inline)]
            public Span<S> Storage<S>()
                where S : unmanaged
                    => api.cells<S>(this);

            public string Format()
                => Descriptor().Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Descriptor(Section src)
                => src.Descriptor();
        }
    }
}