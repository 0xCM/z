//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using L = BitMaskLiterals;

    public class t_bitmix : t_bits<t_bitmix>
    {
        public void bitmix_8()
            => bitmix_check<byte>();

        public void bitmix_16()
            => bitmix_check<ushort>();

        public void bitmix_32()
            => bitmix_check<uint>();

        public void bitmix_64()
            => bitmix_check<ulong>();

        /// <summary>
        /// Verifies even/odd bit-level interspersal
        /// </summary>
        /// <typeparam name="T">The primal type</typeparam>
        void bitmix_check<T>(T t = default)
            where T : unmanaged
        {
            var len = width<T>();

            for(var i=0; i<RepCount; i++)
            {
                var a = Random.Next<T>();
                var b = Random.Next<T>();

                // odd a/b interspersal
                var abOdd = BitStrings.scalar(gbits.mix(n1,a,b));

                // even a/b interspersal
                var abEven = BitStrings.scalar(gbits.mix(n0,a,b));

                // even/odd bits for a/b via bitstring
                var bsaEven = BitStrings.scalar(a).Even();
                var bsaOdd = BitStrings.scalar(a).Odd();
                var bsbEven = BitStrings.scalar(b).Even();
                var bsbOdd = BitStrings.scalar(b).Odd();

                // bitstring reference interspersal for the even bits
                var bsEven = bsaEven.Intersperse(bsbEven);
                Claim.yea(bsEven == abEven);

                // bitstring reference interspersal for the odd bits
                var bsOdd = bsaOdd.Intersperse(bsbOdd);
                Claim.yea(bsOdd == abOdd);
            }
        }

        // public void bitmix_outline()
        // {
        //     for(var i=0; i<RepCount; i++)
        //     {
        //         BitVector64 x = Random.BitVector(n64);
        //         BitVector32 y = (uint)BitMasks.gather(x, L.Even64);
        //         BitVector32 z = default;

        //         for(int j=0, k = 0; j<64; j+=2, k++)
        //             z[k] = x[j];

        //         Claim.eq(z.State, y.State);
        //     }

        //     for(var i=0; i<RepCount; i++)
        //     {
        //         BitVector64 x = Random.BitVector(n64);
        //         BitVector32 y = (uint)BitMasks.gather(x, L.Odd64);
        //         BitVector32 z = default;

        //         for(int j=1, k = 0; j<64; j+=2, k++)
        //             z[k] = x[j];

        //         Claim.eq(z.State, y.State);
        //     }
        // }

        string sb_mix_report()
        {
            var x = Random.Next<uint>();
            var y = Random.Next<uint>();
            var xE = bits.scatter(bits.gather(x,L.Even32), L.Even32);
            var xO = bits.scatter(bits.gather(x,L.Odd32), L.Even32);
            var yE = bits.scatter(bits.gather(y,L.Even32), L.Odd32);
            var yO = bits.scatter(bits.gather(y,L.Odd32), L.Odd32);
            var xEy = xE | yE;
            var xOy = xO | yO;
            var t = text.build();
            var sep = Chars.Colon;
            t.Label("x", sep, x.FormatBits(1));
            t.Label("x", sep, x.FormatBits(1));
            t.Label("y", sep, y.FormatBits(1));
            t.Label("xE", sep, xE.FormatBits(1));
            t.Label("xO", sep, xO.FormatBits(1));
            t.Label("yE", sep, yE.FormatBits(1));
            t.Label("yO", sep, yO.FormatBits(1));
            t.Label("xEy", sep, xEy.FormatBits(1));
            t.Label("xOy", sep, xOy.FormatBits(1));
            return t.ToString();
        }
    }
}