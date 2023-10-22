//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct SymGrid<R,C>
    where R : unmanaged
    where C : unmanaged
{
    readonly Symbols<R> RowData;

    readonly Symbols<C> ColData;

    [MethodImpl(Inline)]
    public SymGrid(Symbols<R> rows, Symbols<C> cols)
    {
        RowData = rows;
        ColData = cols;
    }

    public ReadOnlySpan<Sym<R>> Rows
    {
        [MethodImpl(Inline)]
        get => RowData.View;
    }

    public ReadOnlySpan<Sym<C>> Cols
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
    public ref readonly Sym<R> Row(R row)
        => ref RowData[row];

    [MethodImpl(Inline)]
    public ref readonly Sym<C> Col(C col)
        => ref ColData[col];

    [MethodImpl(Inline)]
    public ref readonly Sym<R> Row(uint row)
        => ref RowData[row];

    [MethodImpl(Inline)]
    public ref readonly Sym<C> Col(uint col)
        => ref ColData[col];

    [MethodImpl(Inline)]
    public SymPair<R,C> Pair(R row, C col)
        => (Row(row),Col(col));

    [MethodImpl(Inline)]
    public SymPair<R,C> Pair(uint row, uint col)
        => (Row(row),Col(col));

    public SymPair<R,C> this[uint row, uint col]
    {
        [MethodImpl(Inline)]
        get => Pair(row,col);
    }

    public SymPair<R,C> this[R row, C col]
    {
        [MethodImpl(Inline)]
        get => Pair(row,col);
    }
}
