//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a datatype that represents a rational number
/// </summary>
public readonly struct Quotient<T> : IRatio<Quotient<T>,T>
{
    public readonly T Over;

    public readonly T Under;

    [MethodImpl(Inline)]
    public Quotient(T over, T under)
    {
        Over = over;
        Under = under;
    }

    [MethodImpl(Inline)]
    public string Format()
        => string.Format($"{Over}/{Under}");

    public override string ToString()
        => Format();

    T IRatio<T>.Over
        => Over;

    T IRatio<T>.Under    
        => Under;

    [MethodImpl(Inline)]
    public static implicit operator Quotient<T>((T over, T under) src)
        => new (src.over, src.under);

    [MethodImpl(Inline)]
    public static implicit operator Quotient<T>(Pair<T> src)
        => new (src.Left, src.Right);

    public static Quotient<T> Undefined
        => default;

    public static Quotient<T> Zero
        => (default(T), Numeric.force<T>(1));
}
