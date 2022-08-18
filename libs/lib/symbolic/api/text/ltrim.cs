//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Trims leading characters when matched
        /// </summary>
        /// <param name="src">The text to manipulate</param>
        /// <param name="chars">The leading characters to remove</param>
        [Op]
        public static string ltrim(string src, params char[] chars)
            => string.IsNullOrWhiteSpace(src) ? EmptyString : src.TrimStart(chars);
    }
}