//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        /// <summary>
        /// [10000001]
        /// </summary>
        [BitMask("10000001")]
        public const byte Jsb8x8x1 = Lsb8x1x1 | Msb8x8x1;

        /// <summary>
        /// [10000001 10000001]
        /// </summary>
        [BitMask("10000001 10000001")]
        public const ushort Jsb16x8x1 = (ushort) Jsb8x8x1 | (ushort) Jsb8x8x1 << 8;

        /// <summary>
        /// [10000001 10000001 10000001 10000001]
        /// </summary>
        [BitMask("10000001 10000001 10000001 10000001")]
        public const uint Jsb32x8x1 = (uint) Jsb16x8x1 | (uint) Jsb16x8x1 << 16;

        /// <summary>
        /// [10000001 10000001 10000001 10000001 10000001 10000001 10000001 10000001]
        /// </summary>
        [BitMask("10000001 10000001 10000001 10000001 10000001 10000001 10000001 10000001")]
        public const ulong Jsb64x8x1 = (ulong) Jsb32x8x1 | (ulong) Jsb32x8x1 << 32;

        // ~ Jsb8x2 [11000011]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [11000011]
        /// </summary>
        [BitMask("11000011")]
        public const byte Jsb8x8x2 = Lsb8x8x2 | Msb8x8x2;

        /// <summary>
        /// [11000011 11000011]
        /// </summary>
        [BitMask("11000011 11000011")]
        public const ushort Jsb16x8x2 = (ushort) Jsb8x8x2 | (ushort) Jsb8x8x2 << 8;

        /// <summary>
        /// [11000011 11000011 11000011 11000011]
        /// </summary>
        [BitMask("11000011 11000011 11000011 11000011")]
        public const uint Jsb32x8x2 = (uint) Jsb16x8x2 | (uint) Jsb16x8x2 << 16;

        /// <summary>
        /// [11000011 11000011 11000011 11000011 11000011 11000011 11000011 11000011]
        /// </summary>
        [BitMask("11000011 11000011 11000011 11000011 11000011 11000011 11000011 11000011")]
        public const ulong Jsb64x8x2 = (ulong) Jsb32x8x2 | (ulong) Jsb32x8x2 << 32;

        // ~ Jsb8x3 [11100111]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [11100111]
        /// </summary>
        [BitMask("11100111")]
        public const byte Jsb8x8x3 = Lsb8x8x3 | Msb8x8x3;

        /// <summary>
        /// [11100111 11100111]
        /// </summary>
        [BitMask("11100111 11100111")]
        public const ushort Jsb16x8x3 = (ushort) Jsb8x8x3 | (ushort) Jsb8x8x3 << 8;

        /// <summary>
        /// [11100111 11100111 11100111 11100111]
        /// </summary>
        [BitMask("11100111 11100111 11100111 11100111")]
        public const uint Jsb32x8x3 = (uint) Jsb16x8x3 | (uint) Jsb16x8x3 << 16;

        /// <summary>
        /// [11100111 11100111 11100111 11100111 11100111 11100111 11100111 11100111]
        /// </summary>
        [BitMask("11100111 11100111 11100111 11100111 11100111 11100111 11100111 11100111")]
        public const ulong Jsb64x8x3 = (ulong) Jsb32x8x3 | (ulong) Jsb32x8x3 << 32;
    }
}