//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a structured surrogate over an emitter
/// </summary>
public readonly struct SurrogateFunc<R> : IFunc<R>
{
    public OpIdentity Id {get;}

    readonly System.Func<R> F;

    [MethodImpl(Inline)]
    public SurrogateFunc(System.Func<R> f, OpIdentity id)
    {
        F = f;
        Id = id;
    }

    [MethodImpl(Inline)]
    public R Invoke() => F();

    public System.Func<R> Subject
    {
        [MethodImpl(Inline)]
        get => F;
    }

    [MethodImpl(Inline)]
    public static implicit operator System.Func<R>(SurrogateFunc<R> src)
        => src.F;
}

