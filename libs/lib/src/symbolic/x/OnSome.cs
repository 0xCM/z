//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        /// <summary>
        /// Invokes an action if the source string is nonempty
        /// </summary>
        /// <param name="s">The string to evaluate</param>
        /// <param name="f">The action to conditionally invoke</param>
        [TextUtility]
        public static void OnSome(this string s, Action<string> f)
        {
            if(!string.IsNullOrWhiteSpace(s))
                f(s);
        }
    }
}