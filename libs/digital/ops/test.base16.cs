//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    /// <summary>
    /// Defines operations over character digits
    /// </summary>
    partial struct Digital
    {
        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='HexDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base16 @base, char c)
            => scalar(@base, c) || upper(@base, c) || lower(@base,c);

        /// <summary>
        /// Determines whether a code represents a lowercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, LowerCased @case, C src)
            => SQ.lowerhex(src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> represents a lowercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, LowerCased @case, char src)
            => test(@base, @case, (C)src);

        /// <summary>
        /// Determines whether a code represents an uppercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, UpperCased @case, C src)
            => SQ.upperhex(src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> represents an uppercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, UpperCased @case, char src)
            => test(@base, @case, (C)src);

        /// <summary>
        /// Determines whether a code represents a hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base16 @base, C src)
            => SQ.lowerhex(src) || SQ.upperhex(src);
    }
}