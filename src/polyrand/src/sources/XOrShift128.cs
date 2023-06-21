//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using G = XorShift128;

    /// <summary>
    /// Defines pseudorandom number generator
    /// </summary>
    [ApiHost]
    [Rng(nameof(XorShift128))]
    public struct XorShift128 : ISource<uint>
    {
        uint A;

        uint B;

        uint C;

        uint D;

        [MethodImpl(Inline)]
        public XorShift128(uint a, uint b, uint c, uint d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        [MethodImpl(Inline)]
        public XorShift128(ReadOnlySpan<uint> state)
        {
            A = skip(state,0);
            B = skip(state,1);
            C = skip(state,2);
            D = skip(state,3);
        }

        public Label Name
            => nameof(XorShift128);

        [MethodImpl(Inline), Op]
        public static uint next(ref G g)
            => g.Next();

        // From Marsaglia's Xorshift RNGs
        // The stream produced should have a period of 2^128 - 1
        [MethodImpl(Inline)]
        public uint Next()
        {
            var t = xorsl(A,15);
            A = B;
            B = C;
            C = D;
            D = grind(D,t);
            return D;
        }

        [MethodImpl(Inline), Op]
        static uint grind(uint d, uint t)
            => xorsr(d, 21) ^ xorsr(t, 4);

        [MethodImpl(Inline), Op]
        static uint xorsl(uint a, byte offset)
            => a^(a << offset);

        [MethodImpl(Inline), Op]
        static uint xorsr(uint a, byte offset)
            => a^(a >> offset);
    }
}