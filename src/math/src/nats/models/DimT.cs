//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct Dim<T>
    where T : unmanaged
{
    public readonly T I;

    public readonly T J;

    [MethodImpl(Inline)]
    public Dim(T m, T n)
    {
        I = m;
        J = n;
    }

    public string Format()
        => $"{I}×{J}";

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator Dim<T>((T m, T n) src)
        => new Dim<T>(src.m, src.n);
}
