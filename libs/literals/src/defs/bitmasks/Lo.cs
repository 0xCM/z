//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        /// <summary>
        /// [1]
        /// </summary>
        [BitMask("1")]
        public const byte Lo8x1 = 0b1;

        /// <summary>
        /// [11]
        /// </summary>
        [BitMask("11")]
        public const byte Lo8x2 = 0b11;

        /// <summary>
        /// [111]
        /// </summary>
        [BitMask("111")]
        public const byte Lo8x3 = 0b111;

        /// <summary>
        /// [1111]
        /// </summary>
        [BitMask("1111")]
        public const byte Lo8x4 = 0b1111;

        /// <summary>
        /// [11111]
        /// </summary>
        [BitMask("11111")]
        public const byte Lo8x5 = 0b11111;

        /// <summary>
        /// [111111]
        /// </summary>
        [BitMask("111111")]
        public const byte Lo8x6 = 0b111111;

        /// <summary>
        /// [1111111]
        /// </summary>
        [BitMask("1111111")]
        public const byte Lo8x7 = 0b1111111;

        /// <summary>
        /// [11111111]
        /// </summary>
        [BitMask("11111111")]
        public const byte Lo8x8 = byte.MaxValue;

        /// <summary>
        /// [00000000 00000001]
        /// </summary>
        [BitMask("00000000 00000001")]
        public const ushort Lo16x1 = Lo8x1;

        /// <summary>
        /// [00000000 00000011]
        /// </summary>
        [BitMask("00000000 00000011")]
        public const ushort Lo16x2 = Lo8x2;

        /// <summary>
        /// [00000000 00000111]
        /// </summary>
        [BitMask("00000000 00000111")]
        public const ushort Lo16x3 = Lo8x3;

        /// <summary>
        /// [00000000 00001111]
        /// </summary>
        [BitMask("00000000 00001111")]
        public const ushort Lo16x4 = Lo8x4;

        /// <summary>
        /// [00000000 00011111]
        /// </summary>
        [BitMask("00000000 00011111")]
        public const ushort Lo16x5 = Lo8x5;

        /// <summary>
        /// [00000000 00111111]
        /// </summary>
        [BitMask("00000000 00111111")]
        public const ushort Lo16x6 = Lo8x6;

        /// <summary>
        /// [00000000 01111111]
        /// </summary>
        [BitMask("00000000 01111111")]
        public const ushort Lo16x7 = Lo8x7;

        /// <summary>
        /// [00000000 11111111]
        /// </summary>
        [BitMask("00000000 11111111")]
        public const ushort Lo16x8 = Lo8x8;

        /// <summary>
        /// [00000001 1111111]
        /// </summary>
        [BitMask("00000001 11111111")]
        public const ushort Lo16x9 = (ushort)Lo8x8 << 1 | Lo16x1;

        /// <summary>
        /// [00000011 1111111]
        /// </summary>
        [BitMask("00000011 11111111")]
        public const ushort Lo16x10 = (ushort)Lo8x8 << 2 | Lo16x2;

        /// <summary>
        /// [00000111 1111111]
        /// </summary>
        [BitMask("00000111 11111111")]
        public const ushort Lo16x11 = (ushort)Lo8x8 << 3 | Lo16x3;

        /// <summary>
        /// [00001111 1111111]
        /// </summary>
        [BitMask("00001111 11111111")]
        public const ushort Lo16x12 = (ushort)Lo8x8 << 4 | Lo16x4;

        /// <summary>
        /// [00011111 1111111]
        /// </summary>
        [BitMask("00011111 11111111")]
        public const ushort Lo16x13 = (ushort)Lo8x8 << 4 | Lo16x5;

        /// <summary>
        /// [00111111 1111111]
        /// </summary>
        [BitMask("00111111 11111111")]
        public const ushort Lo16x14 = (ushort)Lo8x8 << 4 | Lo16x6;

        /// <summary>
        /// [11111111 11111111]
        /// </summary>
        [BitMask("11111111 11111111")]
        public const ushort Lo16x16 = ushort.MaxValue;

        /// <summary>
        /// [00000000 00000000 00000000 00001111]
        /// </summary>
        [BitMask("00000000 00000000 00000000 00000011")]
        public const uint Lo32x2 = Lo8x2;

        /// <summary>
        /// [00000000 00000000 00000000 00001111]
        /// </summary>
        [BitMask("00000000 00000000 00000000 00001111")]
        public const uint Lo32x4 = Lo8x4;

        /// <summary>
        /// [11111111 11111111 11111111]
        /// </summary>
        [BitMask("11111111 11111111 11111111")]
        public const uint Lo32x24 = (uint)Lo16x16 << 8 | Lo8x8;

        /// <summary>
        /// [11111111 11111111 11111111 11111111]
        /// </summary>
        [BitMask("11111111 11111111 11111111 11111111")]
        public const uint Lo32x32 = Lo32x24 << 8 | Lo8x8;

        /// <summary>
        /// [00000000 00000000 00000000 00001111]
        /// </summary>
        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 00001111")]
        public const ulong Lo64x4 = Lo8x4;

        /// <summary>
        /// [11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111111]
        /// </summary>
        [BitMask("11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111111")]
        public const ulong Lo64x64 = ulong.MaxValue;
    }
}