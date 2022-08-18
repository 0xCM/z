//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using O = OctalDigitFacets;
    using C = AsciCode;

    /// <summary>
    /// Defines operations over character digits
    /// </summary>
    partial struct Digital
    {
        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='OctalDigitCode'/> or <see cref='OctalDigitSym'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base8 @base, char c)
            => (OctalDigitCode)c >= O.MinCode && (OctalDigitCode)c <= O.MaxCode;

        /// <summary>
        /// Determines whether a byte can be interpreted as a <see cref='OctalDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base8 @base, byte c)
            => (OctalDigitValue)c >= O.MinDigit && (OctalDigitValue)c <= O.MaxDigit;

        /// <summary>
        /// Determines whether a code represents an octal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base8 @base, C src)
            => contains(C.d0, C.d7, src);
    }
}