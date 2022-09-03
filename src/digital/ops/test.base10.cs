//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using D = DecimalDigitFacets;
    using C = AsciCode;

    using static sys;

    /// <summary>
    /// Defines operations over character digits
    /// </summary>
    partial struct Digital
    {
        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='DecimalDigitCode'/> or <see cref='DecimalDigitSym'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base10 @base, char c)
            => (DecimalDigitCode)c >= D.MinCode && (DecimalDigitCode)c <= D.MaxCode;

        /// <summary>
        /// Determines whether a character can be interpreted as a <see cref='DecimalDigitValue'/>
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(Base10 @base, byte c)
            => (DecimalDigitValue)c >= D.MinDigit && (DecimalDigitValue)c <= D.MaxDigit;

        /// <summary>
        /// Determines whether a code represents a decimal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base10 @base, C src)
            => contains(C.d0, C.d9, src);

        /// <summary>
        /// Determines whether a code represents a decimal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit test(Base10 @base, AsciCharSym src)
            => contains(C.d0, C.d9, (C)src);

        /// <summary>
        /// Returns the index of the first <see cref='Base10'/> digit found in the source
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static int digitIndex(Base10 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(test(base10, skip(src, i)))
                    return i;
            return NotFound;
        }
    }
}