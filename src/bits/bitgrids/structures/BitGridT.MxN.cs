//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a maximally packed data structure of natural dimensions over a primal type
    /// </summary>
    public readonly ref struct BitGrid<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        internal readonly SpanBlock256<T> Data;

        [MethodImpl(Inline)]
        internal BitGrid(SpanBlock256<T> src)
            => Data = src;

        /// <summary>
        /// The allocated storage
        /// </summary>
        public SpanBlock256<T> Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// A reference to the leading storage cell
        /// </summary>
        public ref T Head
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        /// <summary>
        /// The number of grid rows
        /// </summary>
        public int RowCount => nat32i<M>();

        /// <summary>
        /// The number of grid columns
        /// </summary>
        public int ColCount => nat32i<N>();

        /// <summary>
        /// The number of allocated 256-bit blocks
        /// </summary>
        public int BlockCount
        {
            [MethodImpl(Inline)]
            get => Data.BlockCount;
        }

        /// <summary>
        /// The number of cells over which the grid is defined
        /// </summary>
        public int CellCount
        {
            [MethodImpl(Inline)]
            get => (int)grids.gridcells<M,N,T>();
        }

        /// <summary>
        /// The number of bits covered by the grid
        /// </summary>
        public int BitCount
        {
            [MethodImpl(Inline)]
            get => (int)NatCalc.mul<M,N>();
        }

        // public bit this[int row, int col]
        // {
        //     [MethodImpl(Inline)]
        //     get => BitGrid.readbit(ColCount, in Head, row, col);

        //     [MethodImpl(Inline)]
        //     set => BitGrid.setbit(ColCount, row, col, value, ref Head);
        // }

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

        [MethodImpl(Inline)]
        public void SetBit(uint index, bit state)
            => BitGrid.setbit(index, state, ref Head);

        [MethodImpl(Inline)]
        public bit ReadBit(int index)
            => BitGrid.readbit(in Head, index);

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
        public Span<T> SpanBlock(int block)
            => Data.CellBlock(block);

        [MethodImpl(Inline)]
        public bool Equals(BitGrid<M,N,T> rhs)
            => Content.Identical(rhs.Data);

        public override bool Equals(object obj)
            => throw new NotSupportedException();

        public override int GetHashCode()
            => throw new NotSupportedException();

        [MethodImpl(Inline)]
        public static bit operator ==(in BitGrid<M,N,T> g1, in BitGrid<M,N,T> g2)
            => BitGrid.same(g1,g2);

        [MethodImpl(Inline)]
        public static bit operator !=(in BitGrid<M,N,T> g1, in BitGrid<M,N,T> g2)
            => !BitGrid.same(g1,g2);
    }
}