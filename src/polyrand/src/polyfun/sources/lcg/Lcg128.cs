//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using u128 = UInt128;
using G = Lcg128;

[Rng(nameof(Lcg64)), ApiHost]
public struct Lcg128 : IRng<u128>
{
    [MethodImpl(Inline), Op]
    public static void spin(ref G g, Func<u128,bool> f)
    {
        while(f(advance(ref g).State)){}
    }

    [MethodImpl(Inline), Op]
    public static ref G skip(ref G g, u128 n)
    {
        for(u128 i=0; i<n; i++)
            advance(ref g);
        return ref g;
    }

    [MethodImpl(Inline), Op]
    public static ref G advance(ref G g)
    {
        g.State = (g.Mul*g.State + g.Inc) % g.Mod;
        return ref g;
    }

    [MethodImpl(Inline), Op]
    public static ref G advance(ref G g, u128 count)
    {
        for(u128 i=0; i<count; i++)
            advance(ref g);
        return ref g;
    }

    readonly u128 Mul;

    readonly u128 Inc;

    readonly u128 Mod;

    u128 State;

    [MethodImpl(Inline)]
    internal Lcg128(u128 mul, u128 inc, u128 mod, u128 seed)
    {
        Mul = mul;
        Inc = inc;
        Mod = mod;
        State = seed;
    }

    [MethodImpl(Inline)]
    public u128 Next()
        => advance(ref this).State;

    public Label Name => nameof(Lcg128);

    public ByteSize Fill(Span<u128> dst)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next();
        return size;
    }
}
