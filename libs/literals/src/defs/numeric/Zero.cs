//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Zero, variously
    /// </summary>
    [LiteralProvider(numeric)]
    public readonly struct Zero
    {
        /// <summary>
        /// The zero-value for an 8-bit signed integer
        /// </summary>
        public const sbyte z8i = 0;

        /// <summary>
        /// The zero-value for an 8-bit unsigned integer
        /// </summary>
        public const byte z8 = 0;

        /// <summary>
        /// The zero-value for a 16-bit signed integer
        /// </summary>
        public const short z16i = 0;

        /// <summary>
        /// The zero-value for a 16-bit unsigned integer
        /// </summary>
        public const ushort z16 = 0;

        /// <summary>
        /// The zero-value for a 32-bit signed integer
        /// </summary>
        public const int z32i = 0;

        /// <summary>
        /// The zero-value for a 32-bit unsigned integer
        /// </summary>
        public const uint z32 = 0;

        /// <summary>
        /// The zero-value for a 64-bit signed integer
        /// </summary>
        public const long z64i = 0;

        /// <summary>
        /// The zero-value for a 64-bit unsigned integer
        /// </summary>
        public const ulong z64 = 0;

        /// <summary>
        /// The zero-value for a 32-bit float
        /// </summary>
        public const float z32f = 0;

        /// <summary>
        /// The zero-value for a 64-bit float
        /// </summary>
        public const double z64f = 0;

        /// <summary>
        /// Zero, presented as a character, expressed with an impressively-short identifier
        /// </summary>
        public const char z16c = (char)0;

        /// <summary>
        /// The zero-value for a bool
        /// </summary>
        public const bool z8b = false;

        /// <summary>
        /// The zero-value for a string
        /// </summary>
        public const string zS = "";
    }
}