//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        // ~ Index8x8
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000001]
        /// </summary>
        [MultiLiteral ("[00000001 | 1h | 1d]")]
        public const byte Index8x8x0 = 0b00000001;

        /// <summary>
        /// [00000010]
        /// </summary>
        [MultiLiteral ("00000010 | 2h | 2d")]
        public const byte Index8x8x1 = Index8x8x0 << 1;

        /// <summary>
        /// [00000100]
        /// </summary>
        [MultiLiteral ("00000100 | 4h | 4d")]
        public const byte Index8x8x2 = Index8x8x1 << 1;

        /// <summary>
        /// [00001000]
        /// </summary>
        [MultiLiteral ("00001000 | 8h | 8d")]
        public const byte Index8x8x3 = Index8x8x2 << 1;

        /// <summary>
        /// [00010000]
        /// </summary>
        [MultiLiteral ("00010000 | 10h | 16d")]
        public const byte Index8x8x4 = Index8x8x3 << 1;

        /// <summary>
        /// [00100000]
        /// </summary>
        [BinaryLiteral ("00100000")]
        public const byte Index8x8x5 = Index8x8x4 << 1;

        /// <summary>
        /// [01000000]
        /// </summary>
        [BinaryLiteral ("01000000")]
        public const byte Index8x8x6 = Index8x8x5 << 1;

        /// <summary>
        /// [10000000]
        /// </summary>
        [BinaryLiteral ("10000000")]
        public const byte Index8x8x7 = Index8x8x6 << 1;

        /// <summary>
        /// [00000000 00000001]
        /// </summary>
        [BinaryLiteral ("00000000 00000001")]
        public const ushort Index16x16x1 = Index8x8x7 << 1;

        // ~ Index16x8
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000001 00000001]
        /// </summary>
        [BinaryLiteral ("[00000001 00000001]")]
        public const ushort Index16x8x0 = (ushort) Index8x8x0 | (ushort) Index8x8x0 << 8;

        /// <summary>
        /// [00000010 00000010]
        /// </summary>
        [BinaryLiteral ("[00000010 00000010]")]
        public const ushort Index16x8x1 = (ushort) Index8x8x1 | (ushort) Index8x8x1 << 8;

        /// <summary>
        /// [00000100 00000100]
        /// </summary>
        [BinaryLiteral ("[00000100 00000100]")]
        public const ushort Index16x8x2 = (ushort) Index8x8x2 | (ushort) Index8x8x2 << 8;

        /// <summary>
        /// [00001000 00001000]
        /// </summary>
        [BinaryLiteral ("[00001000 00001000]")]
        public const ushort Index16x8x3 = (ushort) Index8x8x3 | (ushort) Index8x8x3 << 8;

        /// <summary>
        /// [00010000 00010000]
        /// </summary>
        [BinaryLiteral ("[00010000 00010000]")]
        public const ushort Index16x8x4 = (ushort) Index8x8x4 | (ushort) Index8x8x4 << 8;

        /// <summary>
        /// [00100000 00100000]
        /// </summary>
        [BinaryLiteral ("[00100000 00100000]")]
        public const ushort Index16x8x5 = (ushort) Index8x8x5 | (ushort) Index8x8x5 << 8;

        /// <summary>
        /// [01000000 01000000]
        /// </summary>
        [BinaryLiteral ("[01000000 01000000]")]
        public const ushort Index16x8x6 = (ushort) Index8x8x6 | (ushort) Index8x8x6 << 8;

        /// <summary>
        /// [10000000 10000000]
        /// </summary>
        [BinaryLiteral("[10000000 10000000]")]
        public const ushort Index16x8x7 = (ushort) Index8x8x7 | (ushort) Index8x8x7 << 8;

        // ~ Index32x8
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000001 00000001 00000001 00000001]
        /// </summary>
        [BinaryLiteral ("[00000001 00000001 00000001 00000001]")]
        public const uint Index32x8x0 = (uint) Index16x8x0 | (uint) Index16x8x0 << 16;

        /// <summary>
        /// [00000010 00000010 00000010 00000010]
        /// </summary>
        [BinaryLiteral ("[00000010 00000010 00000010 00000010]")]
        public const uint Index32x8x1 = (uint) Index16x8x1 | (uint) Index16x8x1 << 16;

        /// <summary>
        /// [00000100 00000100 00000100 00000100]
        /// </summary>
        [BinaryLiteral ("[00000100 00000100 00000100 00000100]")]
        public const uint Index32x8x2 = (uint) Index16x8x2 | (uint) Index16x8x2 << 16;

        /// <summary>
        /// [00001000 00001000 00001000 00001000]
        /// </summary>
        public const uint Index32x8x3 = (uint) Index16x8x3 | (uint) Index16x8x3 << 16;

        /// <summary>
        /// [00010000 00010000 00010000 00010000]
        /// </summary>
        public const uint Index32x8x4 = (uint) Index16x8x4 | (uint) Index16x8x4 << 16;

        /// <summary>
        /// [00100000 00100000 00100000 00100000]
        /// </summary>
        public const uint Index32x8x5 = (uint) Index16x8x5 | (uint) Index16x8x5 << 16;

        /// <summary>
        /// [01000000 01000000 01000000 01000000]
        /// </summary>
        public const uint Index32x8x6 = (uint) Index16x8x6 | (uint) Index16x8x6 << 16;

        /// <summary>
        /// [10000000 10000000 10000000 10000000]
        /// </summary>
        public const uint Index32x8x7 = (uint) Index16x8x7 | (uint) Index16x8x7 << 16;

        // ~ Index64x8
        // ~ ------------------------------------------------------------------

        /// <summary>
        /// [00000001 00000001 00000001 00000001 00000001 00000001 00000001]
        /// </summary>
        public const ulong Index64x8x0 = (ulong) Index32x8x0 | (ulong) Index32x8x0 << 32;

        /// <summary>
        /// [00000010 00000010 00000010 00000010 00000010 00000010 00000010 00000010]
        /// </summary>
        public const ulong Index64x8x1 = (ulong) Index32x8x1 | (ulong) Index32x8x1 << 32;

        /// <summary>
        /// [00000100 00000100 00000100 00000100 00000100 00000100 00000100 00000100]
        /// </summary>
        public const ulong Index64x8x2 = (ulong) Index32x8x2 | (ulong) Index32x8x2 << 32;

        /// <summary>
        /// [00001000 00001000 00001000 00001000 00001000 00001000 00001000 00001000]
        /// </summary>
        public const ulong Index64x8x3 = (ulong) Index32x8x3 | (ulong) Index32x8x3 << 32;

        /// <summary>
        /// [00010000 00010000 00010000 00010000 00010000 00010000 00010000 00010000]
        /// </summary>
        public const ulong Index64x8x4 = (ulong) Index32x8x4 | (ulong) Index32x8x4 << 32;

        /// <summary>
        /// [00100000 00100000 00100000 00100000 00100000 00100000 00100000 00100000]
        /// </summary>
        public const ulong Index64x8x5 = (ulong) Index32x8x5 | (ulong) Index32x8x5 << 32;

        /// <summary>
        /// [01000000 01000000 01000000 01000000 01000000 01000000 01000000 01000000]
        /// </summary>
        public const ulong Index64x8x6 = (ulong) Index32x8x6 | (ulong) Index32x8x6 << 32;

        /// <summary>
        /// [10000000 10000000 10000000 10000000 10000000 10000000 10000000 10000000]
        /// </summary>
        public const ulong Index64x8x7 = (ulong) Index32x8x7 | (ulong) Index32x8x7 << 32;

        /// <summary>
        /// [00000010 00000001]
        /// </summary>
        public const ulong Increment16 =
            (ulong) Index8x8x0 << 0 | (ulong) Index8x8x1 << 8;

        /// <summary>
        /// [00000100 00000010 00000001]
        /// </summary>
        public const ulong Increment24 =
            (ulong) Index8x8x0 << 0 | (ulong) Index8x8x1 << 8 | (ulong) Index8x8x2 << 16;

        /// <summary>
        /// [00001000 00000100 00000010 00000001]
        /// </summary>
        [BinaryLiteral("[00001000 00000100 00000010 00000001]")]
        public const ulong Increment32 =
            (ulong) Index8x8x0 << 0 | (ulong) Index8x8x1 << 8 | (ulong) Index8x8x2 << 16 | (ulong) Index8x8x3 << 24;

        /// <summary>
        /// [00010000 00001000 00000100 00000010 00000001]
        /// </summary>
        [BinaryLiteral("[00010000 00001000 00000100 00000010 00000001]")]
        public const ulong Increment40 =
            (ulong) Index8x8x0 << 0 | (ulong) Index8x8x1 << 8 | (ulong) Index8x8x2 << 16 | (ulong) Index8x8x3 << 24 |
            (ulong) Index8x8x4 << 32;

        /// <summary>
        /// [00100000 00010000 00001000 00000100 00000010 00000001]
        /// </summary>
        [BinaryLiteral("[00100000 00010000 00001000 00000100 00000010 00000001]")]
        public const ulong Increment48 =
            (ulong) Index8x8x0 << 0 | (ulong) Index8x8x1 << 8 | (ulong) Index8x8x2 << 16 | (ulong) Index8x8x3 << 24 |
            (ulong) Index8x8x4 << 32 | (ulong) Index8x8x5 << 40;

        /// <summary>
        /// [01000000 00100000 00010000 00001000 00000100 00000010 00000001]
        /// </summary>
        [BinaryLiteral("[01000000 00100000 00010000 00001000 00000100 00000010 00000001]")]
        public const ulong Increment56 =
            (ulong) Index8x8x0 << 0 | (ulong) Index8x8x1 << 8 | (ulong) Index8x8x2 << 16 | (ulong) Index8x8x3 << 24 |
            (ulong) Index8x8x4 << 32 | (ulong) Index8x8x5 << 40 | (ulong) Index8x8x6 << 48;

        /// <summary>
        /// [10000000 01000000 00100000 00010000 00001000 00000100 00000010 00000001]
        /// </summary>
        [BinaryLiteral("[10000000 01000000 00100000 00010000 00001000 00000100 00000010 00000001]")]
        public const ulong Increment64 =
            (ulong) Index8x8x0 << 0 | (ulong) Index8x8x1 << 8 | (ulong) Index8x8x2 << 16 | (ulong) Index8x8x3 << 24 |
            (ulong) Index8x8x4 << 32 | (ulong) Index8x8x5 << 40 | (ulong) Index8x8x6 << 48 | (ulong) Index8x8x7 << 56;
    }

}