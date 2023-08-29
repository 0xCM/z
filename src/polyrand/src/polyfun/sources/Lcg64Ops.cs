//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using G = Lcg64;
using api = Lcg64Ops;

[ApiHost]
public readonly partial struct Lcg64Ops
{
    [MethodImpl(Inline), Op]
    public static void spin(ref G g, Func<ulong,bool> f)
    {
        while(true)
        {
            if(!f(next(g)))
                break;
        }
    }

    [MethodImpl(Inline), Op]
    public static G create(N64 n, ulong mul, ulong inc, ulong mod, ulong seed)
    {
        var min = inc == 0 ? 1ul : 0ul;
        var max = mod - 1;
        return new G(mul,inc,mod,seed,min,max);
    }

    [MethodImpl(Inline), Op]
    public static void capture(ref G g, Span<ulong> dst)
    {
        var count = (uint)dst.Length;
        for(var i=0u; i<count; i++)
        {
            advance(ref g);
            seek(dst,i) = g.State;
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
    public static ulong next(in G g)
        => (g.Mul*g.State + g.Inc) % g.Mod;

    [MethodImpl(Inline), Op]
    public static ref G advance(ref G g)
    {
        g.State = api.next(g);
        return ref g;
    }

    [MethodImpl(Inline), Op]
    public static ref G advance(ref G g, uint count)
    {
        for(var i=0; i<count; i++)
            api.advance(ref g);
        return ref g;
    }

    [MethodImpl(Inline), Op]
    public static ulong min(in G g)
        => g.Inc == 0 ? 1ul : 0ul;

    [MethodImpl(Inline), Op]
    public static ulong max(in G g)
        => g.Mod - 1;
}
