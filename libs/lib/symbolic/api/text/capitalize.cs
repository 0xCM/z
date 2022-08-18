//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Replaces the first character of the source with its capitalized form
        /// </summary>
        /// <param name="src">The source string</param>
        [Op]
        public static string capitalize(string src)
        {
            if(empty(src))
                return EmptyString;

            return src[0].ToUpper() + slice(src,1);
        }
    }
}