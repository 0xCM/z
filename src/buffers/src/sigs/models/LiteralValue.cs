//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1)]
public readonly record struct LiteralValue
{
    public readonly LiteralType Type;

    public readonly ulong Value;

    [MethodImpl(Inline)]
    public LiteralValue(LiteralType type, ulong value)
    {
        Type = type;
        Value = value;
    }

    [MethodImpl(Inline)]
    public static implicit operator LiteralValue<ulong>(LiteralValue src)
        => new (src.Type, src.Value);
}
