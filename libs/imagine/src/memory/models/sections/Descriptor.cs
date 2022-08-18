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
        public readonly struct Descriptor
        {
            /// <summary>
            /// A 0-based surrogate key
            /// </summary>
            public readonly ushort Index;

            /// <summary>
            /// The first address covered by the section
            /// </summary>
            public readonly MemoryAddress BaseAddress;

            /// <summary>
            /// The capacity specifier
            /// </summary>
            public readonly Capacity Capacity;

            [MethodImpl(Inline)]
            public Descriptor(ushort id, MemoryAddress @base, Capacity capacity)
            {
                Index = id;
                BaseAddress = @base;
                Capacity = capacity;
            }

            /// <summary>
            /// The number of blocks covered by the allocation
            /// </summary>
            public uint BlockCount
            {
                [MethodImpl(Inline)]
                get => Capacity.BlockCount;
            }

            /// <summary>
            /// The factor by which to scale the segment to determine the block size
            /// </summary>
            public byte SegScale
            {
                [MethodImpl(Inline)]
                get => Capacity.SegsPerBlock;
            }

            /// <summary>
            /// The number of bytes covered by a segment
            /// </summary>
            public ByteSize SegSize
            {
                [MethodImpl(Inline)]
                get => Capacity.SegSize;
            }

            /// <summary>
            /// The size of a block, as determined by <see cref='SegSize'/> * <see cref='SegScale'/>
            /// </summary>
            public ByteSize BlockSize
            {
                [MethodImpl(Inline)]
                get => Capacity.BlockSize;
            }

            public ByteSize TotalSize
            {
                [MethodImpl(Inline)]
                get => Capacity.TotalSize;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Capacity.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Capacity.IsNonEmpty;
            }

            public MemoryRange AddressRange
            {
                [MethodImpl(Inline)]
                get => new MemoryRange(BaseAddress, TotalSize);
            }

            /// <summary>
            /// The last address covered by the section
            /// </summary>
            public MemoryAddress EndAddress
            {
                [MethodImpl(Inline)]
                get => BaseAddress + TotalSize;
            }

            public string Format()
                => api.format(this);

            public override string ToString()
                => Format();
        }
    }
}