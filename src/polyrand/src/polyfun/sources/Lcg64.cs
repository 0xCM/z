//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = Lcg64Ops;

[Rng(nameof(Lcg64))]
public struct Lcg64 : IRng<ulong>
{
    internal readonly ulong Mul;

    internal readonly ulong Inc;

    internal readonly ulong Mod;

    internal readonly ulong Seed;

    internal readonly ulong Min;

    internal readonly ulong Max;

    internal ulong State;

    [MethodImpl(Inline)]
    internal Lcg64(ulong mul, ulong inc, ulong mod, ulong seed, ulong min, ulong max)
    {
        Mul = mul;
        Inc = inc;
        Mod = mod;
        Seed = seed;
        State = seed;
        Min = min;
        Max = max;
    }

    [MethodImpl(Inline)]
    public ulong Next()
        => api.next(this);

    public Label Name => nameof(Lcg64);

}
