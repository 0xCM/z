//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Tests whether the source string is either empty, null or consists only of whitespace
        /// </summary>
        /// <param name="src">The string to evaluate</param>
        [MethodImpl(Inline), Op]
        public static bool blank(string src)
            => string.IsNullOrWhiteSpace(src);

        [MethodImpl(Inline), Op]
        public static bool blank(ReadOnlySpan<char> src)
            => blank(new string(src));
    }
}