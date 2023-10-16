//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static num;

public struct num<T> : IScalarValue<T>, IComparable<num<T>>, IEquatable<num<T>>
    where T : unmanaged
{
    public T Value;

    [MethodImpl(Inline)]
    public num(T value)
        => Value = value;

    [MethodImpl(Inline)]
    public bool Equals(num<T> src)
        => eq(this, src);

    [MethodImpl(Inline)]
    public int CompareTo(num<T> src)
        => gmath.cmp(Value,src.Value);

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString()
        => Value.ToString();

    public override bool Equals(object src)
        => src is num<T> x && Equals(x);

    T IValued<T>.Value
        => Value;

    [MethodImpl(Inline)]
    public static bool operator ==(num<T> a, num<T> b)
        => eq(a,b);

    [MethodImpl(Inline)]
    public static bool operator !=(num<T> a, num<T> b)
        => neq(a,b);

    [MethodImpl(Inline)]
    public static bool operator <(num<T> a, num<T> b)
        => lt(a,b);

    [MethodImpl(Inline)]
    public static bool operator >(num<T> a, num<T> b)
        => gt(a,b);

    [MethodImpl(Inline)]
    public static bool operator <=(num<T> a, num<T> b)
        => lteq(a,b);

    [MethodImpl(Inline)]
    public static bool operator >=(num<T> a, num<T> b)
        => gteq(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator +(num<T> a, num<T> b)
        => add(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator -(num<T> a, num<T> b)
        => sub(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator *(num<T> a, num<T> b)
        => mul(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator /(num<T> a, num<T> b)
        => div(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator %(num<T> a, num<T> b)
        => mod(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator -(num<T> a)
        => negate(a);

    [MethodImpl(Inline)]
    public static num<T> operator &(num<T> a, num<T> b)
        => and(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator |(num<T> a, num<T> b)
        => or(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator ^(num<T> a, num<T> b)
        => xor(a,b);

    [MethodImpl(Inline)]
    public static num<T> operator >>(num<T> a, int offset)
        => srl(a,(byte)offset);

    [MethodImpl(Inline)]
    public static num<T> operator <<(num<T> a, int offset)
        => sll(a,(byte)offset);

    [MethodImpl(Inline)]
    public static num<T> operator ~(num<T> a)
        => not(a);

    [MethodImpl(Inline)]
    public static num<T> operator ++(num<T> a)
        => inc(a);

    [MethodImpl(Inline)]
    public static num<T> operator --(num<T> a)
        => dec(a);

    [MethodImpl(Inline)]
    public static implicit operator T(num<T> src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator num<T>(T src)
        => new num<T>(src);
}
