//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout, Pack=1)]
    public readonly struct GridMetrics
    {
        /// <summary>
        /// The number of rows in the layout
        /// </summary>
        public readonly ushort RowCount;

        /// <summary>
        /// The number of columns in the layout
        /// </summary>
        public readonly ushort ColCount;

        /// <summary>
        /// The number of bits in a segment
        /// </summary>
        public readonly ushort CellWidth;

        /// <summary>
        /// The number of segment-aligned storage segments
        /// </summary>
        public readonly uint CellCount;

        /// <summary>
        /// The number of segment-aligned bits required for storage
        /// </summary>
        public readonly uint StoreWidth;

        /// <summary>
        /// The number of segment-aligned bytes bits required for storage
        /// </summary>
        public readonly uint StoreSize;

        [MethodImpl(Inline)]
        public GridMetrics(in GridSpec spec)
        {
            RowCount = spec.RowCount;
            ColCount = spec.ColCount;
            CellWidth = spec.CellWidth;
            StoreWidth = spec.StoreWidth;
            StoreSize = spec.StoreSize;
            CellCount = spec.CellCount;
        }

        /// <summary>
        /// Computes the 0-based linear index determined by a row/col coordinate
        /// </summary>
        /// <param name="row">The 0-based row index</param>
        /// <param name="col">The 0-based col index</param>
        [MethodImpl(Inline)]
        public int Position(int row, int col)
            => row*ColCount + col;

        /// <summary>
        /// Computes the 0-based linear index determined by a row/col coordinate
        /// </summary>
        /// <param name="row">The 0-based row index</param>
        /// <param name="col">The 0-based col index</param>
        public int this[int row, int col]
        {
            [MethodImpl(Inline)]
            get => Position(row,col);
        }

        public string Format()
            => EmptyString;

        public GridStats Stats
        {
            [MethodImpl(Inline)]
            get => throw new NotImplementedException();
            //grids.stats(this);
        }

        public GridDim Dim
        {
            [MethodImpl(Inline)]
            get => new GridDim(RowCount, ColCount);
        }
    }
}