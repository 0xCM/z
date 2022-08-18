//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using G = XorShift256;

    /// <summary>
    /// Defines pseudorandom number generator
    /// </summary>
    /// <remarks> Core algorithm taken from http://xoshiro.di.unimi.it/xoshiro256starstar.c</remarks>
    [ApiHost]
    [Rng(nameof(XorShift256))]
    public struct XorShift256 : IRandomSource<XorShift256,ulong>
    {
        ulong S0;

        ulong S1;

        ulong S2;

        ulong S3;

        [MethodImpl(Inline), Op]
        public static G create(ReadOnlySpan<ulong> seed)
            => new G(seed);

        [MethodImpl(Inline), Op]
        public static ulong next(ref G rng)
        {
            var next = math.rotl(rng.S1 * 5, 7) * 9;
            var t = rng.S1 << 17;
            rng.S2 ^= rng.S0;
            rng.S3 ^= rng.S1;
            rng.S1 ^= rng.S2;
            rng.S0 ^= rng.S3;
            rng.S2 ^= t;
            rng.S3 = math.rotl(rng.S3, 45);
            return next;
        }

        [MethodImpl(Inline), Op]
        public static ulong next(ref G rng, ulong max)
            => math.contract(next(ref rng), max);

        [MethodImpl(Inline), Op]
        public static ulong next(ref G rng, ulong min, ulong max)
            => min + next(ref rng, max - min);

        [MethodImpl(Inline), Op]
        public static void jump(ref G rng, ReadOnlySpan<ulong> J)
        {
            var count = J.Length;
            var s0 = 0UL;
            var s1 = 0UL;
            var s2 = 0UL;
            var s3 = 0UL;
            for(var i = 0; i<count; i++)
                for(var b = 0; b<64; b++)
                {
                    var j = skip(J,i) & 1UL << b;
                    if (j != 0)
                    {
                        s0 ^= rng.S0;
                        s1 ^= rng.S1;
                        s2 ^= rng.S2;
                        s3 ^= rng.S3;
                    }
                    next(ref rng);
                }

            rng.S0 = s0;
            rng.S1 = s1;
            rng.S2 = s2;
            rng.S3 = s3;
        }

        [MethodImpl(Inline)]
        internal XorShift256(ReadOnlySpan<ulong> seed)
        {
            S0 = skip(seed, 0);
            S1 = skip(seed, 1);
            S2 = skip(seed, 2);
            S3 = skip(seed, 3);
            jump(ref this, J128);
        }

        [MethodImpl(Inline)]
        public ulong Next()
            => next(ref this);

        public Label Name
            => nameof(XorShift256);

        [MethodImpl(Inline)]
        public ulong Next(ulong max)
            => next(ref this,max);

        [MethodImpl(Inline)]
        public ulong Next(ulong min, ulong max)
            => next(ref this, min, max);

        /* When supplied to the jump function, it is equivalent
        to 2^128 calls to next(); it can be used to generate 2^128
        non-overlapping subsequences for parallel computations. */
        static ulong[] J128 {get;} = new ulong[]{0x180ec6d33cfd0aba, 0xd5a61266f0c9392c, 0xa9582618e03fc9aa, 0x39abdc4529b1661c};

        /* When supplied ot the jump function, t is equivalent to
        2^192 calls to next(); it can be used to generate 2^64 starting points,
        from each of which jump() will generate 2^64 non-overlapping
        subsequences for parallel distributed computations. */
        static ulong[] J192 {get;} = new ulong[]{0x76e15d3efefdcbbf, 0xc5004e441c522fb3, 0x77710069854ee241, 0x39109bb02acbe635};
    }
}