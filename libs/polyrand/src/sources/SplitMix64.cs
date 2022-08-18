//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using G = SplitMix64;

    /// <summary>
    /// Implements a 64-bit random number generator
    /// </summary>
    /// <remarks>Algorithms take from https://github.com/lemire/testingRNG/blob/master/source/splitmix64.h</remarks>
    [ApiHost, Rng(nameof(SplitMix64))]
    public struct SplitMix64 : IRandomSource<SplitMix64,ulong>
    {
        ulong State;

        [MethodImpl(Inline)]
        internal SplitMix64(ulong state)
            => State = state;

        public Label Name => nameof(SplitMix64);

        [MethodImpl(Inline)]
        public ulong Next()
            => next(ref this);

        [MethodImpl(Inline)]
        public ulong Next(ulong max)
            => next(ref this, max);

        [MethodImpl(Inline)]
        public ulong Next(ulong min, ulong max)
            => next(ref this, min, max);

        [MethodImpl(Inline), Op]
        static ulong next(ref G g)
        {
            var  z = g.State + X1;
            z = (z ^ (z >> 30)) * X2;
            z = (z ^ (z >> 27)) * X3;
            z = z ^ (z >> 31);
            g.State += X1;
            return z;
        }

        [MethodImpl(Inline), Op]
        static ulong next(ref G g, ulong max)
            => math.contract(next(ref g), max);

        [MethodImpl(Inline), Op]
        static ulong next(ref G g, ulong min, ulong max)
            => min + math.contract(next(ref g), max - min);

        const ulong X1 = 0x9E3779B97F4A7C15;

        const ulong X2 = 0xBF58476D1CE4E5B9;

        const ulong X3 = 0x94D049BB133111EB;
    }
}