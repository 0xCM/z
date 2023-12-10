//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class DbColGrid<T>
    {
        readonly Index<T> Data;

        readonly Index<uint> _Offsets;

        public readonly uint CellCount;

        public readonly uint RowCount;

        public readonly uint ColCount;

        public DbColGrid(DbRowGrid<T> src)
        {
            CellCount = src.CellCount;
            RowCount = src.RowCount;
            ColCount = src.ColCount;
            Data = sys.alloc<T>(CellCount);
            _Offsets = DbGrids.CalcColOffsets(new Dim<uint>(src.RowCount,src.ColCount));
            for(var j=0u; j<RowCount; j++)
                for(var i=0u; i<ColCount; i++)
                    this[j,i] = src[i,j];
        }

        public DbColGrid(Dim<uint> shape)
        {
            RowCount = shape.I;
            ColCount = shape.J;
            CellCount = shape.I*shape.J;
            Data = sys.alloc<T>(CellCount);
            _Offsets = DbGrids.CalcColOffsets(shape);
        }

        public ref readonly Index<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => ref _Offsets;
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public Span<T> Col(uint col)
            =>  slice(Data.Edit, Offsets[col], RowCount);

        [MethodImpl(Inline)]
        public ref T Cell(uint row, uint col)
            => ref seek(Col(col), row);

        public ref T this[uint row, uint col]
        {
            [MethodImpl(Inline)]
            get => ref Cell(row,col);
        }
    }
}