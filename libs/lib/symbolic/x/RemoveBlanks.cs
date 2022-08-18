//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Chars;

    partial class XText
    {
        /// <summary>
        /// Removes whitespace characters from a string
        /// </summary>
        /// <param name="src">The source string</param>
        [TextUtility]
        public static string RemoveBlanks(this string src)
            => src.RemoveAny(core.array(Space, CR, NL, Tab));
    }
}