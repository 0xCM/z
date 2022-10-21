//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        /// <summary>
        /// [10101010]
        /// </summary>
        [BitMask ("10101010")]
        public const byte Odd8 = Msb8x2x1;

        /// <summary>
        /// [10101010 10101010]
        /// </summary>
        [BitMask ("10101010 10101010")]
        public const ushort Odd16 = (ushort) Odd8 | (ushort) Odd8 << 8;

        /// <summary>
        /// [10101010 10101010 10101010 10101010]
        /// </summary>
        [BitMask ("10101010 10101010 10101010 10101010")]
        public const uint Odd32 = (uint) Odd16 | (uint) Odd16 << 16;

        /// <summary>
        /// [10101010 10101010 10101010 10101010 10101010 10101010 10101010 10101010]
        /// </summary>
        [BitMask ("10101010 10101010 10101010 10101010 10101010 10101010 10101010 10101010")]
        public const ulong Odd64 = (ulong) Odd32 | (ulong) Odd32 << 32;

        /// <summary>
        /// [11001100]
        /// </summary>
        [BitMask ("11001100")]
        public const byte Odd8x2 = 0b11001100;

        /// <summary>
        /// [11001100 11001100]
        /// </summary>
        [BitMask ("11001100 11001100")]
        public const ushort Odd16x2 = (ushort) Odd8x2 | (ushort) Odd8x2 << 8;

        /// <summary>
        /// [11001100 11001100 11001100 11001100]
        /// </summary>
        [BitMask ("11001100 11001100 11001100 11001100")]
        public const uint Odd32x2 = (uint) Odd16x2 | (uint) Odd16x2 << 16;

        /// <summary>
        /// [11001100 11001100 11001100 11001100 11001100 11001100 11001100 11001100]
        /// </summary>
        [BitMask ("11001100 11001100 11001100 11001100 11001100 11001100 11001100 11001100")]
        public const ulong Odd64x2 = (ulong) Odd32x2 | (ulong) Odd32x2 << 32;
    }
}