//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = LcgOps;

[Rng("Lcg<{0}>")]
public struct Lcg<T> : IRng<T>
    where T : unmanaged
{
    internal readonly T Mul;

    internal readonly T Inc;

    internal readonly T Mod;

    internal readonly T Seed;

    internal readonly T Min;

    internal readonly T Max;

    internal T State;

    [MethodImpl(Inline)]
    internal Lcg(T mul, T inc, T mod, T seed)
        : this()
    {
        Mul = mul;
        Inc = inc;
        Mod = mod;
        Seed = seed;
        State = Seed;
        Min = api.min(this);
        Max = api.max(this);
    }

    public Label Name => "Lcg<{0}>";

    [MethodImpl(Inline)]
    public T Next()
        => api.next(this);
}
