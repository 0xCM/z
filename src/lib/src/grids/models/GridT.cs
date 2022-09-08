//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = grids;

    public readonly struct Grid<T>
    {
        readonly Index<T> Data;

        public readonly GridDim Dim;

        [MethodImpl(Inline)]
        public Grid(GridDim dim, T[] data)
        {
            Dim = dim;
            Data = data;
        }

        ref T First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => Dim.M;
        }

        public uint ColCount
        {
            [MethodImpl(Inline)]
            get => Dim.N;
        }

        [MethodImpl(Inline)]
        public ref T Cell(uint row, uint col)
            => ref seek(First, api.lineraize(Dim, (row, col)));

        [MethodImpl(Inline)]
        public ref T Cell(CellIndex point)
            => ref seek(First, api.lineraize(Dim, point));

        public ref T this[uint row, uint col]
        {
            [MethodImpl(Inline)]
            get => ref Cell(row,col);
        }

        public ref T this[int row, int col]
        {
            [MethodImpl(Inline)]
            get => ref Data[Dim.Offset((uint)row,(uint)col)];
        }

        [MethodImpl(Inline)]
        public Span<T> Row(uint row)
            => cover(Data[row*Dim.N], Dim.N);
    }
}