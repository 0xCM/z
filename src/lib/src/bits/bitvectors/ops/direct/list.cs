//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Enumerates each and every 8-bit bitvector exactly once
        /// </summary>
        /// <param name="n">The bitness selector</param>
        public static IEnumerable<BitVector8> list(N8 n)
        {
            var bv = BitVector8.Zero;
            do
                yield return bv;
            while(++bv);
        }

        /// <summary>
        /// Enumerates each nonempty 8-bit bitvector
        /// </summary>
        public static IEnumerable<BitVector8> nonempty(N8 n)
        {
            var bv = BitVector8.One;
            do
                yield return bv;
            while(++bv);
        }

        /// <summary>
        /// Enumerates all 16-bit bitvectors whose width is less than or equal to a specified maximum
        /// </summary>
        /// <param name="n">The bitness selector</param>
        public static IEnumerable<BitVector16> list(N16 n, int maxwidth)
        {
            var maxval = 1 << math.min(maxwidth,16);
            var bv = BitVector16.Zero;
            while(bv < maxval)
                yield return bv++;
        }

        /// <summary>
        /// Enumerates the 8-bit Gray codes
        /// </summary>
        /// <param name="n">The bitness selector</param>
        public static IEnumerable<BitVector8> gray(N8 n)
        {
            foreach(var x in list(n))
                yield return x ^ (x >> 1);
        }

        /// <summary>
        /// Enumerates all 32-bit bitvectors for which the effective width is less than or equal to a specified maximum
        /// </summary>
        public static IEnumerable<BitVector32> list(N32 n, int maxwidth)
        {
            var maxval = Pow2.pow(maxwidth);
            var bv = BitVector32.Zero;
            while(bv < maxval)
                yield return bv++;
        }

        /// <summary>
        /// Enumerates all 64-bit bitvectors for which the effective width is less than or equal to a specified maximum
        /// </summary>
        public static IEnumerable<BitVector64> list(N64 n, int maxwidth)
        {
            var maxval = Pow2.pow(maxwidth);
            var bv = BitVector64.Zero;
            while(bv < maxval)
                yield return bv++;
        }
    }
}