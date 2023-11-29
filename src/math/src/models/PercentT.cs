//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a datatype that represents a discrete percentage
/// </summary>
public readonly struct Percent<T>
    where T : unmanaged
{
    public readonly Quotient<T> Value;

    [MethodImpl(Inline)]
    public Percent(T over, T under)
        => Value = (over,under);

    [MethodImpl(Inline)]
    public Percent(Quotient<T> src)
        => Value = src;

    [MethodImpl(Inline)]
    public string Format()
        => Value.ToString();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator Percent<T>(Quotient<T> src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator Percent<T>(Pair<T> src)
        => new (src.Left, src.Right);

    public static Percent<T> Zero
        => Quotient<T>.Zero;
}
