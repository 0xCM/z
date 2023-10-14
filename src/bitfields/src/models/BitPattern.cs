//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct BitPattern : IComparable<BitPattern>
{
    public readonly @string Data;

    [MethodImpl(Inline)]
    public BitPattern(string src)
    {
        Data = src;
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
    public bool Equals(BitPattern src)
        => Data.Equals(src.Data);

    [MethodImpl(Inline)]
    public int CompareTo(BitPattern src)
        => Data.CompareTo(src.Data);

    public override int GetHashCode()
        => Data.GetHashCode();

    [MethodImpl(Inline)]
    public static implicit operator BitPattern(string src)
        => new (src);
}
