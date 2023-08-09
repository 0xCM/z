//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

public readonly partial struct XedCells : IIndex<CellValue>
{
    public readonly Index<CellValue> Data;

    public readonly byte LayoutCount;

    [MethodImpl(Inline)]
    public XedCells(CellValue[] src, byte lCount)
    {
        Data = src;
        LayoutCount = lCount;
    }

    public ReadOnlySpan<CellValue> Layout
    {
        [MethodImpl(Inline)]
        get => IsEmpty ? default : sys.slice(Data.View, 0, LayoutCount);
    }

    public ReadOnlySpan<CellValue> Expr
    {
        [MethodImpl(Inline)]
        get => IsEmpty ?  default : sys.slice(Data.View, LayoutCount);
    }

    public CellValue[] Storage
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Data.IsEmpty;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get =>  Data.IsNonEmpty;
    }

    public ref CellValue First
    {
        [MethodImpl(Inline)]
        get => ref Data.First;
    }

    public ref CellValue this[int i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public ref CellValue this[uint i]
    {
        [MethodImpl(Inline)]
        get => ref Data[i];
    }

    public byte Count
    {
        [MethodImpl(Inline)]
        get => (byte)Data.Count;
    }

    public byte ExprCount
    {
        [MethodImpl(Inline)]
        get => (byte)(Count - LayoutCount);
    }

    public string Format()
        => this.Delimit(Chars.Space).Format();

    public override string ToString()
        => Format();
}

