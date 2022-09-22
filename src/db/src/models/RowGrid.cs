//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static sys;

    public class DbRowGrid<T>
    {
        readonly Index<T> Data;

        readonly Index<uint> _Offsets;

        public readonly uint CellCount;

        public readonly uint RowCount;

        public readonly uint ColCount;

        public DbRowGrid(Dim2<uint> shape)
        {
            RowCount = shape.I;
            ColCount = shape.J;
            CellCount = shape.I*shape.J;
            Data = sys.alloc<T>(CellCount);
            _Offsets = DbGrids.CalcRowOffsets(shape);
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref readonly Index<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => ref _Offsets;
        }

        [MethodImpl(Inline)]
        public Span<T> Row(uint row)
            =>  slice(Data.Edit, Offsets[row], ColCount);

        [MethodImpl(Inline)]
        public ref T Cell(uint row, uint col)
            => ref seek(Row(row), col);

        [MethodImpl(Inline)]
        uint index(uint row, uint col)
            => row == 0 ? col : row*ColCount + col;

        public ref T this[uint row, uint col]
        {
            [MethodImpl(Inline)]
            get => ref Data[index(row,col)];
        }

        public DbColGrid<T> Columns()
            => new DbColGrid<T>(this);
    }

}