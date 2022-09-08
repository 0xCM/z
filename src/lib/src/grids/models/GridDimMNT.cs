//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Encapsulates metrics that characterize a grid of natural rectangular dimensions
    /// </summary>
    public readonly struct GridDim<M,N,T>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        /// <summary>
        /// The total number gb of grid bits determined by gb := MxN
        /// </summary>
        public BitWidth BitCount
        {
            [MethodImpl(Inline)]
            get => grids.gridwidth<M,N,T>();
        }

        /// <summary>
        /// The number of grid rows
        /// </summary>
        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => nat32u<M>();
        }

        /// <summary>
        /// The number of grid columns
        /// </summary>
        public uint ColCount
        {
            [MethodImpl(Inline)]
            get => nat32u<N>();
        }

        /// <summary>
        /// The bit width of a storage cell
        /// </summary>
        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => width<T>();
        }

        /// <summary>
        /// The number of cells required cover a grid
        /// </summary>
        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => grids.gridcells<M,N,T>();
        }

        /// <summary>
        /// The number of bytes required to cover a grid
        /// </summary>
        public ByteSize GridSize
        {
            [MethodImpl(Inline)]
            get => grids.gridsize<M,N,T>();
        }

        /// <summary>
        /// Returns a dimension expression of the form RxCxWw where
        /// R := row count
        /// C := column count
        /// W := cell width
        /// </summary>
        public string Format()
            => $"{RowCount}x{ColCount}x{CellWidth}w";
    }
}