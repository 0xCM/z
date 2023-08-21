//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public readonly record struct KindedToken<K,V> : IKindedToken<K,V>, IComparable<KindedToken<K,V>>
    where K : unmanaged
    where V : unmanaged
{
    public readonly K Kind;

    public readonly V Value;

    [MethodImpl(Inline)]
    public KindedToken(K kind, V value)
    {
        Kind = kind;
        Value = value;
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => sys.u64(Kind) == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => sys.u64(Kind) != 0;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => ((Hash32)sys.u32(Kind)) | ((Hash32)sys.u32(Value));
    }

    K IKinded<K>.Kind
        => Kind;

    V IValued<V>.Value
        => Value;

    public bool Equals(KindedToken<K,V> src)
        => sys.u64(Kind) == sys.u64(src.Kind) && sys.u64(Value) == sys.u64(src.Value);

    [MethodImpl(Inline)]
    public int CompareTo(KindedToken<K,V> src)    
    {
        var result = sys.i64(Kind).CompareTo(sys.i64(src.Kind));
        if(result == 0)
        {
            result = sys.i64(Value).CompareTo(sys.i64(src.Value));
        }
        return result;
    }

    public override int GetHashCode()
        => Hash;
 
    public override string ToString()
        => Format();
 
    public string Format()
        => $"{Kind}:{Value}";

    public static KindedToken<K,V> Empty => default;

    [MethodImpl(Inline)]
    public static implicit operator KindedToken(KindedToken<K,V> src)
        => new(sys.u64(src.Kind), sys.u64(src.Value));

    [MethodImpl(Inline)]
    public static implicit operator KindedToken<K,V>(KindedToken src)
        => new(sys.generic<K>(src.Kind), sys.generic<V>(src.Value));
}
