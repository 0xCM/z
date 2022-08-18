//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a parametrically-predicated blocked grid
    /// </summary>
    public readonly struct GridDim<W,M,N,T>
        where W : unmanaged, IDataWidth
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The bit width of a block
        /// </summary>
        public int BlockWidth
        {
            [MethodImpl(Inline)]
            get => (int)DataWidths.measure<W>();
        }

        /// <summary>
        /// The number of grid rows
        /// </summary>
        public int RowCount
        {
            [MethodImpl(Inline)]
            get => nat32i<M>();
        }

        /// <summary>
        /// The number of grid columns
        /// </summary>
        public int ColCount
        {
            [MethodImpl(Inline)]
            get => nat32i<N>();
        }

        /// <summary>
        /// The bit width of a storage cell
        /// </summary>
        public int CellWidth
        {
            [MethodImpl(Inline)]
            get => (int)width<T>();
        }

        /// <summary>
        /// The total number of grid bits
        /// </summary>
        public int BitCount
        {
            [MethodImpl(Inline)]
            get => (int)NatCalc.mul<M,N>();
        }

        /// <summary>
        /// The number of cells required cover a grid
        /// </summary>
        public int CellCount
        {
            [MethodImpl(Inline)]
            get => (int)grids.gridcells<M,N,T>();
        }

        /// <summary>
        /// The number of bytes required to cover a grid
        /// </summary>
        public uint ByteCount
        {
            [MethodImpl(Inline)]
            get => CellCalcs.mincells<M,N,byte>();
        }

        /// <summary>
        /// Computes the aligned number of W-blocks required to cover M*N bits
        /// </summary>
        public int BlockCount
        {
            [MethodImpl(Inline)]
            get => CellCalcs.cellcover<W,M,N,T>();
        }

        /// <summary>
        /// Computes the number of cells covered by a block
        /// </summary>
        public int BlockLength
        {
            [MethodImpl(Inline)]
            get => CellCalcs.blocklength<W,T>();
        }

        /// <summary>
        /// Returns a dimension expression of the form {R}x{C}x{W}w where
        /// R := row count
        /// C := column count
        /// W := cell width
        /// </summary>
        public string Format()
            => $"{BlockWidth}::{RowCount}x{ColCount}x{CellWidth}w";
    }
}