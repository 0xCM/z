//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;


using api = Lcg8Ops;

[Rng(nameof(Lcg8))]
public struct Lcg8 : IRng<byte>
{
    internal readonly byte Mul;

    internal readonly byte Inc;

    internal readonly byte Mod;

    internal readonly byte Seed;

    internal readonly byte Min;

    internal readonly byte Max;

    internal byte State;

    [MethodImpl(Inline)]
    internal Lcg8(byte mul, byte inc, byte mod, byte seed)
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

    [MethodImpl(Inline)]
    public byte Next()
        => api.next(this);

    public ByteSize Fill(Span<byte> dst)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next();
        return size;
    }

    public Label Name => nameof(Lcg8);
}
