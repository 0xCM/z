//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    using api = MemorySections;

    partial struct MemorySections
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct Capacity
        {
            /// <summary>
            /// The size of the smallest addressable unit
            /// </summary>
            public readonly ushort CellSize;

            /// <summary>
            /// The number of cells per segment
            /// </summary>
            public readonly uint CellsPerSeg;

            /// <summary>
            /// The number of bytes covered by a segment
            /// </summary>
            public readonly uint SegSize;

            /// <summary>
            /// The number of allocated segments
            /// </summary>
            public readonly uint SegCount;

            /// <summary>
            /// The number of segments per block
            /// </summary>
            public readonly byte SegsPerBlock;

            /// <summary>
            /// The number of blocks covered by the allocation
            /// </summary>
            public readonly uint BlockCount;

            /// <summary>
            /// The size of a block, as determined by <see cref='SegSize'/> * <see cref='SegsPerBlock'/>
            /// </summary>
            public readonly uint BlockSize;

            /// <summary>
            /// The total allocation size, as determined by <see cref='BlockCount'/> * <see cref='BlockSize'/>
            /// </summary>
            public readonly uint TotalSize;

            [MethodImpl(Inline)]
            public Capacity(ushort cellsize, uint blocks, byte segsperblock, uint cellsperseg)
            {
                CellSize = cellsize;
                BlockCount = blocks;
                SegsPerBlock = segsperblock;
                CellsPerSeg = cellsperseg;
                SegSize = cellsperseg*cellsize;
                BlockSize = SegSize*SegsPerBlock;
                TotalSize = BlockCount*BlockSize;
                SegCount = SegSize != 0 ? TotalSize/SegSize : 0;
            }

            public CapacityIndicator Indicator
            {
                [MethodImpl(Inline)]
                get => @as<Capacity,CapacityIndicator>(this);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => BlockCount == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => TotalSize != 0;
            }

            public string Format()
                => api.format(Indicator);

            public override string ToString()
                => Format();

            public static Capacity Empty => default;
        }
    }
}