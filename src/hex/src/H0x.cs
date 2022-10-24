//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = HexDigitFacets;

    [ApiHost]
    public partial class H0x
    {
        /// <summary>
        /// Determines whether a character corresponds to one of the lower hex codes
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool scalar(AsciCode c)
            => (HexDigitCode)c >= XF.MinScalarCode && (HexDigitCode)c <= XF.MaxScalarCode;

        /// <summary>
        /// Determines whether a character corresponds to one of the lower hex codes
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool scalar(char c)
            => scalar((AsciCode)c);

        /// <summary>
        /// Determines whether a character corresponds to one of the lowercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool lower(AsciCode c)
            => (HexDigitCode)c >= XF.MinLetterCodeL && (HexDigitCode)c <= XF.MaxLetterCodeL;

        /// <summary>
        /// Determines whether a character corresponds to one of the lowercase hex code characters
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool lower(char c)
            => lower((AsciCode)c);

        /// <summary>
        /// Retrieves the character corresponding to a specified <see cref='HexDigitValue'/>
        /// </summary>
        /// <param name="case">The case specifier</param>
        /// <param name="value">The digit value</param>
        [MethodImpl(Inline), Op]
        public static char lower(HexDigitValue value)
            => (char)symbol(LowerCase, value);
    }
}