//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMasks.Descriptions;

    partial struct BitMaskLiterals
    {
        /// <summary>
        /// [0101]
        /// </summary>
        [BitMask("0101", LsbIxJx1, 4, 2)]
        public const byte Lsb4x2x1 = 0b0101;

        /// <summary>
        /// [010101]
        /// </summary>
        [BitMask("010101", LsbIxJx1, 6, 2)]
        public const byte Lsb6x2x1 = Lsb4x2x1 | 1 << 4;

        /// <summary>
        /// [01010101]
        /// </summary>
        [BitMask("01010101", LsbIxJx1, 8, 2)]
        public const byte Lsb8x2x1 = Lsb6x2x1 | 1 << 6;

        /// <summary>
        /// [01 01010101]
        /// </summary>
        [BitMask("01 01010101", LsbIxJx1, 10, 2)]
        public const ushort Lsb10x2x1 = (ushort) Lsb8x2x1 | 1 << 8;

        /// <summary>
        /// [0101 01010101]
        /// </summary>
        [BitMask("0101 01010101", LsbIxJx1, 12, 2)]
        public const ushort Lsb12x2x1 = Lsb10x2x1 | 1 << 10;

        /// <summary>
        /// [010101 01010101]
        /// </summary>
        [BitMask("010101 01010101", LsbIxJx1, 14, 2)]
        public const ushort Lsb14x2x1 = Lsb12x2x1 | 1 << 12;

        /// <summary>
        /// [01010101 01010101]
        /// </summary>
        [BitMask("01010101 01010101", LsbIxJx1, 16, 2)]
        public const ushort Lsb16x2x1 = (ushort) Lsb8x2x1 | (ushort) Lsb8x2x1 << 8;

        /// <summary>
        /// [01 01010101 01010101]
        /// </summary>
        [BitMask("01 01010101 01010101", LsbIxJx1, 18, 2)]
        public const uint Lsb18x2x1 = (uint) Lsb16x2x1 | 1u << 16;

        /// <summary>
        /// [01010101 01010101 01010101 01010101]
        /// </summary>
        [BitMask("01010101 01010101 01010101 01010101", LsbIxJx1, 32, 2)]
        public const uint Lsb32x2x1 = (uint) Lsb16x2x1 | (uint) Lsb16x2x1 << 16;

        /// <summary>
        /// [01010101 01010101 01010101 01010101 01010101 01010101 01010101 01010101]
        /// </summary>
        [BitMask("01010101 01010101 01010101 01010101 01010101 01010101 01010101 01010101", LsbIxJx1, 64, 2)]
        public const ulong Lsb64x2x1 = (ulong) Lsb32x2x1 | (ulong) Lsb32x2x1 << 32;

        // ~ Lsb3x1: The least bit of each 3-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [001 001]
        /// </summary>
        [BitMask("001 001")]
        public const byte Lsb6x3x1 = 1 | 1 << 3;

        /// <summary>
        /// [001 001 001]
        /// </summary>
        [BitMask("001 001 001")]
        public const ushort Lsb9x3x1 = Lsb6x3x1 | 1 << 6;

        /// <summary>
        /// [001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001")]
        public const ushort Lsb12x3x1 = Lsb9x3x1 | 1 << 9;

        /// <summary>
        /// [001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001")]
        public const ushort Lsb15x3x1 = Lsb12x3x1 | 1 << 12;

        /// <summary>
        /// [001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001")]
        public const uint Lsb18x3x1 = (uint) Lsb15x3x1 | 1u << 15;

        /// <summary>
        /// [001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001")]
        public const uint Lsb21x3x1 = (uint) Lsb18x3x1 | 1u << 18;

        /// <summary>
        /// [001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001")]
        public const uint Lsb24x3x1 = (uint) Lsb21x3x1 | 1u << 21;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001")]
        public const uint Lsb27x3x1 = (uint) Lsb24x3x1 | 1u << 24;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001")]
        public const uint Lsb30x3x1 = (uint) Lsb27x3x1 | 1u << 27;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb33x3x1 = (ulong) Lsb30x3x1 | 1ul << 30;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb36x3x1 = Lsb33x3x1 | 1ul << 33;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb39x3x1 = Lsb36x3x1 | 1ul << 36;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb41x3x1 = Lsb39x3x1 | 1ul << 39;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb44x3x1 = 0b001_001_001_001_001_001_001_001_001_001_001_001_001_001_001;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb48x3x1 = (ulong) Lsb24x3x1 | (ulong) Lsb24x3x1 << 24;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb51x3x1 = Lsb48x3x1 | 1ul << 48;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb54x3x1 = Lsb51x3x1 | 1ul << 51;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb57x3x1 = Lsb54x3x1 | 1ul << 54;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb60x3x1 = Lsb57x3x1 | 1ul << 57;

        /// <summary>
        /// [001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001]
        /// </summary>
        [BitMask("001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001 001")]
        public const ulong Lsb63x3x1 = Lsb60x3x1 | 1ul << 60;

        // ~ Lsb4x1: The least bit of each 4-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [0001]
        /// </summary>
        [BitMask("0001")]
        public const byte Lsb4x4x1 = 1;

        /// <summary>
        /// [0001 0001]
        /// </summary>
        [BitMask("0001 0001")]
        public const byte Lsb8x4x1 = Lsb4x4x1 | Lsb4x4x1 << 4;

        /// <summary>
        /// [0001 0001 0001]
        /// </summary>
        [BitMask("0001 0001 0001")]
        public const short Lsb12x4x1 = Lsb8x4x1 | Lsb4x4x1 << 8;

        /// <summary>
        /// [0001 0001 0001 0001]
        /// </summary>
        [BitMask("00010001 00010001")]
        public const ushort Lsb16x4x1 = (ushort) Lsb8x4x1 | (ushort) Lsb8x4x1 << 8;

        /// <summary>
        /// [0001_0001 0001_0001 0001_0001 0001_0001]
        /// </summary>
        [BitMask("00010001 00010001 00010001 00010001")]
        public const uint Lsb32x4x1 = (uint) Lsb16x4x1 | (uint) Lsb16x4x1 << 16;

        /// <summary>
        /// [00010001 00010001 00010001 00010001 00010001 00010001 00010001 00010001]
        /// </summary>
        [BitMask("00010001 00010001 00010001 00010001 00010001 00010001 00010001 00010001")]
        public const ulong Lsb64x4x1 = (ulong) Lsb32x4x1 | (ulong) Lsb32x4x1 << 32;

        // ~ 5x1: The least bit of each 5-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00001]
        /// </summary>
        [BitMask("00001")]
        public const byte Lsb5x5x1 = 1;

        /// <summary>
        /// [00001 00001]
        /// </summary>
        [BitMask("00001 00001")]
        public const ushort Lsb10x5x1 = (ushort) Lsb5x5x1 | (ushort) Lsb5x5x1 << 5;

        // ~ 6x1: The least bit of each 6-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [000001]
        /// </summary>
        [BitMask("000001")]
        public const byte Lsb6x6x1 = 1;

        /// <summary>
        /// [000001 000001]
        /// </summary>
        [BitMask("000001 000001")]
        public const ushort Lsb12x6x1 = (ushort) Lsb6x6x1 | (ushort) Lsb6x6x1 << 6;

        /// <summary>
        /// [000001 000001 000001]
        /// </summary>
        [BitMask("000001 000001 000001")]
        public const uint Lsb18x6x1 = (uint) Lsb12x6x1 | (uint) Lsb6x6x1 << 12;

        // ~ 7x1: The least bit of each 7-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [0000001]
        /// </summary>
        [BitMask("0000001")]
        public const byte Lsb7x7x1 = 1;

        /// <summary>
        /// [0000001 0000001]
        /// </summary>
        [BitMask("0000001 0000001")]
        public const ushort Lsb14x7x1 = (ushort) Lsb7x7x1 | (ushort) Lsb7x7x1 << 7;

        // ~ 8x1: The least bit of each 8-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// 0x01 = [00000001]
        /// </summary>
        [BitMask("00000001")]
        public const byte Lsb8x1x1 = 1;

        /// <summary>
        /// 0x0101 = [00000001 00000001]
        /// </summary>
        [BitMask("00000001 00000001")]
        public const ushort Lsb16x8x1 = (ushort) Lsb8x1x1 | 1 << 8;

        /// <summary>
        /// 0x010101 = [00000001 00000001 00000001]
        /// </summary>
        [BitMask("00000001 00000001 00000001")]
        public const uint Lsb24x8x1 = (uint) Lsb16x8x1 | (uint) Lsb8x1x1 << 16;

        /// <summary>
        /// 0x01010101 = [00000001 00000001 00000001 00000001]
        /// </summary>
        [BitMask("00000001 00000001 00000001 00000001")]
        public const uint Lsb32x8x1 = (uint) Lsb16x8x1 | (uint) Lsb16x8x1 << 16;

        /// <summary>
        /// 0x0101010101010101 = [00000001 00000001 00000001 00000001 00000001 00000001 00000001 00000001]
        /// </summary>
        [BitMask("00000001 00000001 00000001 00000001 00000001 00000001 00000001 00000001")]
        public const ulong Lsb64x8x1 = (ulong) Lsb32x8x1 | (ulong) Lsb32x8x1 << 32;

        // ~ 16x1: The least bit of each 16-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000000 00000001]
        /// </summary>
        [BitMask("00000000 00000001")]
        public const ushort Lsb16x16x1 = 1;

        /// <summary>
        /// [00000000 00000001 00000000 00000001]
        /// </summary>
        [BitMask("00000000 00000001 00000000 00000001")]
        public const uint Lsb32x16x1 = (uint) Lsb16x16x1 | (uint) Lsb16x16x1 << 16;

        /// <summary>
        /// [00000000 00000001 00000000 00000001 00000000 00000001 00000000 00000001]
        /// </summary>
        [BitMask("00000000 00000001 00000000 00000001 00000000 00000001 00000000 00000001")]
        public const ulong Lsb64x16x1 = (ulong) Lsb32x16x1 | (ulong) Lsb32x16x1 << 32;

        // ~ 32x1: The least bit of each 32-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000000 00000000 00000000 00000001]
        /// </summary>
        [BitMask("00000000 00000000 00000000 00000001")]
        public const uint Lsb32x32x1 = 1;

        /// <summary>
        /// [00000000 00000000 00000000 00000001 00000000 00000000 00000000 00000001]
        /// </summary>
        [BitMask("00000000 00000000 00000000 00000001 00000000 00000000 00000000 00000001")]
        public const ulong Lsb64x32x1 = (ulong) Lsb32x32x1 | (ulong) Lsb32x32x1 << 32;

        // ~ 64x1: The least bit of each 64-bit segment is enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000000 00000000 00000000 0000000 00000000 00000000 00000000 0000001]
        /// </summary>
        [BitMask("00000000 00000000 00000000 0000000 00000000 00000000 00000000 0000001")]
        public const ulong Lsb64x64x1 = 1;

        // ~ Lsb8x2: The least 2 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000011]
        /// </summary>
        [BitMask("00000011")]
        public const byte Lsb8x8x2 = 1 | 1 << 1;

        /// <summary>
        /// [00000011 00000011]
        /// </summary>
        [BitMask("00000011 00000011")]
        public const ushort Lsb16x8x2 = (ushort) Lsb8x8x2 | (ushort) Lsb8x8x2 << 8;

        /// <summary>
        /// [00000011 00000011 00000011 00000011]
        /// </summary>
        [BitMask("00000011 00000011 00000011 00000011")]
        public const uint Lsb32x8x2 = (uint) Lsb16x8x2 | (uint) Lsb16x8x2 << 16;

        /// <summary>
        /// [00000011 00000011 00000011 00000011 00000011 00000011 00000011 00000011]
        /// </summary>
        [BitMask("00000011 00000011 00000011 00000011 00000011 00000011 00000011 00000011")]
        public const ulong Lsb64x8x2 = (ulong) Lsb32x8x2 | (ulong) Lsb32x8x2 << 32;

        // ~ Lsb8x3: The least 3 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000111]
        /// </summary>
        [BitMask("00000111")]
        public const byte Lsb8x8x3 = Lsb8x8x2 << 1 | 1;

        /// <summary>
        /// [00000111 00000111]
        /// </summary>
        [BitMask("00000111 00000111")]
        public const ushort Lsb16x8x3 = (ushort) Lsb8x8x3 | (ushort) Lsb8x8x3 << 8;

        /// <summary>
        /// [00000111 00000111 00000111 00000111]
        /// </summary>
        [BitMask("00000111 00000111 00000111 00000111")]
        public const uint Lsb32x8x3 = (uint) Lsb16x8x3 | (uint) Lsb16x8x3 << 16;

        /// <summary>
        /// [00000111 00000111 00000111 00000111 00000111 00000111 00000111 00000111]
        /// </summary>
        [BitMask("00000111 00000111 00000111 00000111 00000111 00000111 00000111 00000111")]
        public const ulong Lsb64x8x3 = (ulong) Lsb32x8x3 | (ulong) Lsb32x8x3 << 32;

        // ~ 8x4: The least 4 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// 0x0f = [00001111]
        /// </summary>
        [BitMask("00001111")]
        public const byte Lsb8x8x4 = Lsb8x8x3 << 1 | 1;

        /// <summary>
        /// 0x0f0f = [00001111 00001111]
        /// </summary>
        [BitMask("00001111 00001111")]
        public const ushort Lsb16x8x4 = (ushort)Lsb8x8x4 | (ushort)Lsb8x8x4 << 8;

        /// <summary>
        /// 0x0f0f0f0f = [00001111 ... 00001111]
        /// </summary>
        [BitMask("00001111 00001111 00001111 00001111")]
        public const uint Lsb32x8x4 = (uint) Lsb16x8x4 | (uint)Lsb16x8x4 << 16;

        /// <summary>
        /// 0x0f0f0f0f0f0f0f0f = [00001111 ... 00001111]
        /// </summary>
        [BitMask("00001111 00001111 00001111 00001111 00001111 00001111 00001111 00001111")]
        public const ulong Lsb64x8x4 = (ulong) Lsb32x8x4 | (ulong)Lsb32x8x4 << 32;

        // ~ 8x5: The least 5 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// 00011111
        /// </summary>
        [BitMask("00011111")]
        public const byte Lsb8x8x5 = Lsb8x8x4 << 1 | 1;

        /// <summary>
        /// 00011111 00011111
        /// </summary>
        [BitMask("00011111 00011111")]
        public const ushort Lsb16x8x5 = (ushort) Lsb8x8x5 | (ushort) Lsb8x8x5 << 8;

        /// <summary>
        /// 00011111 00011111 00011111
        /// </summary>
        [BitMask("00011111 00011111 00011111 00011111")]
        public const uint Lsb24x8x5 = (uint) Lsb16x8x5 | (uint) Lsb8x8x5 << 16;

        /// <summary>
        /// [00011111 00011111 00011111 00011111]
        /// </summary>
        [BitMask("00011111 00011111 00011111 00011111")]
        public const uint Lsb32x8x5 = (uint) Lsb16x8x5 | (uint) Lsb16x8x5 << 16;

        /// <summary>
        /// [00011111 00011111 00011111 00011111 00011111]
        /// </summary>
        [BitMask("00011111 00011111 00011111 00011111 00011111")]
        public const ulong Lsb40x8x5 = (ulong) Lsb32x8x5 | (ulong) Lsb8x8x5 << 32;

        /// <summary>
        /// [00011111 00011111 00011111 00011111 00011111 00011111 00011111 00011111]
        /// </summary>
        [BitMask("00011111 00011111 00011111 00011111 00011111 00011111 00011111 00011111")]
        public const ulong Lsb64x8x5 = (ulong) Lsb32x8x5 | (ulong) Lsb32x8x5 << 32;

        // ~ 8x6: The least 6 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00111111]
        /// </summary>
        public const byte Lsb8x8x6 = Lsb8x8x5 << 1 | 1;

        /// <summary>
        /// [00111111 00111111]
        /// </summary>
        public const ushort Lsb16x8x6 = (ushort) Lsb8x8x6 | (ushort) Lsb8x8x6 << 8;

        /// <summary>
        /// [00111111 00111111 00111111 00111111]
        /// </summary>
        [BitMask("00111111 00111111 00111111 00111111")]
        public const uint Lsb32x8x6 = (uint) Lsb16x8x6 | (uint) Lsb16x8x6 << 16;

        /// <summary>
        /// [00111111 00111111 00111111 00111111 00111111 00111111 00111111 00111111]
        /// </summary>
        [BitMask("00111111 00111111 00111111 00111111 00111111 00111111 00111111 00111111")]
        public const ulong Lsb64x8x6 = (ulong) Lsb32x8x6 | (ulong) Lsb32x8x6 << 32;

        // ~ 8x4: The least 7 bits of each 8-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [01111111]
        /// </summary>
        [BitMask("01111111")]
        public const byte Lsb8x8x7 = Lsb8x8x6 << 1 | 1;

        /// <summary>
        /// [01111111 01111111]
        /// </summary>
        [BitMask("01111111 01111111")]
        public const ushort Lsb16x8x7 = (ushort) Lsb8x8x7 | (ushort) Lsb8x8x7 << 8;

        /// <summary>
        /// [01111111 01111111 01111111 01111111]
        /// </summary>
        [BitMask("01111111 01111111 01111111 01111111")]
        public const uint Lsb32x8x7 = (uint) Lsb16x8x7 | (uint) Lsb16x8x7 << 16;

        /// <summary>
        /// [01111111 01111111 01111111 01111111 01111111 01111111 01111111 01111111]
        /// </summary>
        [BitMask("01111111 01111111 01111111 01111111 01111111 01111111 01111111 01111111")]
        public const ulong Lsb64x8x7 = (ulong) Lsb32x8x7 | (ulong) Lsb32x8x7 << 32;

        // ~ 16x3: The least 3 bits of each 16-bit segment are enabled
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000000 00000111]
        /// </summary>
        [BitMask("00000000 00000111")]
        public const ushort Lsb16x16x3 = (ushort) Lsb8x8x3;

        /// <summary>
        /// [00000000 00000111 00000000 00000111]
        /// </summary>
        [BitMask("00000000 00000111 00000000 00000111")]
        public const uint Lsb32x16x3 = (uint) Lsb16x16x3 | (uint) Lsb16x16x3 << 16;

        /// <summary>
        /// [01111111 11111111]
        /// </summary>
        [BitMask("01111111 11111111")]
        public const ushort Lsb16x16x15 = ushort.MaxValue >> 1;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 00000001")]
        public const ulong Lsb64x1 = 0b1;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 00000011")]
        public const ulong Lsb64x2 = Lsb64x1 | Lsb64x1 << 1;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 00000111")]
        public const ulong Lsb64x3 = Lsb64x2 | Lsb64x1 << 2;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 00001111")]
        public const ulong Lsb64x4 = Lsb64x3 | Lsb64x1 << 3;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 00011111")]
        public const ulong Lsb64x5 = Lsb64x4 | Lsb64x1 << 4;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 00111111")]
        public const ulong Lsb64x6 = Lsb64x5 | Lsb64x1 << 5;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 01111111")]
        public const ulong Lsb64x7 = Lsb64x6 | Lsb64x1 << 6;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 11111111")]
        public const ulong Lsb64x8 = Lsb64x7 | Lsb64x1 << 7;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000001 11111111")]
        public const ulong Lsb64x9 = Lsb64x8 | Lsb64x1 << 8;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000011 11111111")]
        public const ulong Lsb64x10 = Lsb64x9 | Lsb64x1 << 9;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000111 11111111")]
        public const ulong Lsb64x11 = Lsb64x10 | Lsb64x1 << 10;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00001111 11111111")]
        public const ulong Lsb64x12 = Lsb64x11 | Lsb64x1 << 11;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00011111 11111111")]
        public const ulong Lsb64x13 = Lsb64x12 | Lsb64x1 << 12;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00111111 11111111")]
        public const ulong Lsb64x14 = Lsb64x13 | Lsb64x1 << 13;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 01111111 11111111")]
        public const ulong Lsb64x15 = Lsb64x14 | Lsb64x1 << 14;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 11111111 11111111")]
        public const ulong Lsb64x16 = Lsb64x15 | Lsb64x1 << 15;
    }
}