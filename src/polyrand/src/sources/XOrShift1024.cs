//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Implements an XOrShift generator
    /// </summary>
    /// <remarks>
    /// Core algorithms taken from the paper: https://arxiv.org/pdf/1402.6246.pdf
    /// </remarks>
    [Rng(nameof(XorShift256))]
    public class XorShift1024 : IRandomSource<ulong>
    {
        readonly ulong[] State;

        int P;

        public XorShift1024(ulong[] seed)
        {
            Require.invariant(seed.Length >= 16, () => $"Not enough seed! 1024 bits = 128 bytes = 16 longs are required");
            State = seed;
        }

        public XorShift1024(Span<byte> seed)
        {
            Require.invariant(seed.Length >= 128, () => $"Not enough seed! 1024 bits = 128 bytes are required");
            State = recover<ulong>(seed).ToArray();
        }

        public Label Name
            => nameof(XorShift1024);

        public void Jump()
        {
            ulong[] t = new ulong[16];

            for(int i = 0; i < JT.Length; i++)
            for(int b = 0; b < 64; b++)
            {
                if ( (JT[i] & 1ul << b) != 0)
                    for(int j = 0; j < 16; j++)
                        t[j] ^= State[(j + P) & 15];
                Next();
            }

            for(int j = 0; j < 16; j++)
                State[(j + P) & 15] = t[j];
        }

        [MethodImpl(Inline)]
        public ulong Next()
        {
            ulong s0 = State[P];
            ulong s1 = State[P = (P + 1) & 15];
            s1 ^= s1 << 31; // a
            State[P] = s1 ^ s0 ^ (s1 >> 11) ^ (s0 >> 30); // b,c
            return State[P] * Multiplier;
        }

        [MethodImpl(Inline)]
        public ulong Next(ulong max)
            => math.contract(Next(), max);

        [MethodImpl(Inline)]
        public ulong Next(ulong min, ulong max)
            => min + Next(max - min);

        /// <summary>
        /// The jump table of predetermined constants to facilitate an efficient way
        /// to simulate calls to "Next()"
        /// </summary>
        ulong[] JT {get;} = new ulong[]
        {   0x84242f96eca9c41d, 0xa3c65b8776f96855, 0x5b34a39f070b5837,0x4489affce4f31a1e,
            0x2ffeeb0a48316f40, 0xdc2d9891fe68c022, 0x3659132bb12fea70, 0xaac17d8efa43cab8,
            0xc4cb815590989b13, 0x5ee975283d71c93b, 0x691548c86c1bd540, 0x7910c41d10a1e6a5,
            0x0b5fc64563b3e2a8, 0x047f7684e9fc949d, 0xb99181f2d8f685ca, 0x284600e3f30e38c3
        };

        /// <summary>
        /// Predetermined constant by which every generated value is multiplied
        /// </summary>
        const ulong Multiplier = 1181783497276652981;
    }
}