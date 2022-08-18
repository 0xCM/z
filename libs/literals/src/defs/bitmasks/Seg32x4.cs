//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        [BitMask("00000000 00000000 00000000 00001111")]
        public const uint Seg32x4x0 = Lo32x4;

        [BitMask("00000000 00000000 00000000 11110000")]
        public const uint Seg32x4x1 = Seg32x4x0 << 4;

        [BitMask("00000000 00000000 00001111 00000000")]
        public const uint Seg32x4x2 = Seg32x4x1 << 4;

        [BitMask("00000000 00000000 11110000 00000000")]
        public const uint Seg32x4x3 = Seg32x4x2 << 4;

        [BitMask("00000000 00001111 00000000 00000000")]
        public const uint Seg32x4x4 = Seg32x4x3 << 4;

        [BitMask("00000000 11110000 00000000 00000000")]
        public const uint Seg32x4x5 = Seg32x4x4 << 4;

        [BitMask("00001111 00000000 00000000 00000000")]
        public const uint Seg32x4x6 = Seg32x4x5 << 4;

        [BitMask("11110000 00000000 00000000 00000000")]
        public const uint Seg32x4x7 = Seg32x4x6 << 4;

    }
}