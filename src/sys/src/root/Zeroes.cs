//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z = Zero;

    partial struct Root
    {
        /// <summary>
        /// The zero-value for an 8-bit signed integer
        /// </summary>
        public const sbyte z8i = Z.z8i;

        /// <summary>
        /// The zero-value for an 8-bit usigned integer
        /// </summary>
        public const byte z8 = Z.z8;

        /// <summary>
        /// The zero-value for a 16-bit signed integer
        /// </summary>
        public const short z16i = Z.z16i;

        /// <summary>
        /// The zero-value for a 16-bit unsigned integer
        /// </summary>
        public const ushort z16 = Z.z16;

        /// <summary>
        /// The zero-value for a 32-bit signed integer
        /// </summary>
        public const int z32i = Z.z32i;

        /// <summary>
        /// The zero-value for a 32-bit usigned integer
        /// </summary>
        public const uint z32 = Z.z32i;

        /// <summary>
        /// The zero-value for a 64-bit signed integer
        /// </summary>
        public const long z64i = Z.z64i;

        /// <summary>
        /// The zero-value for a 64-bit usigned integer
        /// </summary>
        public const ulong z64 = Z.z64;

        /// <summary>
        /// Zero, presented as a character
        /// </summary>
        public const char z16c = Z.z16c;

        /// <summary>
        /// The zero-value for a 32-bit float
        /// </summary>
        public const float z32f = Z.z32f;

        /// <summary>
        /// The zero-value for a 64-bit float
        /// </summary>
        public const double z64f = Z.z64f;

        /// <summary>
        /// The zero-value for a 128-bit float
        /// </summary>
        public const decimal z128f = 0;

        /// <summary>
        /// The zero-value for a bool
        /// </summary>
        public const bool z8b = Z.z8b;
    }
}