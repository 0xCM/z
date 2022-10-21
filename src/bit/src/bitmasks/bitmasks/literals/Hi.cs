//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        /// <summary>
        /// [11111111 00000000]
        /// </summary>
        [BitMask("11111111 00000000")]
        public const ushort Hi16x8 = (ushort)byte.MaxValue << 8;

        /// <summary>
        /// [11111111 00000000 00000000]
        /// </summary>
        [BitMask("11111111 00000000 00000000")]
        public const uint Hi24x8 = (uint)Hi16x8 << 8;

        /// <summary>
        /// 11111111 00000000 00000000 00000000
        /// </summary>
        [BitMask("11111111 00000000 00000000 00000000")]
        public const uint Hi32x8 = (uint)Hi24x8 << 8;

        /// <summary>
        /// [11111111 11111111 00000000 00000000]
        /// </summary>
        [BitMask("11111111 11111111 00000000 00000000")]
        public const uint Hi32x16 = (uint)ushort.MaxValue << 16;

        /// <summary>
        /// [11111111 11111111 11111111 11111111 00000000 00000000 00000000 00000000]
        /// </summary>
        [BitMask("11111111 11111111 11111111 11111111 00000000 00000000 00000000 00000000")]
        public const ulong Hi64x32 = (ulong)uint.MaxValue << 32;
    }
}