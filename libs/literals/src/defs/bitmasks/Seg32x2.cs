//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        [BitMask("00000000 00000000 00000000 00000011")]
        public const uint Seg32x2x0 = Lo32x2;

        [BitMask("00000000 00000000 00000000 00000110")]
        public const uint Seg32x2x1 = Seg32x2x0 << 2;

        [BitMask("00000000 00000000 00000000 00011000")]
        public const uint Seg32x2x2 = Seg32x2x1 << 2;

        [BitMask("00000000 00000000 00000000 11000000")]
        public const uint Seg32x2x3 = Seg32x2x2 << 2;

        [BitMask("00000000 00000000 00000011 00000000")]
        public const uint Seg32x2x4 = Seg32x2x3 << 2;

        [BitMask("00000000 00000000 00001100 00000000")]
        public const uint Seg32x2x5 = Seg32x2x4 << 2;

        [BitMask("00000000 00000000 00110000 00000000")]
        public const uint Seg32x2x6 = Seg32x2x5 << 2;

        [BitMask("00000000 00000000 11000000 00000000")]
        public const uint Seg32x2x7 = Seg32x2x6 << 2;

        [BitMask("00000000 00000011 00000000 00000000")]
        public const uint Seg32x2x8 = Seg32x2x7 << 2;

        [BitMask("00000000 00001100 00000000 00000000")]
        public const uint Seg32x2x9 = Seg32x2x8 << 2;

        [BitMask("00000000 00110000 00000000 00000000")]
        public const uint Seg32x2x10 = Seg32x2x9 << 2;

        [BitMask("00000000 11000000 00000000 00000000")]
        public const uint Seg32x2x11 = Seg32x2x10 << 2;

        [BitMask("00000011 00000000 00000000 00000000")]
        public const uint Seg32x2x12 = Seg32x2x11 << 2;

        [BitMask("00001100 00000000 00000000 00000000")]
        public const uint Seg32x2x13 = Seg32x2x12 << 2;

        [BitMask("00110000 00000000 00000000 00000000")]
        public const uint Seg32x2x14 = Seg32x2x13 << 2;

        [BitMask("11000000 00000000 00000000 00000000")]
        public const uint Seg32x2x15 = Seg32x2x14 << 2;
    }
}