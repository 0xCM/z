//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using G = Lcg64;

[Rng(nameof(Lcg64)), ApiHost]
public struct Lcg64 : IRng<ulong>
{
    [MethodImpl(Inline), Op]
    public static void spin(ref G g, Func<ulong,bool> f)
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

    readonly ulong Mul;

    readonly ulong Inc;

    readonly ulong Mod;

    ulong State;

    [MethodImpl(Inline)]
    internal Lcg64(ulong mul, ulong inc, ulong mod, ulong seed)
    {
        Mul = mul;
        Inc = inc;
        Mod = mod;
        State = seed;
    }

    [MethodImpl(Inline)]
    public ulong Next()
        => advance(ref this).State;

    public Label Name => nameof(Lcg64);

    public ByteSize Fill(Span<ulong> dst)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next();
        return size;
    }
}
