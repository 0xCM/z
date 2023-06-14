//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Defines a structured surrogate over a ternary function delegate
/// </summary>
public readonly struct SurrogateFunc<X0,X1,X2,R> : IFunc<X0,X1,X2,R>
{
    readonly System.Func<X0,X1,X2,R> F;

    public OpIdentity Id {get;}

    [MethodImpl(Inline)]
    public SurrogateFunc(System.Func<X0,X1,X2,R> f, OpIdentity id)
    {
        F = f;
        Id = id;
    }

    [MethodImpl(Inline)]
    public R Invoke(X0 x0, X1 x1, X2 x2)
        => F(x0, x1, x2);

    public System.Func<X0,X1,X2,R> Subject
    {
        [MethodImpl(Inline)]
        get => F;
    }

    [MethodImpl(Inline)]
    public static implicit operator System.Func<X0,X1,X2,R>(SurrogateFunc<X0,X1,X2,R> src)
        => src.F;
}

