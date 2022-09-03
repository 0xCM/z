//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines reference implementations for various bitfunction definitions
    /// </summary>
    [ApiHost]
    public readonly struct BitRefs
    {
        [Op]
        public static ref byte pack(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte pos, ref byte dst)
        {
            if(bit.test(x0, pos))
                dst = bits.enable(dst, 0);
            if(bit.test(x1, pos))
                dst = bits.enable(dst, 1);
            if(bit.test(x2, pos))
                dst = bits.enable(dst, 2);
            if(bit.test(x3, pos))
                dst = bits.enable(dst, 3);
            if(bit.test(x4, pos))
                dst = bits.enable(dst, 4);
            if(bit.test(x5, pos))
                dst = bits.enable(dst, 5);
            if(bit.test(x6, pos))
                dst = bits.enable(dst, 6);
            if(bit.test(x7, pos))
                dst = bits.enable(dst, 7);
            return ref dst;
        }

        /// <summary>
        /// Collects mask-identified source bits that are deposited to contiguous low bits in a target
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The scatter spec</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Closures(UnsignedInts)]
        public static T gather<T>(T src, T mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(gather(uint8(src), uint8(mask)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(gather(uint16(src), uint16(mask)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(gather(uint32(src), uint32(mask)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(gather(uint64(src), uint64(mask)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Collects mask-identified source bits that are deposited to
        /// contiguous low bits in the target
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">The mask that identifies the bits to gather</param>
        /// <remark>Algorithm adapted from Arndt, Matters Computational </remark>
        [MethodImpl(Inline), Op]
        static byte gather(byte src, byte mask)
        {
            var dst = (byte)0;
            var x = (byte)1;
            while (mask != 0)
            {
                byte i = (byte)(mask & math.negate(mask));
                mask ^= i;
                dst += (byte)((i & src) != 0 ? x : 0);
                x <<= 1;
            }
            return dst;
        }

        /// <summary>
        /// Collects mask-identified source bits that are deposited to
        /// contiguous low bits in the target
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">The mask that identifies the bits to gather</param>
        /// <remark>Algorithm adapted from Arndt, Matters Computational </remark>
        [MethodImpl(Inline), Op]
        static ushort gather(ushort src, ushort mask)
        {
            var dst = (ushort)0;
            var x = (ushort)1;
            while (mask != 0)
            {
                ushort i = (ushort)(mask & math.negate(mask));
                mask ^= i;
                dst += (ushort)((i & src) != 0 ? x : 0);
                x <<= 1;
            }
            return dst;
        }

        /// <summary>
        /// Collects mask-identified source bits that are deposited to
        /// contiguous low bits in the target
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">The mask that identifies the bits to gather</param>
        /// <remark>Algorithm adapted from Arndt, Matters Computational </remark>
        [MethodImpl(Inline), Op]
        static uint gather(uint src, uint mask)
        {
            var dst = 0u;
            var x = 1u;
            while (mask != 0)
            {
                var i = mask & math.negate(mask);
                mask ^= i;
                dst += ((i & src) != 0 ? x : 0);
                x <<= 1;
            }
            return dst;
        }

        /// <summary>
        /// Collects mask-identified source bits that are deposited to
        /// contiguous low bits in the target
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">The mask that identifies the bits to gather</param>
        /// <remark>Algorithm adapted from Arndt, Matters Computational </remark>
        [MethodImpl(Inline), Op]
        static ulong gather(ulong src, ulong mask)
        {
            var dst = 0ul;
            var x = 1ul;
            while (mask != 0)
            {
                var i = mask & math.negate(mask);
                mask ^= i;
                dst += ((i & src) != 0 ? x : 0);
                x <<= 1;
            }
            return dst;
        }

        // The algorithms for the functions below were taken from https://github.com/lemire/SIMDCompressionAndIntersection/blob/master/src/bitpacking.cpp
        [MethodImpl(Inline), Op]
        public static unsafe void part32x4(uint src, Span<byte> dst)
        {
            for(int i = 0, j=0; i<32; i +=4, j++)
                dst[j] = (byte)(((src) >> i) % (1u << 4));
        }

        [MethodImpl(Inline), Op]
        public static unsafe void unpack32x4(uint* pSrc, uint* pDst)
        {
            for(var inner = 0; inner < 32; inner +=4)
                *(pDst++) = ((*pSrc) >> inner) % (1u << 4);
        }

        [MethodImpl(Inline), Op]
        public static unsafe void fastunpack4(uint* pSrc, uint* pDst)
        {
           for(var outer = 0; outer<4; ++outer)
                unpack32x4(pSrc++,pDst);
        }


        /// <summary>
        /// From the book "Hackers Delight"
        /// </summary>
        [MethodImpl(Inline), Op]
        public static uint compress(uint x, uint m)
        {
            uint mk, mp, mv, t;
            int i;

            x = x & m;           // Clear irrelevant bits.
            mk = ~m << 1;        // We will count 0's to right.

            for (i = 0; i<5; i++)
            {
                mp = mk ^ (mk << 1);              // Parallel suffix.
                mp = mp ^ (mp << 2);
                mp = mp ^ (mp << 4);
                mp = mp ^ (mp << 8);
                mp = mp ^ (mp << 16);
                mv = mp & m;                      // Bits to move.
                m = m ^ mv | (mv >> (1 << i));    // Compress m.
                t = x & mv;
                x = x ^ t | (t >> (1 << i));      // Compress x.
                mk = mk & ~mp;
            }
            return x;
        }

         /// <summary>
        /// From the book "Hackers Delight"
        /// </summary>
        [MethodImpl(Inline), Op]
        public static uint compress_left(uint x, uint m)
        {
            uint mk, mp, mv, t;
            int i;

            x = x & m;           // Clear irrelevant bits.
            mk = ~m >> 1;        // We will count 0's to left.

            for (i = 0; i < 5; i++)
            {
                mp = mk ^ (mk >> 1);              // Parallel prefix.
                mp = mp ^ (mp >> 2);
                mp = mp ^ (mp >> 4);
                mp = mp ^ (mp >> 8);
                mp = mp ^ (mp >> 16);
                mv = mp & m;                      // Bits to move.
                m = m ^ mv | (mv << (1 << i));    // Compress m.
                t = x & mv;
                x = x ^ t | (t << (1 << i));      // Compress x.
                mk = mk & ~mp;
            }
            return x;
        }

        [MethodImpl(Inline), Op]
        public static uint SAG(uint x, uint m)
            => compress_left(x, m) | compress(x, ~m);
    }
}