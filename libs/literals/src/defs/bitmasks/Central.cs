//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        // ~ Central4x2 [01100110]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// 0x6 = [0110]
        /// </summary>
        [BitMask("0110")]
        public const byte Central4x4x2 = 0x6;

        /// <summary>
        /// 0x66 = [01100110]
        /// </summary>
        [BitMask("01100110")]
        public const byte Central8x4x2 = 0x66;

        /// <summary>
        /// 0x6666 = [01100110 01100110]
        /// </summary>
        [BitMask("01100110 01100110")]
        public const ushort Central16x4x2 = 0x6666;

        /// <summary>
        /// 0x66666666 = [01100110 01100110 01100110 01100110]
        /// </summary>
        [BitMask("01100110 01100110 01100110 01100110")]
        public const uint Central32x4x2 = 0x66666666;

        /// <summary>
        /// 0x6666666666666666 = [01100110 01100110 01100110 01100110 01100110 01100110 01100110 01100110 01100110 01100110]
        /// </summary>
        [BitMask("01100110 01100110 01100110 01100110 01100110 01100110 01100110 01100110 01100110 01100110")]
        public const ulong Central64x4x2 = 0x6666666666666666;

        // ~ Central8x2 [00011000]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// 0x18 = [00011000]
        /// </summary>
        [BitMask("00011000")]
        public const byte Central8x8x2 = 0b00011000;

        /// <summary>
        /// 0x1818 = [00011000 00011000]
        /// </summary>
        [BitMask("00011000 00011000")]
        public const ushort Central16x8x2 = (ushort)Central8x8x2 | (ushort)Central8x8x2 << 8;

        /// <summary>
        /// 0x18181818 = [00011000 00011000 00011000 00011000]
        /// </summary>
        [BitMask("00011000 00011000 00011000 00011000")]
        public const uint Central32x8x2 = (uint)Central16x8x2 | (uint)Central16x8x2 << 16;

        /// <summary>
        /// 0x1818181818181818 = [00011000 00011000 00011000 00011000 00011000 00011000 00011000 00011000]
        /// </summary>
        [BitMask("00011000 00011000 00011000 00011000 00011000 00011000 00011000 00011000")]
        public const ulong Central64x8x2 = (ulong)Central32x8x2 | (ulong)Central32x8x2 << 32;

        // ~ Central8x4 [00111100]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// 0x3C = [00111100]
        /// </summary>
        [BitMask("00111100")]
        public const byte Central8x8x4 = 0b00111100;

        /// <summary>
        /// 0x3C3C = [00111100 00111100]
        /// </summary>
        [BitMask("00111100 00111100")]
        public const ushort Central16x8x4 = (ushort)Central8x8x4 | (ushort)Central8x8x4 << 8;

        /// <summary>
        /// 0x3C3C3C3C = [00111100 00111100 00111100 00111100]
        /// </summary>
        [BitMask("00111100 00111100 00111100 00111100")]
        public const uint Central32x8x4 = (uint)Central16x8x4 | (uint)Central16x8x4 << 16;

        /// <summary>
        /// 0x3C3C3C3C3C3C3C3C = [00111100 00111100 00111100 00111100 00111100 00111100 00111100 00111100]
        /// </summary>
        [BitMask("00111100 00111100 00111100 00111100 00111100 00111100 00111100 00111100")]
        public const ulong Central64x8x4 = (ulong)Central32x8x4 | (ulong)Central32x8x4 << 32;

        // ~ Central16x8
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// 0x0FF0 = [00001111 11110000]
        /// </summary>
        [BitMask("00001111 11110000")]
        public const ushort Central16x16x8 = (ushort) Msb8x8x4 | (ushort)Lsb8x8x4 << 8;

        /// <summary>
        /// 0x0FF00FF0 = [00001111 11110000 00001111 11110000]
        /// </summary>
        [BitMask("00001111 11110000 00001111 11110000")]
        public const uint Central32x16x8 = (uint) Central16x16x8 | (uint)Central16x16x8 << 16;

        /// <summary>
        /// 0x0FF00FF00FF00FF0 = [00001111 11110000 00001111 11110000 00001111 11110000 00001111 11110000]
        /// </summary>
        [BitMask("00001111 11110000 00001111 11110000 00001111 11110000 00001111 11110000")]
        public const ulong Central64x16x8 = (ulong) Central32x16x8 | (ulong)Central32x16x8 << 32;

        // ~ Central8x6 [01111110]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [01111110]
        /// </summary>
        [BitMask("01111110")]
        public const byte Central8x8x6 = 0b01111110;

        /// <summary>
        /// [01111110 01111110]
        /// </summary>
        [BitMask("01111110 01111110")]
        public const ushort Central16x8x6 = (ushort)Central8x8x6 | (ushort)Central8x8x6 << 8;

        /// <summary>
        /// [01111110 01111110 01111110 01111110]
        /// </summary>
        [BitMask("01111110 01111110 01111110 01111110")]
        public const uint Central32x8x6 = (uint)Central16x8x6 | (uint)Central16x8x6 << 16;

        /// <summary>
        /// [01111110 01111110 01111110 01111110 01111110 01111110 01111110 01111110]
        /// </summary>
        [BitMask("01111110 01111110 01111110 01111110 01111110 01111110 01111110 01111110")]
        public const ulong Central64x8x6 = (ulong)Central32x8x6 | (ulong)Central32x8x6 << 32;

        /// <summary>
        /// [00000001 10000000]
        /// </summary>
        [BitMask("00000001 10000000")]
        public const ushort Central16x16x2 = (ushort) Msb8x8x1 | (ushort)Lsb8x1x1 << 8;

        /// <summary>
        /// [00000001 10000000 00000001 10000000]
        /// </summary>
        [BitMask("00000001 10000000 00000001 10000000")]
        public const uint Central32x16x2 = (uint) Central16x16x2 | (uint)Central16x16x2 << 16;

        /// <summary>
        /// [00000001 10000000 00000001 10000000 00000001 10000000 00000001 10000000]
        /// </summary>
        [BitMask("00000001 10000000 00000001 10000000 00000001 10000000 00000001 10000000")]
        public const ulong Central64x16x2 = (ulong) Central32x16x2 | (ulong)Central32x16x2 << 32;

        /// <summary>
        /// [00000011 11000000]
        /// </summary>
        [BitMask("00000011 11000000")]
        public const ushort Central16x4 = (ushort) Msb8x8x2 | (ushort)Lsb8x8x2 << 8;

        /// <summary>
        /// [00000111 11100000]
        /// </summary>
        [BitMask("00000111 11100000")]
        public const ushort Central16x6 = (ushort) Msb8x8x3 | (ushort)Lsb8x8x3 << 8;

        /// <summary>
        /// [00011111 11111000]
        /// </summary>
        [BitMask("00011111 11111000")]
        public const ushort Central16x10 = (ushort) Msb8x8x5 | (ushort)Lsb8x8x5 << 8;

        /// <summary>
        /// [00111111 11111100]
        /// </summary>
        [BitMask("00111111 11111100")]
        public const ushort Central16x12 = (ushort) Msb8x8x6 | (ushort)Lsb8x8x6 << 8;

        /// <summary>
        /// [01111111 11111110]
        /// </summary>
        [BitMask("01111111 11111110")]
        public const ushort Central16x14 = (ushort) Msb8x8x7 | (ushort)Lsb8x8x7 << 8;

        /// <summary>
        /// [00000000 00000001 10000000 00000000]
        /// </summary>
        [BitMask("00000000 00000001 10000000 00000000")]
        public const uint Central32x2 = (uint) Msb16x16x1 | (uint)Lsb16x16x1 << 16;

        /// <summary>
        /// 0x00FFFF00
        /// </summary>
        [HexLiteral("0x00FFFF00")]
        public const uint Central32x32x16 = 0x00FFFF00;

        /// <summary>
        /// 0x00FFFF0000FFFF00
        /// </summary>
        [HexLiteral("0x00FFFF0000FFFF00")]
        public const ulong Central64x32x16 = 0x00FFFF0000FFFF00;

        /// <summary>
        /// 0x0000FFFFFFFF0000
        /// </summary>
        [HexLiteral("0x0000FFFFFFFF0000")]
        public const ulong Central64x64x32 = 0x0000FFFFFFFF0000;
    }
}