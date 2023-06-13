//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Tests whether a specified <see cref='string'/> is either null or of zero length
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline)]
        public static bool empty(string src)
            => string.IsNullOrEmpty(src);

        /// <summary>
        /// Tests whether a specified <see cref='char'/> matches the <see cref='Chars.Null'/> character
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static bool empty(char src)
            => src == Chars.Null;

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<char> src)
            => empty(new string(src));
    }
}