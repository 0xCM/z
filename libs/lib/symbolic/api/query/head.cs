//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        /// <summary>
        /// Determines whether a specified <see cref='string'/> begins with a specified <see cref='string'/>
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="match">The match text</param>
        [Op]
        public static bit head(string src, string match)
        {
            if(nonempty(src) && nonempty(match))
                return src.StartsWith(match, Invariant);
            return false;
        }

        /// <summary>
        /// Determines whether a specified <see cref='string'/> begins with a specified <see cref='char'/>
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="match">The match text</param>
        [Op]
        public static bit head(string src, char match)
        {
            if(nonempty(src))
                return src[0] == match;
            return false;
        }
    }
}