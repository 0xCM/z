//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Pow2
    {
        /// <summary>
        /// Computes 2^i where i is an integer value in the interval [0,63]
        /// </summary>
        /// <param name="i">The exponent</param>
        [MethodImpl(Inline), Op]
        public static ulong pow(byte i)
            => 1ul << i;

        /// <summary>
        /// Computes 2^i where i is an integer value in the interval [0,63]
        /// </summary>
        /// <param name="i">The exponent</param>
        [MethodImpl(Inline), Op]
        public static ulong pow(int i)
            => pow((byte)i);

        [MethodImpl(Inline), Op]
        public static byte pow8u(byte i)
            => (byte)pow(i);

        [MethodImpl(Inline), Op]
        public static ushort pow16u(byte i)
            => (ushort)pow(i);

        [MethodImpl(Inline), Op]
        public static uint pow32u(byte i)
            => (uint)pow(i);

        [MethodImpl(Inline), Op]
        public static ulong pow64u(byte i)
            => pow(i);

        [MethodImpl(Inline), Op]
        public static byte pow(Log2x2 src)
            => pow8u((byte)src);

        [MethodImpl(Inline), Op]
        public static byte pow(Log2x3 src)
            => pow8u((byte)src);

        [MethodImpl(Inline), Op]
        public static byte pow(Log2x4 src)
            => pow8u((byte)src);

        [MethodImpl(Inline), Op]
        public static byte pow(Log2x8 src)
            => pow8u((byte)src);

        [MethodImpl(Inline), Op]
        public static ushort pow(Log2x16 src)
            => pow16u((byte)src);

        [MethodImpl(Inline), Op]
        public static uint pow(Log2x32 src)
            => pow32u((byte)src);

        [MethodImpl(Inline), Op]
        public static ulong pow(Log2x64 src)
            => pow64u((byte)src);
    }
}