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
        public readonly struct Section<T> : IMemorySection<Section<T>>
            where T : unmanaged, IMemorySection<T>
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
            public Span<S> Storage<S>()
                where S : unmanaged
                    => api.cells<S>(this);

            public string Format()
                => Descriptor().Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Section(Section<T> src)
                => new Section(src.Index, src.Base(), src.Capacity());

            [MethodImpl(Inline)]
            public static implicit operator Descriptor(Section<T> src)
                => src.Descriptor();
        }
    }
}