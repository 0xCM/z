//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    /// <summary>
    /// Identifies a cell within the context of a table
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct CellIndex : IComparable<CellIndex>, IEquatable<CellIndex>, IHashed
    {
        internal const string RenderPattern = "({0},{1})";

        /// <summary>
        /// A zero-based row index
        /// </summary>
        public readonly uint Row;

        /// <summary>
        /// A zero-based column index
        /// </summary>
        public readonly uint Col;

        [MethodImpl(Inline)]
        public CellIndex(uint row, uint col)
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
            get => hash(Row, Col);
        }

        public string Format()
            => string.Format(RenderPattern, Row, Col);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public bool Equals(CellIndex src)
            => Row == src.Row && Col == src.Col;

        [MethodImpl(Inline)]
        public int CompareTo(CellIndex src)
        {
            if(Row == src.Row)
                return Col.CompareTo(src.Col);
            else
                return Row.CompareTo(src.Row);
        }

        [MethodImpl(Inline)]
        public CellIndex IncRow()
            => new (Row+1,Col);

        [MethodImpl(Inline)]
        public CellIndex DecRow()
            => new (Row-1,Col);

        [MethodImpl(Inline)]
        public CellIndex IncCol()
            => new (Row,Col+1);

        [MethodImpl(Inline)]
        public CellIndex DecCol()
            => new (Row,Col-1);

        [MethodImpl(Inline)]
        public static implicit operator CellIndex((uint row, uint col) src)
            => new CellIndex(src.row, src.col);

        [MethodImpl(Inline)]
        public static implicit operator (uint row, uint col)(CellIndex src)
            => (src.Row, src.Col);

        [MethodImpl(Inline)]
        public static CellIndex operator++(CellIndex src)
            => src.IncRow();

        [MethodImpl(Inline)]
        public static CellIndex operator--(CellIndex src)
            => src.DecRow();

        public static CellIndex Zero => default;

        public static CellIndex Empty
            => new CellIndex(uint.MaxValue, uint.MaxValue);
    }
}