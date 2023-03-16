//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
   {
        /// <summary>
        /// Tests whether the source string is non-blank where blank := {null | whitespace}
        /// </summary>
        /// <param name="src">The string to evaluate</param>
        [MethodImpl(Inline), Op]
        public static bool nonempty(string src)
            => !string.IsNullOrWhiteSpace(src);

        /// Tests whether a specified <see cref='char'/> has a nozero value
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static bool nonempty(char src)
            => src != Chars.Null;
    }
}