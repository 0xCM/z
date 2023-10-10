//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Specifies the origin of a bitfield definition
/// </summary>
public readonly record struct BfOrigin<T>
{
    public readonly T Value;

    [MethodImpl(Inline)]
    public BfOrigin(T value)
    {
        Value = value;
    }

    [MethodImpl(Inline)]
    public string Format()
        => Value.ToString();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator BfOrigin<T>(T src)
        => new BfOrigin<T>(src);

    [MethodImpl(Inline)]
    public static implicit operator BfOrigin(BfOrigin<T> src)
        => new BfOrigin(src.Value, (dynamic x) => ((T)x).ToString());
}
