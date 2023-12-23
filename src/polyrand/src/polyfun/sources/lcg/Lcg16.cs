//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using G = Lcg16;

[Rng(nameof(Lcg8)), ApiHost]
public struct Lcg16 : IRng<ushort>
{
    [MethodImpl(Inline), Op]
    public static void spin(ref G g, Func<ushort,bool> f)
    {
        while(true)
        {
            if(!f(advance(ref g).State))
                break;
        }
    }

    [MethodImpl(Inline), Op]
    public static ushort min(in G g)
        => g.Inc == 0 ? (ushort)1 : (ushort)0;

    [MethodImpl(Inline), Op]
    public static ushort max(in G g)
        => (ushort)(g.Mod - 1);

    [MethodImpl(Inline), Op]
    public static void capture(ref G g, Span<ushort> dst)
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
    public static ref G advance(ref G g)
    {
        g.State = (ushort)((g.Mul*g.State + g.Inc) % g.Mod);
        return ref g;
    }

    [MethodImpl(Inline), Op]
    public static ref G advance(ref G g, uint count)
    {
        for(var i=0; i<count; i++)
            advance(ref g);
        return ref g;
    }

    readonly ushort Mul;

    readonly ushort Inc;

    readonly ushort Mod;

    ushort State;

    [MethodImpl(Inline)]
    internal Lcg16(ushort mul, ushort inc, ushort mod, ushort seed)
        : this()
    {
        Mul = mul;
        Inc = inc;
        Mod = mod;
        State = seed;
    }

    [MethodImpl(Inline)]
    public ushort Next()
        => advance(ref this).State;

    public ByteSize Fill(Span<ushort> dst)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next();
        return size;
    }

    public Label Name => nameof(Lcg16);
}
