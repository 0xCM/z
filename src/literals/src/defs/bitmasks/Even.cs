//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        /// <summary>
        /// 0x55 = [01010101]
        /// </summary>
        [BitMask ("01010101")]
        public const byte Even8 = Lsb8x2x1;

        /// <summary>
        /// 0x5555 = [01010101 01010101]
        /// </summary>
        [BitMask ("01010101 01010101")]
        public const ushort Even16 = (ushort) Even8 | (ushort) Even8 << 8;

        /// <summary>
        /// 0x55555555 = [01010101 01010101 01010101 01010101]
        /// </summary>
        [BitMask ("01010101 01010101 01010101 01010101")]
        public const uint Even32 = (ushort) Even16 | (ushort) Even16 << 16;

        /// <summary>
        /// 0x5555555555555555 = [01010101 01010101 01010101 01010101 01010101 01010101 01010101 01010101]
        /// </summary>
        [BitMask ("01010101 01010101 01010101 01010101 01010101 01010101 01010101 01010101")]
        public const ulong Even64 = (ulong) Even32 | (ulong) Even32 << 32;

        /// <summary>
        /// 0x33 = [00110011]
        /// </summary>
        [BitMask ("00110011")]
        public const byte Even8x2 = 0b00110011;

        /// <summary>
        /// 0x3333 = [00110011 00110011]
        /// </summary>
        [BitMask ("00110011 00110011")]
        public const ushort Even16x2 = (ushort) Even8x2 | (ushort) Even8x2 << 8;

        /// <summary>
        /// 0x33333333 = [00110011 00110011 00110011 00110011]
        /// </summary>
        [BitMask ("00110011 00110011 00110011 00110011")]
        public const uint Even32x2 = (uint) Even16x2 | (uint) Even16x2 << 16;

        /// <summary>
        /// 0x3333333333333333 = [00110011 00110011 00110011 00110011 00110011 00110011 00110011 00110011]
        /// </summary>
        [BitMask ("00110011 00110011 00110011 00110011 00110011 00110011 00110011 00110011")]
        public const ulong Even64x2 = (ulong) Even32x2 | (ulong) Even32x2 << 32;
    }
}