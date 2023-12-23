//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using G = Lcg32;

[Rng(nameof(Lcg64)), ApiHost]
public struct Lcg32 : IRng<uint>
{
    [MethodImpl(Inline), Op]
    public static void spin(ref G g, Func<uint,bool> f)
    {
        while(true)
        {
            if(!f(advance(ref g).State))
                break;
        }
    }

    [MethodImpl(Inline), Op]
    public static ref G skip(ref G g, uint n)
    {
        for(var i=0; i<n; i++)
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
    public static ref G advance(ref G g, uint count)
    {
        for(var i=0; i<count; i++)
            advance(ref g);
        return ref g;
    }

    [MethodImpl(Inline), Op]
    public static uint min(in G g)
        => g.Inc == 0 ? 1u : 0u;

    [MethodImpl(Inline), Op]
    public static uint max(in G g)
        => g.Mod - 1;

    readonly uint Mul;

    readonly uint Inc;

    readonly uint Mod;

    uint State;

    [MethodImpl(Inline)]
    internal Lcg32(uint mul, uint inc, uint mod, uint seed)
    {
        Mul = mul;
        Inc = inc;
        Mod = mod;
        State = seed;
    }

    [MethodImpl(Inline)]
    public uint Next()
        => advance(ref this).State;

    public Label Name => nameof(Lcg32);

    public ByteSize Fill(Span<uint> dst)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next();
        return size;
    }
}
