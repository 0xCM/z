//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using api = Pcg;

[Rng(nameof(Pcg32))]
public struct Pcg32 : IRandomNav<uint>, IRandomSource<Pcg32,ulong>
{
    [MethodImpl(Inline)]
    internal Pcg32(ulong s0, ulong? index = null)
        : this()
    {
        Init(s0, index ?? Pcg.DefaultIndex);
    }

    [MethodImpl(Inline)]
    internal Pcg32(ulong s0)
        : this()
    {
        Init(s0, Pcg.DefaultIndex);
    }

    internal ulong State;

    internal ulong Index;

    public Label Name => nameof(Pcg32);

    [MethodImpl(Inline)]
    public uint Next()
        => Pcg.grind32(Step());

    [MethodImpl(Inline)]
    public uint Next(uint max)
        => math.contract(Next(), max);

    [MethodImpl(Inline)]
    public uint Next(uint min, uint max)
        => min + Next(max - min);

    [MethodImpl(Inline)]
    public void Advance(ulong delta)
        => State = api.advance(State, delta, Multiplier, Index);

    [MethodImpl(Inline)]
    public void Retreat(ulong count)
        => Advance(gmath.negate(count));

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

    void Init(ulong s0, ulong index)
    {
        //The index must be odd; so at this point either an exception must be
        //thrown or the index must be manipulated; the latter was chosen
        index = index % 2 == 0 ? index + 1 : index;
        Index = (index << 1) | 1u;
        Step();
        State += s0;
        Step();
    }

    public override string ToString()
        => $"{State}[{Index}]";

    const ulong Multiplier = Pcg.DefaultMultiplier;

    [MethodImpl(Inline)]
    public ulong Next(ulong max)
        => Next((uint)max);

    [MethodImpl(Inline)]
    public ulong Next(ulong min, ulong max)
        => Next((uint)min, (uint)max);

    ulong ISource<ulong>.Next()
        => Next();
}
