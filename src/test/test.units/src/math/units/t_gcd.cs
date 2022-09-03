//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_gcd : t_gmath<t_gcd>
    {
        public void gcdbin_8u()
            => gcdbin_check((byte)2, (byte)225);

        public void gcdbin_16u()
            => gcdbin_check((ushort)2, (ushort)22000);

        public void gcdbin_8u_bench()
            => gcdbin_bench((byte)2, (byte)225);

        public void gcdbin_16u_bench()
            => gcdbin_bench((ushort)2, (ushort)22000);

        public void gcdbin_32u()
            => gcdbin_check(2u, 500000u);

        public void gcdbin_64u_check()
            => gcdbin_check(2ul, 500000ul);

        public void gcdbin_32u_bench()
            => gcdbin_bench(2u, 500000u);

        public void gcdbin_64u_bench()
            => gcdbin_bench(2ul, 500000ul);

        void gcdbin_check<T>(T min, T max)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var a = Random.Next(min, max);
                var b = Random.Next(min, max);
                var c = gmath.gcdbin(a,b);
                var d = gmath.gcd(a,b);
                Claim.eq(c,d);
            }
        }

        void gcdbin_bench<T>(T min, T max, SystemCounter subject = default, SystemCounter compare = default)
            where T : unmanaged
        {
            var last = default(T);
            for(var i=0; i<OpCount; i++)
            {
                var a = Random.Next(min, max);
                var b = Random.Next(min, max);

                subject.Start();
                last = gmath.gcdbin(a,b);
                subject.Stop();

                compare.Start();
                last = gmath.gcd(a,b);
                compare.Stop();
            }

            ReportBenchmark($"gcdbin{TypeIdentity.numeric<T>()}", OpCount,subject);
            ReportBenchmark($"gcd{TypeIdentity.numeric<T>()}", OpCount,compare);
        }

        /// <summary>
        /// Extended binary gcd
        /// </summary>
        /// <param name="a">Must be a power of 2</param>
        /// <param name="b">Must be odd</param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <remarks>Adapted from http://www.hackersdelight.org/MontgomeryMultiplication.pdf</remarks>
        static void binxgcd(ulong a, ulong b, out ulong u, out ulong v)
        {
            if(!math.ispow2(a))
                throw new Exception($"{a} is not a power of 2");

            if(!gmath.odd(b))
                throw new Exception($"{b} is not odd");

            u = 1ul;
            v = 0ul;

            // Note that alpha is even and beta is odd.
            var alpha = a;
            var beta = b;

            // The invariant maintained from here on is: 2a = u*2*alpha - v*beta.
            while (a > 0)
            {
                a = a >> 1;
                if ((u & 1) == 0)
                {
                    // Delete a common factor of 2 in u and v
                    u = u >> 1;
                    v = v >> 1;
                }
                else
                {
                    // We want to set u = (u + beta) >> 1, but that can overflow, so we use Dietz's method.
                    u = ((u ^ beta) >> 1) + (u & beta);
                    v = (v >> 1) + alpha;
                }
            }
        }


        /// <summary>
        /// Divides (x || y) by z, for 64-bit integers x, y,
        /// and z, giving the remainder (modulus) as the result.
        /// Must have x < z (to get a 64-bit result). This is
        /// checked for.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <remarks>Adapted from http://www.hackersdelight.org/MontgomeryMultiplication.pdf</remarks>
        static ulong mod(ulong x, ulong y, ulong z)
        {
            if (x >= z)
                throw new Exception("Bad call to modul64, must have x < z.");

            for (var i = 1; i <= 64; i++)
            {
                // All 1's if x(63) = 1.
                var t = (ulong)((long)x >> 63);

                // Shift x || y left
                x = (x << 1) | (y >> 63);

                // one bit.
                y = y << 1;

                if ((x | t) >= z)
                {
                    x = x - z;
                    y = y + 1;
                }
            }
            return x; // Quotient is y.
        }
    }
}