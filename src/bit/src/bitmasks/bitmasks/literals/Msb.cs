//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        // ~ 8x1: The greatest bit of each 8-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [10000000]
        /// </summary>
        [BitMask ("10000000")]
        public const byte Msb8x8x1 = 1 << 7;

        /// <summary>
        /// [10000000 10000000]
        /// </summary>
        [BitMask ("10000000 10000000")]
        public const ushort Msb16x8x1 = (ushort) Msb8x8x1 | (ushort) Msb8x8x1 << 8;

        /// <summary>
        /// [10000000 10000000 10000000 10000000]
        /// </summary>
        [BitMask ("10000000 10000000 10000000 10000000")]
        public const uint Msb32x8x1 = (uint) Msb16x8x1 | (uint) Msb16x8x1 << 16;

        /// <summary>
        /// [10000000 10000000 10000000 10000000 10000000 10000000 10000000 10000000]
        /// </summary>
        [BitMask ("10000000 10000000 10000000 10000000 10000000 10000000 10000000 10000000")]
        public const ulong Msb64x8x1 = (ulong) Msb32x8x1 | (ulong) Msb32x8x1 << 32;

        // ~ Msb16x1: The greatest bit of each 16-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [10000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000")]
        public const ushort Msb16x16x1 = 1 << 15;

        /// <summary>
        /// [10000000 00000000 10000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000 10000000 00000000")]
        public const uint Msb32x16x1 = (uint) Msb16x16x1 | (uint) Msb16x16x1 << 16;

        /// <summary>
        /// [10000000 00000000 10000000 00000000 10000000 00000000 10000000 00000000]
        /// </summary>
        [BitMask ("10000000 00000000 10000000 00000000 10000000 00000000 10000000 00000000")]
        public const ulong Msb64x16x1 = (ulong) Msb32x16x1 | (ulong) Msb32x16x1 << 32;

        // ~ 2x1: The most signifcant bit of each 2-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [1010]
        /// </summary>
        [BitMask ("1010")]
        public const byte Msb4x2x1 = 0b1010;

        /// <summary>
        /// [010101]
        /// </summary>
        [BitMask ("010101")]
        public const byte Msb6x2x1 = Msb4x2x1 | 1 << 4;

        /// <summary>
        /// [10101010]
        /// </summary>
        [BitMask ("10101010")]
        public const byte Msb8x2x1 = Lsb8x2x1 << 1;

        /// <summary>
        /// [10 10101010]
        /// </summary>
        [BitMask ("10 10101010")]
        public const ushort Msb10x2x1 = (ushort)Msb8x2x1 | 1 << 9;

        /// <summary>
        /// [1010 10101010]
        /// </summary>
        [BitMask ("1010 10101010")]
        public const ushort Msb12x2x1 = Msb10x2x1 | 1 << 11;

        /// <summary>
        /// [101010 10101010]
        /// </summary>
        [BitMask ("101010 10101010")]
        public const ushort Msb14x2x1 = Msb12x2x1 | 1 << 13;

        /// <summary>
        /// [10101010 10101010]
        /// </summary>
        [BitMask ("10101010 10101010")]
        public const ushort Msb16x2x1 = (ushort)Msb8x2x1 | (ushort)Msb8x2x1 << 8;

        /// <summary>
        /// [10 10101010 10101010]
        /// </summary>
        [BitMask ("10 10101010 10101010")]
        public const uint Msb18x2x1 = Lsb8x2x1 << 1;

        /// <summary>
        /// [10101010 10101010 10101010 10101010]
        /// </summary>
        [BitMask ("10101010 10101010 10101010 10101010")]
        public const uint Msb32x2x1 = (uint)Msb16x2x1 | (uint)Msb16x2x1 << 16;

        /// <summary>
        /// [10101010 10101010 10101010 10101010 10101010 10101010 10101010 10101010]
        /// </summary>
        public const ulong Msb64x2x1 = Lsb64x2x1 << 1;

        // ~ 3x1: The most signifcant bit of each 3-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [0b100]
        /// </summary>
        public const byte Msb3x1x1 = 1 << 2;

        /// <summary>
        /// [0b100_100]
        /// </summary>
        public const byte Msb6x3x1 = Lsb6x3x1 << 2;

        /// <summary>
        /// [0b100_100_100]
        /// </summary>
        public const ushort Msb9x3x1 = Lsb9x3x1 << 2;

        /// <summary>
        /// [0b100_100_100_100]
        /// </summary>
        public const ushort Msb12x3x1 = Lsb12x3x1 << 2;

        /// <summary>
        /// [0b100_100_100_100_100]
        /// </summary>
        public const ushort Msb15x3x1 = Lsb15x3x1 << 2;

        /// <summary>
        /// [0b100_100_100_100_100_100]
        /// </summary>
        public const uint Msb18x3x1 = Lsb18x3x1 << 2;

        /// <summary>
        /// [0b100_100_100_100_100_100_100]
        /// </summary>
        public const uint Msb21x3x1 = Lsb21x3x1 << 2;

        // ~ 4x1: The greatest bit of each 4-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [10001000]
        /// </summary>
        public const byte Msb8x4x1 = 0b10001000;

        /// <summary>
        /// [10001000 10001000]
        /// </summary>
        public const ushort Msb16x4x1 = (ushort) Msb8x4x1 | (ushort) Msb8x4x1 << 8;

        /// <summary>
        /// [10001000 10001000 10001000 10001000]
        /// </summary>
        public const uint Msb32x4x1 = (uint) Msb16x4x1 | (uint) Msb16x4x1 << 16;

        /// <summary>
        /// [10001000 10001000 10001000 10001000 10001000 10001000 10001000 10001000]
        /// </summary>
        public const ulong Msb64x4x1 = (ulong) Msb32x4x1 | (ulong) Msb32x4x1 << 16;

        // ~ 32x1: The greatest bit of each 32-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [10000000 00000000 00000000 0000000]
        /// </summary>
        public const uint Msb32x32x1 = 1u << 31;

        /// <summary>
        /// [10000000 00000000 00000000 0000000 10000000 00000000 00000000 0000000]
        /// </summary>
        public const ulong Msb64x32x1 = (ulong) Msb32x32x1 | (ulong) Msb32x32x1 << 32;

        // ~ 64x1: The greatest bit of each 64-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [10000000 00000000 00000000 0000000 00000000 00000000 00000000 0000000]
        /// </summary>
        public const ulong Msb64x64x1 = 1ul << 63;

        // ~ Msb8x2: The greatest 2 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [11000000]
        /// </summary>
        public const byte Msb8x8x2 = 0b11000000;

        /// <summary>
        /// [11000000]
        /// </summary>
        public const ushort Msb16x8x2 = (ushort) Msb8x8x2 | (ushort) Msb8x8x2 << 8;

        /// <summary>
        /// [11000000]
        /// </summary>
        public const uint Msb32x8x2 = (uint) Msb16x8x2 | (uint) Msb16x8x2 << 16;

        /// <summary>
        /// [11000000]
        /// </summary>
        public const ulong Msb64x8x2 = (ulong) Msb32x8x2 | (ulong) Msb32x8x2 << 32;

        // ~ Msb8x3: The greatest 3 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [11100000]
        /// </summary>
        public const byte Msb8x8x3 = 0b11100000;

        /// <summary>
        /// [11100000 11100000]
        /// </summary>
        public const ushort Msb16x8x3 = (ushort) Msb8x8x3 | (ushort) Msb8x8x3 << 8;

        /// <summary>
        /// [11100000 11100000 11100000 11100000]
        /// </summary>
        public const uint Msb32x8x3 = (uint) Msb16x8x3 | (uint) Msb16x8x3 << 16;

        /// <summary>
        /// [11100000 11100000 11100000 11100000 11100000 11100000 11100000 11100000]
        /// </summary>
        public const ulong Msb64x8x3 = (ulong) Msb32x8x3 | (ulong) Msb32x8x3 << 32;

        // ~ Msb8x4: The greatest 4 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [11110000]
        /// </summary>
        public const byte Msb8x8x4 = 0b11110000;

        /// <summary>
        /// [11110000 11110000]
        /// </summary>
        public const ushort Msb16x8x4 = (ushort) Msb8x8x4 | (ushort) Msb8x8x4 << 8;

        /// <summary>
        /// [11110000 11110000 11110000 11110000]
        /// </summary>
        public const uint Msb32x8x4 = (uint) Msb16x8x4 | (uint) Msb16x8x4 << 16;

        /// <summary>
        /// [11110000 11110000 11110000 11110000 11110000 11110000 11110000 11110000]
        /// </summary>
        public const ulong Msb64x8x4 = (ulong) Msb32x8x4 | (ulong) Msb32x8x4 << 32;

        // ~ Msb8x5: The greatest 5 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [11111000]
        /// </summary>
        public const byte Msb8x8x5 = 0b11111000;

        /// <summary>
        /// [11111000 11111000]
        /// </summary>
        public const ushort Msb16x8x5 = (ushort) Msb8x8x5 | (ushort) Msb8x8x5 << 8;

        /// <summary>
        /// [11111000 11111000 11111000 11111000]
        /// </summary>
        public const uint Msb32x8x5 = (uint) Msb16x8x5 | (uint) Msb16x8x5 << 16;

        /// <summary>
        /// [11111000 11111000 11111000 11111000 11111000 11111000 11111000 11111000]
        /// </summary>
        public const ulong Msb64x8x5 = (ulong) Msb32x8x5 | (ulong) Msb32x8x5 << 32;

        // ~ Msb8x6: The greatest 6 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [11111100]
        /// </summary>
        public const byte Msb8x8x6 = 0b11111100;

        /// <summary>
        /// [11111100 11111100]
        /// </summary>
        public const ushort Msb16x8x6 = (ushort) Msb8x8x6 | (ushort) Msb8x8x6 << 8;

        /// <summary>
        /// [11111100 11111100 11111100 11111100]
        /// </summary>
        public const uint Msb32x8x6 = (uint) Msb16x8x6 | (uint) Msb16x8x6 << 16;

        /// <summary>
        /// [11111100 11111100 11111100 11111100 11111100 11111100 11111100 11111100]
        /// </summary>
        public const ulong Msb64x8x6 = (ulong) Msb32x8x6 | (ulong) Msb32x8x6 << 32;

        // ~ Msb8x7: The greatest 7 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [11111110]
        /// </summary>
        public const byte Msb8x8x7 = 0b11111110;

        /// <summary>
        /// [11111110 11111110]
        /// </summary>
        public const ushort Msb16x8x7 = (ushort) Msb8x8x7 | (ushort) Msb8x8x7 << 8;

        /// <summary>
        /// [11111110 11111110 11111110 11111110]
        /// </summary>
        public const uint Msb32x8x7 = (uint) Msb16x8x7 | (uint) Msb16x8x7 << 16;

        /// <summary>
        /// [11111110 11111110 11111110 11111110 11111110 11111110 11111110 11111110]
        /// </summary>
        public const ulong Msb64x8x7 = (ulong) Msb32x8x7 | (ulong) Msb32x8x7 << 32;

        /// <summary>
        /// [0b1100]
        /// </summary>
        public const byte Msb4x1x2 = 0b1100;

        /// <summary>
        /// [11001100]
        /// </summary>
        public const byte Msb8x2x2 = Msb4x1x2 | Msb4x1x2 << 4;

        /// <summary>
        /// [0b1100_1100_1100]
        /// </summary>
        public const ushort Msb12x3x2 = (ushort) Msb8x2x2 | (ushort) Msb4x1x2 << 8;
    }
}