//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct KindedToken : IKindedToken<ulong,ulong>, IComparable<KindedToken>
{
    public readonly ulong Kind;

    public readonly ulong Value;

    [MethodImpl(Inline)]
    public KindedToken(ulong kind, ulong value)
    {
        Kind = kind;
        Value = value;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Kind == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Kind != 0;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => ((Hash32)Kind) | ((Hash32)Value);
    }

    ulong IKinded<ulong>.Kind
        => Kind;

    ulong IValued<ulong>.Value
        => Value;

    public override int GetHashCode()
        => Hash;
    public override string ToString()
        => Format();

    public string Format()
        => $"{Kind}:{Value}";

    public int CompareTo(KindedToken src)    
    {
        var result = sys.i64(Kind).CompareTo(sys.i64(src.Kind));
        if(result == 0)
        {
            result = sys.i64(Value).CompareTo(sys.i64(src.Value));
        }
        return result;
    }

    public bool Equals(KindedToken src)
        => Kind == src.Kind && Value == src.Value;
}
