//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NumericKinds
    {
        /// <summary>
        /// Converts a numeric indicator to a character
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static char @char(NumericIndicator src)
            => (char)src;

        /// <summary>
        /// Produces text in the form {'i' | 'u' | 'f'}
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static string format(NumericIndicator src)
            => @char(src).ToString();

        /// <summary>
        /// Produces text in the form {width}{indicator}
        /// </summary>
        /// <param name="k">The source kind</param>
        [MethodImpl(Inline), Op]
        public static string format(NumericKind k)
            => $"{(int)width(k)}{format(indicator(k))}";
    }
}