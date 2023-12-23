//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using api = Pcg;

/// <summary>
/// Implements a 64-bit PCG generator
/// </summary>
[Rng(nameof(Pcg64))]
public struct Pcg64 : IRandomNav<ulong>, IRandomSource<Pcg64,ulong>
{
    internal const ulong Multiplier = Pcg.DefaultMultiplier;

    [MethodImpl(Inline)]
    internal Pcg64(ulong s0, ulong? index = null)
        : this()
            => Init(s0, index ?? Pcg.DefaultIndex);

    internal ulong State;

    internal ulong Index;

    public Label Name => nameof(Pcg64);

    [MethodImpl(Inline)]
    public ulong Next()
        => api.next(ref this);

    /// <summary>
    /// Advances the generator to the next state and returns the prior state for consumption
    /// </summary>
    [MethodImpl(Inline)]
    ulong Step()
    {
        var prior = State;
        State =  prior*Multiplier + Index;
        return prior;
    }

    [MethodImpl(Inline)]
    public ulong Next(ulong max)
        => math.contract(Next(), max);

    [MethodImpl(Inline)]
    public ulong Next(ulong min, ulong max)
        => min + Next(max - min);

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

    [MethodImpl(Inline)]
    public void Advance(ulong count)
        => State = api.advance(State, count, Multiplier, Index);

    [MethodImpl(Inline)]
    public void Retreat(ulong count)
        => Advance(gmath.negate(count));

    void Init(ulong s0, ulong index)
    {
        if(index % 2 == 0)
            Errors.Throw(new ArgumentException($"Then index value {index} is not odd"));

        Index = (index << 1) | 1u;
        Step();
        State += s0;
        Step();
    }

    public override string ToString()
        => $"{State}[{Index}]";
}
