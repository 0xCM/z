//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct MemorySections
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct CapacityIndicator
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

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}