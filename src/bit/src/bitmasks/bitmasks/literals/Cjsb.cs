//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        // ~ CJsb8x2x1 [10011001]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [10011001]
        /// </summary>
        [BitMask("10011001")]
        public const byte CJsb8x8x2x1 = Central8x8x2 | Jsb8x8x1;

        /// <summary>
        /// [10011001 10011001]
        /// </summary>
        [BitMask("10011001 10011001")]
        public const ushort CJsb16x8x2x1 = (ushort)CJsb8x8x2x1 | (ushort)CJsb8x8x2x1 << 8;

        /// <summary>
        /// [10011001 10011001 10011001 10011001]
        /// </summary>
        [BitMask("10011001 10011001 10011001 10011001")]
        public const uint CJsb32x8x2x1 = (uint)CJsb16x8x2x1 | (uint)CJsb16x8x2x1 << 16;

        /// <summary>
        /// [10011001 10011001 10011001 10011001 10011001 10011001 10011001 10011001]
        /// </summary>
        [BitMask("10011001 10011001 10011001 10011001 10011001 10011001 10011001 10011001")]
        public const ulong CJsb64x8x2x1 = (ulong)CJsb32x8x2x1 | (ulong)CJsb32x8x2x1 << 32;

        // ~ CJsb8x2x2 [11011011]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [0b11011011]
        /// </summary>
        [BitMask("11011011")]
        public const byte CJsb8x8x2x2 = Central8x8x2 | Jsb8x8x2;

        /// <summary>
        /// [0b11011011_11011011]
        /// </summary>
        [BitMask("11011011 11011011")]
        public const ushort CJsb16x8x2x2 = (ushort)CJsb8x8x2x2 | (ushort)CJsb8x8x2x2 << 8;

        /// <summary>
        /// [11011011 11011011 11011011 11011011]
        /// </summary>
        [BitMask("11011011 11011011 11011011 11011011")]
        public const uint CJsb32x8x2x2 = (uint)CJsb16x8x2x2 | (uint)CJsb16x8x2x2 << 16;

        /// <summary>
        /// [0b11011011_11011011_11011011_11011011_11011011_11011011_11011011_11011011]
        /// </summary>
        [BitMask("11011011 11011011 11011011 11011011 11011011 11011011 11011011 11011011")]
        public const ulong CJsb64x8x2x2 = (ulong)CJsb32x8x2x2 | (ulong)CJsb32x8x2x2 << 32;

        // ~ CJsb8x4 [10111101]
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [10111101]
        /// </summary>
        [BitMask("10111101")]
        public const byte CJsb8x8x4x1 = Central8x8x4 | Jsb8x8x1;

        /// <summary>
        /// [10111101 10111101]
        /// </summary>
        [BitMask("10111101 10111101")]
        public const ushort CJsb16x8x4x1 = (ushort)CJsb8x8x4x1 | (ushort)CJsb8x8x2x1 << 8;

        /// <summary>
        /// [10111101 10111101 10111101 10111101]
        /// </summary>
        [BitMask("10111101 10111101 10111101 10111101")]
        public const uint CJsb32x8x4x1 = (uint)CJsb16x8x4x1 | (uint)CJsb16x8x2x1 << 16;

        /// <summary>
        /// [10111101 10111101 10111101 10111101 10111101 10111101 10111101 10111101]
        /// </summary>
        [BitMask("10111101 10111101 10111101 10111101 10111101 10111101 10111101 10111101")]
        public const ulong CJsb64x8x4x1 = (ulong)CJsb32x8x4x1 | (ulong)CJsb32x8x2x1 << 32;
    }
}