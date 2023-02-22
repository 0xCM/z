//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Locates a cell in a grid with <typeparamref name='T'/> parametric coordinates
    /// </summary>
    [StructLayout(StructLayout, Pack=1)]
    public readonly record struct CellIndex<T> : ICellIndex<CellIndex<T>,T>
        where T : unmanaged
    {
        /// <summary>
        /// The cell row
        /// </summary>
        public readonly T Row;

        /// <summary>
        /// The cell column
        /// </summary>
        public readonly T Col;

        [MethodImpl(Inline)]
        public CellIndex(T row, T col)
        {
            Row = row;
            Col = col;
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => u32(Row) == 0 && u32(Col) == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => u32(Row) != 0 || u32(Col) != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(u32(Row), u32(Col));
        }

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public CellIndex<T> IncRow()
            => new CellIndex<T>(add(Row,1), Col);

        [MethodImpl(Inline)]
        public CellIndex<T> DecRow()
            => new CellIndex<T>(sub(Row,1), Col);

        [MethodImpl(Inline)]
        public CellIndex<T> IncCol()
            => new CellIndex<T>(Row, add(Col,1));

        [MethodImpl(Inline)]
        public CellIndex<T> DecCol()
            => new CellIndex<T>(Row, sub(Col,1));

        [MethodImpl(Inline)]
        public bool Equals(CellIndex<T> src)
            => bw64(this) == bw64(src);
        public string Format()
            => string.Format(CellIndex.RenderPattern, Row, Col);

        public override string ToString()
            => Format();

        T ICellIndex<CellIndex<T>, T>.Row
            => Row;

        T ICellIndex<CellIndex<T>, T>.Col
            => Col;

        [MethodImpl(Inline)]
        public static CellIndex<T> operator++(CellIndex<T> src)
            => src.IncRow();

        [MethodImpl(Inline)]
        public static CellIndex<T> operator--(CellIndex<T> src)
            => src.DecRow();

        [MethodImpl(Inline)]
        public static implicit operator CellIndex<T>(Pair<T> src)
            => new CellIndex<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator CellIndex<T>((T row, T col) src)
            => new CellIndex<T>(src.row, src.col);

        public static CellIndex<T> Zero
            => new CellIndex<T>(default, default);
    }
}