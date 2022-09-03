//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Bmi2;
    using static System.Runtime.Intrinsics.X86.Bmi2.X64;
    using static LimitValues;
    using static sys;

    partial struct Math128
    {
        /// <summary>
        /// Computes the unsigned 64-bit product of two unsigned 32-bit integers
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mul]
        public static unsafe ulong mul(uint x, uint y)
        {
            var dst = 0u;
            return (((ulong)MultiplyNoFlags(x, y, gptr(dst))) << 32) | dst;
        }

        [MethodImpl(Inline), Mul]
        public static unsafe void mul(uint a, uint b, out uint lo, out uint hi)
        {
           lo = 0u;
           hi = MultiplyNoFlags(a,b, gptr(lo));
        }

        [MethodImpl(Inline), Mul]
        public static unsafe void mul(ulong a, ulong b, out ulong lo, out ulong hi)
        {
           lo = 0ul;
           hi = MultiplyNoFlags(a,b, gptr(lo));
        }

        [MethodImpl(Inline), Mul]
        public static ref Pair<uint> mul(uint a, uint b, out Pair<uint> dst)
        {
            mul(a,b, out dst.Left, out dst.Right);
            return ref dst;
        }

        [MethodImpl(Inline), Mul]
        public static unsafe ref uint128 mul(ref uint128 dst, in uint128 src)
        {
            dst.Hi = MultiplyNoFlags(src.Lo, src.Hi, gptr(dst.Lo));
            return ref dst;
        }

        [MethodImpl(Inline), Mul]
        public static ref uint128 mul(ulong x, ulong y, out uint128 dst)
        {
            mul(x, y, out dst.Lo, out dst.Hi);
            return ref dst;
        }

        /// <summary>
        /// Computes the full 128-bit product between two unsigned 64-bit integers
        /// </summary>
        /// <param name="src">The source integers</param>
        /// <param name="dst">The multiplication result, partitioned into lo/hi parts</param>
        [MethodImpl(Inline), Mul]
        public static unsafe ref Pair<ulong> mul(in Pair<ulong> src, ref Pair<ulong> dst)
        {
            dst.Right = MultiplyNoFlags(src.Left, src.Right, gptr(dst.Left));
            return ref dst;
        }

        /// <summary>
        /// Computes the full 128-bit product between two unsigned 64-bit integers
        /// </summary>
        /// <param name="src">The source integers</param>
        /// <param name="dst">The multiplication result, partitioned into lo/hi parts</param>
        [MethodImpl(Inline), Mul]
        public static Pair<ulong> mul(in Pair<ulong> src)
        {
            var dst = default(Pair<ulong>);
            mul(src, ref dst);
            return dst;
        }

        /// <summary>
        /// Computes the full 64-bit product between two unsigned 32-bit integers
        /// </summary>
        /// <param name="src">The source integers</param>
        /// <param name="dst">The multiplication result, partitioned into lo/hi parts</param>
        [MethodImpl(Inline), Mul]
        public static unsafe ref Pair<uint> mul(in Pair<uint> src, ref Pair<uint> dst)
        {
            dst.Right = MultiplyNoFlags(src.Left, src.Right, gptr(dst.Left));
            return ref dst;
        }

        /// <summary>
        /// Computes the full 64-bit product between two unsigned 32-bit integers
        /// </summary>
        /// <param name="src">The source integers</param>
        /// <param name="dst">The multiplication result, partitioned into lo/hi parts</param>
        [MethodImpl(Inline), Mul]
        public static Pair<uint> mul(in Pair<uint> src)
        {
            var dst = default(Pair<uint>);
            mul(src, ref dst);
            return dst;
        }

        /// <summary>
        /// Computes the full 128-bit product between two unsigned 64-bit integers
        /// </summary>
        /// <param name="src">The source integers</param>
        /// <param name="dst">The multiplication result, partitioned into lo/hi parts</param>
        [MethodImpl(Inline), Mul]
        public static ref Pair<ulong> mul(in ulong a, in ulong b, ref Pair<ulong> dst)
        {
            mul((a,b), ref dst);
            return ref dst;
        }

        /// <summary>
        /// Computes the full 128-bit products between corresponding 64-bit span elements
        /// </summary>
        /// <param name="a">The left operands</param>
        /// <param name="a">The right operands</param>
        /// <param name="dst">The multiplication result, partitioned into lo/hi parts</param>
        [MethodImpl(Inline), Mul]
        public static void mul(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, Span<Pair<ulong>> dst)
        {
            var count = math.min(math.min(a.Length, b.Length), dst.Length);
            for(var i=0u; i<count; i++)
                mul(skip(first(a), i), skip(in first(b), i), ref seek(first(dst), i));
        }

        /// <summary>
        /// Computes the full 128-bit products between 64-bit span elements and a 64-bit scalar
        /// </summary>
        /// <param name="src">The left operands</param>
        /// <param name="scale">The scalar value</param>
        /// <param name="dst">The multiplication result, partitioned into lo/hi parts</param>
        [MethodImpl(Inline), Mul]
        public static void mul(ReadOnlySpan<ulong> src, ulong scale, Span<Pair<ulong>> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                mul(skip(first(src), i), scale, ref seek(first(dst), i));
        }

        /// <summary>
        /// 64x64 -> 128 multiplication, reference implementation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>
        /// Taken from https://github.com/chfast/intx/blob/master/include/intx/int128.hpp
        /// </returns>
        [MethodImpl(Inline), Op]
        public static Pair<ulong> mul(ulong x, ulong y)
        {
            var xl = x & Max32u;
            var xh = x >> 32;
            var yl = y & Max32u;
            var yh = y >> 32;

            var t0 = xl * yl;
            var t1 = xh * yl;
            var t2 = xl * yh;
            var t3 = xh * yh;

            var u1 = t1 + (t0 >> 32);
            var u2 = t2 + (u1 & Max32u);

            var lo = (u2 << 32) | (t0 & Max32u);
            var hi = t3 + (u2 >> 32) + (u1 >> 32);
            return (lo,hi);
        }

        [MethodImpl(Inline), MulHi]
        public static ulong mulhi(uint x, uint y)
            => MultiplyNoFlags(x,y);

        [MethodImpl(Inline), MulHi]
        public static ulong mulhi(ulong x, ulong y)
            => MultiplyNoFlags(x,y);

        [MethodImpl(Inline), MulLo]
        public static unsafe uint mullo(uint x, uint y)
        {
            var lo = 0u;
            MultiplyNoFlags(x, y, gptr(lo));
            return lo;
        }

        [MethodImpl(Inline), MulLo]
        public static unsafe ulong mullo(ulong x, ulong y)
        {
            var lo = 0ul;
            MultiplyNoFlags(x, y, &lo);
            return lo;
        }
    }
}