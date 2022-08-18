//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GridStats
    {
        public string Name;

        /// <summary>
        /// The number of grid rows
        /// </summary>
        public ushort RowCount;

        /// <summary>
        /// The number of grid columns
        /// </summary>
        public ushort ColCount;

        /// <summary>
        /// The number of bits in a storage segment
        /// </summary>
        public ushort SegWidth;

        /// <summary>
        /// The number of points covered by the grid
        /// </summary>
        public uint PointCount;

        /// <summary>
        /// The number of segment-aligned segments required for storage
        /// </summary>
        public uint SorageSegs;

        /// <summary>
        /// The number of segment-aligned bits required for storage
        /// </summary>
        public uint StorageBits;

        /// <summary>
        /// The number of segment-aligned bytes bits required for storage
        /// </summary>
        public uint StorageBytes;

        /// <summary>
        /// The number of whole 128-bit vectors required for storage
        /// </summary>
        public uint Vec128Count;

        /// <summary>
        /// The number bytes that do not fit into a whole number of 128-bit vectors
        /// </summary>
        public uint Vec128Remainder;

        /// <summary>
        /// The number of whole 256-bit vectors required for storage
        /// </summary>
        public uint Vec256Count;

        /// <summary>
        /// The number bytes that do not fit into a whole number of 256-bit vectors
        /// </summary>
        public uint Vec256Remainder;

        [MethodImpl(Inline)]
        public GridStats(ushort RowCount, ushort ColCount,  ushort SegWidth, uint PointCount,
            uint StorageSegs, uint StorageBits, uint StorageBytes, uint Vec128Count, uint Vec128Remainder, uint Vec256Count, uint Vec256Remainder)
        {
            this.Name = $"{RowCount}x{ColCount}";
            this.RowCount = RowCount;
            this.ColCount = ColCount;
            this.SegWidth = SegWidth;
            this.SorageSegs = StorageSegs;
            this.StorageBits = StorageBits;
            this.StorageBytes = StorageBytes;
            this.PointCount = PointCount;
            this.Vec128Count = Vec128Count;
            this.Vec128Remainder = Vec128Remainder;
            this.Vec256Count = Vec256Count;
            this.Vec256Remainder = Vec256Remainder;
        }
    }
}