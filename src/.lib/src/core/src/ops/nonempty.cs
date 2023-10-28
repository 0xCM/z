//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Tests whether a specified <see cref='string'/> is nonempty
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static bool nonempty(string src)
            => !string.IsNullOrEmpty(src);

        /// <summary>
        /// Tests whether a specified <see cref='char'/> has a nozero value
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static bool nonempty(char src)
            => src != Chars.Null;
    }
}