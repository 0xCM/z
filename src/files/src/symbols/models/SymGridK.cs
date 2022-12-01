//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SymGrid<K>
        where K : unmanaged
    {
        readonly Symbols<K> RowData;

        readonly Symbols<K> ColData;

        [MethodImpl(Inline)]
        public SymGrid(Symbols<K> rows, Symbols<K> cols)
        {
            RowData = rows;
            ColData = cols;
        }

        public ReadOnlySpan<Sym<K>> Rows
        {
            [MethodImpl(Inline)]
            get => RowData.View;
        }

        public ReadOnlySpan<Sym<K>> Cols
        {
            [MethodImpl(Inline)]
            get => ColData.View;
        }

        public uint RowCount
        {
            [MethodImpl(Inline)]
            get => RowData.Count;
        }

        public uint ColCount
        {
            [MethodImpl(Inline)]
            get => ColData.Count;
        }

        [MethodImpl(Inline)]
        public ref readonly Sym<K> Row(K row)
            => ref RowData[row];

        [MethodImpl(Inline)]
        public ref readonly Sym<K> Col(K col)
            => ref ColData[col];

        [MethodImpl(Inline)]
        public ref readonly Sym<K> Row(uint row)
            => ref RowData[row];

        [MethodImpl(Inline)]
        public ref readonly Sym<K> Col(uint col)
            => ref ColData[col];

        [MethodImpl(Inline)]
        public SymPair<K> Pair(K row, K col)
            => (Row(row),Col(col));

        [MethodImpl(Inline)]
        public SymPair<K> Pair(uint row, uint col)
            => (Row(row),Col(col));

        public SymPair<K> this[uint row, uint col]
        {
            [MethodImpl(Inline)]
            get => Pair(row,col);
        }

        public SymPair<K> this[K row, K col]
        {
            [MethodImpl(Inline)]
            get => Pair(row,col);
        }
    }
}
