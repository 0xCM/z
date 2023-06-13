//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        /// <summary>
        /// Encloses supplied text in quotation marks
        /// </summary>
        /// <param name="content">The content to be quoted</param>
        [TextUtility]
        public static string Enquote(this string content)
            => $"{Chars.Quote}{content}{Chars.Quote}";
    }
}