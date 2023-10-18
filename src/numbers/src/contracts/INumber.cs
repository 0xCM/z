//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Numerics;

[Free]
public interface INumber
{
    byte PackedWidth {get;}

    ulong Value {get;}

    public bit IsZero {get;}

    public bit IsNonZero {get;}

    public bit IsMax {get;}

    string Format();    

    string Bitstring();

    string Hex();
}

[Free]
public interface INumber<T> : INumber, 
    IEquatable<T>, 
    IComparable<T>, 
    IAdditionOperators<T,T,T>,
    ISubtractionOperators<T,T,T>,
    IMultiplyOperators<T,T,T>,
    IBitwiseOperators<T,T,T>,
    IIncrementOperators<T>,
    IDecrementOperators<T>,
    IComparisonOperators<T,T,bit>    
    where T : unmanaged, INumber<T>
{
    static abstract T Zero {get;}

    static abstract T One {get;}

    static abstract T Min {get;}

    static abstract T Max {get;}

    static abstract T number<S>(S src)
        where S : unmanaged;
    
    static abstract T add(T a, T b);

    static abstract T sub(T a, T b);

    static abstract T mul(T a, T b);

    static abstract T div(T a, T b);

    static abstract T mod(T a, T b);

    static abstract bit eq(T a, T b);

    static abstract bit ne(T a, T b);

    static abstract bit gt(T a, T b);

    static abstract bit lt(T a, T b);

    static abstract bit ge(T a, T b);

    static abstract bit le(T a, T b);

    static abstract T srl(T src, byte count);

    static abstract T sll(T src, byte count);

    static abstract T inc(T src);

    static abstract T dec(T src);

    static abstract T reduce(T src);

    static abstract T set(T src, byte pos, bit state);

    static abstract bit test(T src, byte pos);

    static abstract T negate(T src);

    static abstract T invert(T src);

    static abstract T or(T a, T b);

    static abstract T and(T a, T b);

    static abstract bool parse(ReadOnlySpan<char> src, out T dst);    
}