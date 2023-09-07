//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using G = WyHash64;

/// <summary>
/// Implements a 64-bit random number generator
/// </summary>
/// <remarks>Core algorithm taken from https://github.com/lemire/testingRNG/blob/master/source/wyhash.h</remarks>
[ApiHost]
[Rng(nameof(WyHash64))]
public struct WyHash64 : IRandomSource<WyHash64,ulong>
{
    [MethodImpl(Inline), Op]
    public static ulong next(ref G g)
    {
        g.State += X1;
        zUInt128.mul(g.State, X2, out var Y1);
        var m1 = Y1.Lo ^ Y1.Hi;
        zUInt128.mul(m1, X3, out var Y2);
        var m2 = Y2.Lo ^ Y2.Hi;
        return m2;
    }

    [MethodImpl(Inline), Op]
    public static ulong next(ref G g, out ulong dst)
        => dst = next(ref g);

    [MethodImpl(Inline), Op]
    public static ulong next(ref G g, ulong max)
        => math.contract(next(ref g), max);

    [MethodImpl(Inline), Op]
    public static ulong next(ref G g, ulong min, ulong max)
        => min + next(ref g, max - min);


    ulong State;

    [MethodImpl(Inline)]
    public WyHash64(ulong state)
        => State = state;

    public Label Name => nameof(WyHash64);

    [MethodImpl(Inline)]
    public ulong Next()
        => next(ref this);

    [MethodImpl(Inline)]
    public ulong Next(ulong max)
        => next(ref this, max);

    [MethodImpl(Inline)]
    public ulong Next(ulong min, ulong max)
        => next(ref this, min, max);

    public ByteSize Fill(Span<ulong> dst)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next();
        return size;
    }

    public ByteSize Fill(Span<ulong> dst, ulong max)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next(max);
        return size;
    }

    public ByteSize Fill(Span<ulong> dst, ulong min, ulong max)
    {
        var size = 0u;
        for(var i=0; i<dst.Length; i++, size+=8)
            seek(dst,i) = Next(min, max);
        return size;
    }

    const ulong X1 = 0x60bee2bee120fc15;

    const ulong X2 = 0xa3b195354a39b70d;

    const ulong X3 = 0x1b03738712fad5c9;
}
