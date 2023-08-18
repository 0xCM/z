//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct BfOrigin
{
    public readonly dynamic Value;

    readonly Func<dynamic,string> Render;

    [MethodImpl(Inline)]
    public BfOrigin(dynamic src)
    {
        Value = src;
        Render = (dynamic x) => x?.ToString();
    }

    [MethodImpl(Inline)]
    public BfOrigin(dynamic src, Func<dynamic,string> render)
    {
        Value = src;
        Render = render;
    }

    public string Format()
        => Render?.Invoke(Value);

    public override string ToString()
        => Format();

    public static BfOrigin Empty => new (EmptyString);
}
