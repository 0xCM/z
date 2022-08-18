//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Encloses text between '[' and ']' characters
        /// </summary>
        /// <param name="content">The content to enclose</param>
        public static string bracket<T>(T content)
            => enclose($"{content}", Chars.LBracket, Chars.RBracket);
    }
}