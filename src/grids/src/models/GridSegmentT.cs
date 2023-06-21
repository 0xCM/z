//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CharText;

    [StructLayout(StructLayout, Pack=1)]
    public readonly struct GridSegment<T>
        where T : unmanaged
    {
        /// <summary>
        /// The grid dimension
        /// </summary>
        public readonly GridDim Dim;

        /// <summary>
        /// The bit-width of a grid cell
        /// </summary>
        public readonly uint CellWidth;

        /// <summary>
        /// The bit-width of a segment that covers one or more cells
        /// </summary>
        public readonly uint SegWidth;

        [MethodImpl(Inline)]
        public GridSegment(GridDim dim, uint segwidth)
        {
            Dim = dim;
            SegWidth = segwidth;
            CellWidth = width<T>();
        }

        /// <summary>
        /// Returns a dimension expression of the form {RowCount}x{ColCount}x{CellWidth}{[SegWidth]} where
        /// R := row count
        /// C := column count
        /// W := cell width
        /// </summary>
        public string Format()
            => $"{Dim}x{CellWidth}[{SegWidth}]";

        public override string ToString()
            => Format();

        public static RenderTemplate RT
            => fLT + nameof(Dim) + fRT + x
             + fLT + nameof(CellWidth) + fRT + x
             + fLT + fRB + nameof(SegWidth) + fRT + fRB
             ;
    }
}