//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;

    partial class bits
    {
        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior two bits of each 4-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op]
        public static byte bfly(N1 n, byte x)
            => bfly(x, Central8x4x2, 1);

        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior two bits of each 4-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op]
        public static ushort bfly(N1 n, ushort x)
            => bfly(x, Central16x4x2, 1);

        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior two bits of each 4-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op]
        public static uint bfly(N1 n, uint x)
            => bfly(x, Central32x4x2, 1);

        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior two bits of each 4-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op]
        public static ulong bfly(N1 n, ulong x)
            => bfly(x, Central64x4x2, 1);

        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior 2-bit segments
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op]
        public static byte bfly(N2 n, byte x)
            => bfly(x, Central8x8x4, 2);

        /// <summary>
        /// Effects a butterfly permutation on the bit source that swaps the interior 2-bit segments of each 8-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op]
        public static ushort bfly(N2 n, ushort x)
            => bfly(x, Central16x8x4, 2);

        /// <summary>
        /// Effects a butterfly permutation on the bit source that swaps the interior 2-bit segments of each 8-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op]
        public static uint bfly(N2 n, uint x)
            => bfly(x, Central32x8x4, 2);

        /// <summary>
        /// Effects a butterfly permutation on the bit source that swaps the interior 2-bit segments of each 8-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        [MethodImpl(Inline), Op]
        public static ulong bfly(N2 n, ulong x)
            => bfly(x, Central64x8x4,2);

        /// <summary>
        /// Effects a butterfly permutation on the bit source that swaps the interior 4-bit segments
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        /// <remarks> [0 1 2 3 ] -> [0 2 1 3] </remarks>
        [MethodImpl(Inline), Op]
        public static ushort bfly(N4 n, ushort x)
            => bfly(x, Central16x16x8, 4);

        /// <summary>
        /// Effects a butterfly permutation on the bit source that swaps the interior 4-bit segments of each 16-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        /// <remarks>
        /// [0 | 1 2 | 3 || 4 | 5 6 | 7] -> [0 | 2 1 | 3 || 4 | 6 5 | 7]
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static uint bfly(N4 n, uint x)
            => bfly(x, Central32x16x8,4);

        /// <summary>
        /// Effects a butterfly permutation on the bit source that swaps the interior 4-bit segments of each 16-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        /// <remarks>
        /// [0 | 1 2 | 3 || 4 | 5 6 | 7 || 8 | 9 A | B || C | D E | F] -> [0 | 2 1 | 3 || 4 | 6 5 | 7 || 8 | A 9 | B || C | E D | F]
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static ulong bfly(N4 n, ulong x)
            => bfly(x, Central64x16x8,4);

        /// <summary>
        /// Effects a butterfly permutation on the bit source that swaps the interior 8-bit segments
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        /// <remarks>[0 1 2 3] -> [0 2 1 3]</remarks>
        [MethodImpl(Inline), Op]
        public static uint bfly(N8 n, uint x)
            => bfly(x, Central32x32x16,8);

        /// <summary>
        /// Effects a butterfly permutation on the bit source that swaps the interior 8-bit segments of each 32-bit segment.
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        /// <remarks> [0 1 2 3 | 4 5 6 7] -> [0 2 1 3 | 4 6 5 7]</remarks>
        [MethodImpl(Inline), Op]
        public static ulong bfly(N8 n, ulong x)
            => bfly(x, Central64x32x16,8);

        /// <summary>
        /// Effects a butterfly permutation on the source that swaps the interior 16-bit segments
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        /// <remarks>[0 1 2 3] -> [0 2 1 3]</remarks>
        [MethodImpl(Inline), Op]
        public static ulong bfly(N16 n, ulong x)
            => bfly(x, Central64x64x32,16);

        /// <summary>
        /// Effects a butterfly permutation on the source value, predicated on a supplied mask and shift amount
        /// </summary>
        /// <param name="n">The interior segment width selector</param>
        /// <param name="x">The bit source</param>
        /// <remarks>The algorithm follows that of Arndt's Matters Computational, bitbutterfly.h.</remarks>
        [MethodImpl(Inline), Op]
        static T bfly<T>(T x, T mask, byte shift)
            where T : unmanaged
        {
            var y = gmath.and(x, mask);
            y = gmath.xors(y, shift);
            y = gmath.xor(gmath.and(y, mask), x);
            return y;
        }
    }
}