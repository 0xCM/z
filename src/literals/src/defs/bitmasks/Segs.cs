//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        [BitMask("00000000 11111111")]
        public const ushort Seg16x8x0 = Lo8x8;

        [BitMask("11111111 00000000")]
        public const ushort Seg16x8x1 = Seg16x8x0 << 8;

        [BitMask("00000000 00000000 00000000 11111111")]
        public const uint Seg32x8x0 = Lo8x8;

        [BitMask("00000000 00000000 11111111 00000000")]
        public const uint Seg32x8x1 = Seg32x8x0 << 8;

        [BitMask("00000000 11111111 00000000 00000000")]
        public const uint Seg32x8x2 = Seg32x8x1 << 8;

        [BitMask("11111111 00000000 00000000 00000000")]
        public const uint Seg32x8x3 = Seg32x8x2 << 8;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 00000000 11111111")]
        public const ulong Seg64x8x0 = Lo8x8;

        [BitMask("00000000 00000000 00000000 00000000 00000000 00000000 11111111 00000000")]
        public const ulong Seg64x8x1 = Seg64x8x0 << 8;

        [BitMask("00000000 00000000 00000000 00000000 00000000 11111111 00000000 00000000")]
        public const ulong Seg64x8x2 = Seg64x8x1 << 8;

        [BitMask("00000000 00000000 00000000 00000000 11111111 00000000 00000000 00000000")]
        public const ulong Seg64x8x3 = Seg64x8x2 << 8;

        [BitMask("00000000 00000000 00000000 11111111 00000000 00000000 00000000 00000000")]
        public const ulong Seg64x8x4 = Seg64x8x3 << 8;

        [BitMask("00000000 00000000 11111111 00000000 00000000 00000000 00000000 00000000")]
        public const ulong Seg64x8x5 = Seg64x8x4 << 8;

        [BitMask("00000000 11111111 00000000 00000000 00000000 00000000 00000000 00000000")]
        public const ulong Seg64x8x6 = Seg64x8x5 << 8;

        [BitMask("11111111 00000000 00000000 00000000 00000000 00000000 00000000 00000000")]
        public const ulong Seg64x8x7 = Seg64x8x6 << 8;

        [BitMask("00001111")]
        public const byte Seg8x4x0 = Lo8x4;

        [BitMask("00001111")]
        public const byte Seg8x4x1 = Lo8x4 << 4;

        /// <summary>
        /// [00000000 00001111]
        /// </summary>
        [BitMask("00000000 00001111")]
        public const ushort Seg16x4x0 = Lo16x4;

        /// <summary>
        /// [00000000 11110000]
        /// </summary>
        [BitMask("00000000 11110000")]
        public const ushort Seg16x4x1 = Seg16x4x0 << 4;

        /// <summary>
        /// [00001111 00000000]
        /// </summary>
        [BitMask("00001111 00000000")]
        public const ushort Seg16x4x2 = Seg16x4x1 << 4;

        /// <summary>
        /// [11110000 00000000]
        /// </summary>
        [BitMask("11110000 00000000")]
        public const ushort Seg16x4x3 = Seg16x4x2 << 4;
    }
}