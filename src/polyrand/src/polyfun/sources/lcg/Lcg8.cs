//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using G = Lcg8;

[Rng(nameof(Lcg8)), ApiHost]
public struct Lcg8 : IRng<byte>
{
    [MethodImpl(Inline), Op]
    public static void spin(ref G g, Func<byte,bool> f)
    {
        while(true)
        {
            if(!f(advance(ref g).State))
                break;
        }
    }

    [MethodImpl(Inline), Op]
    public static byte min(in G g)
        => g.Inc == 0 ? (byte)1 : (byte)0;

    [MethodImpl(Inline), Op]
    public static byte max(in G g)
        => (byte)(g.Mod - 1);

    [MethodImpl(Inline), Op]
    public static void capture(ref G g, Span<byte> dst)
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
        g.State = (byte)((g.Mul*g.State + g.Inc) % g.Mod);
        return ref g;
    }

    [MethodImpl(Inline), Op]
    public static ref G advance(ref G g, uint count)
    {
        for(var i=0; i<count; i++)
            advance(ref g);
        return ref g;
    }

    readonly byte Mul;

    readonly byte Inc;

    readonly byte Mod;

    readonly byte Seed;

    readonly byte Min;

    readonly byte Max;

    byte State;

    [MethodImpl(Inline)]
    internal Lcg8(byte mul, byte inc, byte mod, byte seed)
        : this()
    {
        Mul = mul;
        Inc = inc;
        Mod = mod;
        Seed = seed;
        State = Seed;
        Min = min(this);
        Max = max(this);
    }

    [MethodImpl(Inline)]
    public byte Next()
        => advance(ref this).State;

    public ByteSize Fill(Span<byte> dst)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next();
        return size;
    }

    public Label Name => nameof(Lcg8);
}
