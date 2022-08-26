//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static sbyte modmul(sbyte a, sbyte b, sbyte m)
            => (sbyte)modmul((long)a, (long)b, (long)m);

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static byte modmul(byte a, byte b, byte m)
            => (byte)modmul((ulong)a, (ulong)b, (ulong)m);

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static short modmul(short a, short b, short m)
            => (short)modmul((long)a, (long)b, (long)m);

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static ushort modmul(ushort a, ushort b, ushort m)
            => (ushort)modmul((ulong)a, (ulong)b, (ulong)m);

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static int modmul(int a, int b, int m)
            => (int)modmul((long)a, (long)b, (long)m);

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static uint modmul(uint a, uint b, uint m)
            => (uint)modmul((ulong)a, (ulong)b, (ulong)m);

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static long modmul(long a, long b, long m)
            => (a*b) % m;

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static ulong modmul(ulong a, ulong b, ulong m)
            => (a*b) % m;
    }
}