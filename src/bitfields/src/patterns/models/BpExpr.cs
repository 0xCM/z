//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = BitPatterns;
public readonly record struct BpExpr : IComparable<BpExpr>
{
    public readonly @string Data;

    [MethodImpl(Inline)]
    public BpExpr(string src)
    {
        Data = src;
    }

    public uint BitWidth
    {
        get => api.bitwidth(this);
    }
    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Data.IsEmpty;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Data.IsNonEmpty;
    }

    public DataSize DataSize
    {
        [MethodImpl(Inline)]
        get => BitPatterns.size(this);
    }

    public int PatternLength
    {
        [MethodImpl(Inline)]
        get => Data.Length;
    }

    public string Format()
        => Data.Format();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public bool Equals(BpExpr src)
        => Data.Equals(src.Data);

    [MethodImpl(Inline)]
    public int CompareTo(BpExpr src)
        => Data.CompareTo(src.Data);

    public override int GetHashCode()
        => Data.GetHashCode();

    [MethodImpl(Inline)]
    public static implicit operator BpExpr(string src)
        => new (src);

    public static BpExpr Empty => new(EmptyString);
}
