//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Represents the content of a 64-bit opmask regigers
/// </summary>
public struct EvexPredicate
{
    ulong Data;

    [MethodImpl(Inline)]
    public EvexPredicate(ulong src)
    {
        Data = src;
    }

    [MethodImpl(Inline)]
    public ulong Bits()
        => Data;

    [MethodImpl(Inline)]
    public static implicit operator EvexPredicate(ulong src)
        => new (src);

    [MethodImpl(Inline)]
    public static EvexPredicate operator <<(EvexPredicate a, int shift)
        => new (a.Data << shift);

    [MethodImpl(Inline)]
    public static EvexPredicate operator >>(EvexPredicate a, int shift)
        => new (a.Data >> shift);

    [MethodImpl(Inline)]
    public static EvexPredicate operator &(EvexPredicate a, EvexPredicate b)
        => new (a.Data & b.Data);

    [MethodImpl(Inline)]
    public static EvexPredicate operator |(EvexPredicate a, EvexPredicate b)
        => new (a.Data | b.Data);

    [MethodImpl(Inline)]
    public static EvexPredicate operator ^(EvexPredicate a, EvexPredicate b)
        => new (a.Data | b.Data);

    [MethodImpl(Inline)]
    public static EvexPredicate operator ~(EvexPredicate a)
        => new (~a.Data);

    [MethodImpl(Inline)]
    public static EvexPredicate operator -(EvexPredicate a)
        => new (math.negate(a.Data));
}
