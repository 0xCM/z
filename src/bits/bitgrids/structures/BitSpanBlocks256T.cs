//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a grid of bits over a contiguous sequence of primal values stored in blocks of 256 bits
    /// </summary>
    /// <typeparam name="T">The grid cell type</typeparam>
    [IdentityProvider(typeof(BitGridIdentityProvider))]
    public readonly ref struct BitSpanBlocks256<T>
        where T : unmanaged
    {
        internal readonly SpanBlock256<T> Data;

        /// <summary>
        /// The number of grid rows
        /// </summary>
        public readonly int RowCount;

        /// <summary>
        /// The number of grid columns
        /// </summary>
        public readonly int ColCount;

        [MethodImpl(Inline)]
        internal BitSpanBlocks256(SpanBlock256<T> data, int rows, int cols)
        {
            Data = data;
            RowCount = rows;
            ColCount = cols;
        }

        public SpanBlock256<T> Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref T Head
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        /// <summary>
        /// The number of cells over which the grid is defined
        /// </summary>
        public int CellCount
        {
            [MethodImpl(Inline)]
            get => (int)(grids.gridcells<T>((uint)RowCount, (uint)ColCount));
        }

        /// <summary>
        /// The number of covered bits
        /// </summary>
        public int BitCount
        {
            [MethodImpl(Inline)]
            get => RowCount * ColCount;
        }

        public int BlockCount
        {
            [MethodImpl(Inline)]
            get => Data.BlockCount;
        }

        public bit this[int row, int col]
        {
            [MethodImpl(Inline)]
            get => BitGrid.readbit(ColCount, in Head, row, col);

            [MethodImpl(Inline)]
            set => BitGrid.setbit((uint)ColCount, (uint)row, (uint)col, value, ref Head);
        }

        [MethodImpl(Inline)]
        public void SetBit(uint index, bit state)
            => BitGrid.setbit(index, state, ref Head);

        [MethodImpl(Inline)]
        public bit ReadBit(int index)
            => BitGrid.readbit(in Head, index);

        /// <summary>
        /// Transfers 256-bit cpu vectors to/from blocked storage
        /// </summary>
        public Vector256<T> this[int block]
        {
            [MethodImpl(Inline)]
            get => BitGrid.vector(this, block);

            [MethodImpl(Inline)]
            set => BitGrid.store(value, this, block);
        }

        /// <summary>
        /// Reads/writes an index-identified grid cell
        /// </summary>
        /// <param name="index">The 0-based linear cell index</param>
        [MethodImpl(Inline)]
        public ref T Cell(int index)
            => ref Unsafe.Add(ref Head, index);

        /// <summary>
        /// Returns the 256-bit block corresponding to a block index
        /// </summary>
        /// <param name="block">The block index</param>
        [MethodImpl(Inline)]
        public Span<T> Block(int block)
            => Data.CellBlock(block);

        [MethodImpl(Inline)]
        public bool Equals(BitSpanBlocks256<T> rhs)
            => Data.Identical(rhs.Data);

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static bool operator ==(in BitSpanBlocks256<T> g1, in BitSpanBlocks256<T> g2)
            => g1.Equals(g2);

        [MethodImpl(Inline)]
        public static bool operator !=(in BitSpanBlocks256<T> g1, in BitSpanBlocks256<T> g2)
            => !g1.Equals(g2);
    }
}