//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = grids;

    public readonly ref struct GridView<T>
    {
        readonly ReadOnlySpan<T> Data;

        public readonly GridDim Dim;

        [MethodImpl(Inline)]
        public GridView(GridDim dim, ReadOnlySpan<T> data)
        {
            Dim = dim;
            Data = data;
        }

        ref readonly T First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        [MethodImpl(Inline)]
        public ref readonly T Cell(uint row, uint col)
            => ref seek(First, api.lineraize(Dim, (row, col)));

        [MethodImpl(Inline)]
        public ref readonly T Cell(CellIndex point)
            => ref seek(First, api.lineraize(Dim, point));

        public ref readonly T this[uint row, uint col]
        {
            [MethodImpl(Inline)]
            get => ref Cell(row,col);
        }
    }
}