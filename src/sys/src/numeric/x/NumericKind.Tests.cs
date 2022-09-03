//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static NumericKinds;

    partial class XTend
    {
        /// <summary>
        /// Determines whether a numeric kind designates a signed integral type
        /// </summary>
        /// <param name="src">The source kind</typeparam>
        [MethodImpl(Inline), Op]
        public static bool IsSigned(this NumericKind src)
            => signed(src);

        [MethodImpl(Inline)]
        public static bool IsFloat32(this NumericKind src)
            => float32(src);

        [MethodImpl(Inline)]
        public static bool IsFloat64(this NumericKind src)
            => float64(src);

        [MethodImpl(Inline)]
        public static bool IsFractional(this NumericKind src)
            => fractional(src);

        /// <summary>
        /// Determines whether a numeric kind is nonempty
        /// </summary>
        /// <param name="k">The kind to examine</param>
        [MethodImpl(Inline)]
        public static bool IsSome(this NumericKind k)
            => k != 0;

        /// <summary>
        /// Determines whether a numeric kind designates an unsigned integral type
        /// </summary>
        [MethodImpl(Inline)]
        public static bool IsUnsigned(this NumericKind src)
            => unsigned(src);

        [MethodImpl(Inline)]
        public static bool IsInteger(this NumericKind src)
            => integer(src);
    }
}