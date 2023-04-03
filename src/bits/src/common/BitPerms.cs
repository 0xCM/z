//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static math;

    using T = System.UInt32;

    /// <summary>
    /// Adapted from https://programming.sirrida.de/bit_perm.html
    /// </summary>
    [ApiHost]
    public struct BitPerms
    {
        [MethodImpl(Inline), Op]
        public static bit odd(ulong x)
            => (x & 1) != 0;

        // Greatest common divisor.
        [MethodImpl(Inline), Op]
        public static ulong gcd(ulong a, ulong b)
        {
            var t = z64;
            while (b != 0)
            {
                t = a % b;
                a = b;
                b = t;
            }
            return a;
        }

        /// <summary>
        /// Calculate multiplicative inverse, i.e. mul_inv(x)*x==1. The result is defined for all odd values of x.
        /// For even x we simply return 0.
        /// See Hacker's Delight, 10.16 "Exact division by constants" Multiplicative inverse modulo 2**bits by Newton's method.
        /// </summary>
        /// <param name="x"></param>
        public static ulong mul_inv(ulong x)
        {
            ulong xn,t;

            if (!odd(x))
                return 0;  // only defined for odd numbers

            xn = x;
            while (true)
            {
                t = x * xn;
                if (t == 1)
                    return xn;
                xn = xn * (2 - t);
            }
        }

        [MethodImpl(Inline)]
        static byte ld_bits(W8 w) => 3;

        [MethodImpl(Inline)]
        static byte lo_bit(W8 w) => 1;

        [MethodImpl(Inline)]
        static byte bits(W8 w) => sll((byte)1,ld_bits(w));

        [MethodImpl(Inline)]
        static byte ld_bits(W16 w) => 4;

        [MethodImpl(Inline)]
        static ushort lo_bit(W16 w) => 1;

        [MethodImpl(Inline)]
        static ushort bits(W16 w) => sll((ushort)1,ld_bits(w));

        [MethodImpl(Inline)]
        static byte ld_bits(W32 w) => 5;

        [MethodImpl(Inline)]
        static uint lo_bit(W32 w) => 1;

        [MethodImpl(Inline)]
        static uint bits(W32 w) => sll(1u,ld_bits(w));

        [MethodImpl(Inline)]
        static byte ld_bits(W64 w) => 6;

        [MethodImpl(Inline)]
        static ulong lo_bit(W64 w) => 1;

        [MethodImpl(Inline)]
        static ulong bits(W64 w) => sll(1ul,ld_bits(w));

        // Rotate left a complete word.
        // x: value to be rotated
        // rot: rotate count, negative values will rotate right
        // 1 cycle (should be if inlined)
        // A shift by >= bits is undefined by the C/C++ standard.
        // We take care for this case with the "& (bits - 1)" below.
        // For many CPUs this stunt is not neccessary.
        public static ulong rol(ulong x, ulong rot)
            => (x << (byte)(rot & (bits(w64) - 1))) | (x >> (byte)(negate(rot) & (bits(w64) - 1)));

        [Op]
        public static T tbm(T src, byte control)
        {
            switch (control & 0x1f)
            {
                case 0x00: return zero<T>();
                // Isolate lowest clear bit
                case 0x01: return and(src, not(inc(src)));
                // Isolate lowest clear bit and complement
                case 0x02: return and(not(src), inc(src));
                // Mask from lowest clear bit
                case 0x03: return xor(src, inc(src));

                case 0x04: return not(xor(src, inc(src)));
                case 0x05: return or(src, not(inc(src)));
                // Inverse mask from trailing ones
                case 0x06: return or(not(src), inc(src));
                case 0x07: return ones<T>();
                case 0x08: return and(src, inc(src));
                case 0x09: return src;
                case 0x0a: return inc(src);
                // Set lowest clear bit
                case 0x0b: return or(src, inc(src));
                case 0x0c: return not(or(src, inc(src)));
                case 0x0d: return dec(not(src));
                case 0x0e: return not(src);
                case 0x0f: return not(and(src, inc(src)));
                case 0x10: return zero<T>();
                // Mask from trailing zeros
                case 0x11: return and(not(src), inc(src));
                case 0x12: return and(src, negate(src));
                // Fill from lowest set bit
                case 0x13: return or(src, inc(src));
                case 0x14: return xor(src, negate(src));
                // Isolate lowest set bit and complement
                case 0x15: return or(not(src), dec(src));
                case 0x16: return or(src, negate(src));
                case 0x17: return ones<T>();
                case 0x18: return and(src, dec(src));
                case 0x19: return dec(src);
                case 0x1a: return src;
                case 0x1b: return or(src, dec(src));
                case 0x1c: return not(or(src, dec(src)));
                case 0x1d: return not(src);
                case 0x1e: return negate(src);
                case 0x1f: return not(and(src, dec(src)));
                default:
                    return 0;
            }
        }

        public static ulong tbm(ulong x, byte control)
        {
            switch (control & 0x1f)
            {
                case 0x00: return 0;
                // Isolate lowest clear bit
                case 0x01: return x & ~(x+1);
                // Isolate lowest clear bit and complement
                case 0x02: return ~x & (x+1);
                // Mask from lowest clear bit
                case 0x03: return x ^ (x+1);
                case 0x04: return ~(x ^ (x+1));
                case 0x05: return x | ~(x+1);
                case 0x06: return ~x | (x+1);
                case 0x07: return ones<ulong>();
                case 0x08: return x & (x+1);
                case 0x09: return x;
                case 0x0a: return x+1;
                case 0x0b: return x | (x+1);
                case 0x0c: return ~(x | (x+1));
                case 0x0d: return ~x-1;
                case 0x0e: return ~x;
                case 0x0f: return ~(x & (x+1));
                case 0x10: return 0;
                case 0x11: return ~x & (x-1);
                case 0x12: return x & negate(x);
                case 0x13: return x ^ (x-1);
                case 0x14: return x ^ negate(x);
                case 0x15: return ~x | (x-1);
                case 0x16: return x | negate(x);
                case 0x17: return ones<ulong>();
                case 0x18: return x & (x-1);
                case 0x19: return x-1;
                case 0x1a: return x;
                case 0x1b: return x | (x-1);
                case 0x1c: return ~(x | (x-1));
                case 0x1d: return ~x;
                case 0x1e: return negate(x);
                case 0x1f: return ~(x & (x-1));
                default:   return 0;  // this can not happen
            }
        }
    }
}
