//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        /// <summary>
        /// Determines whether a specified <see cref='string'/> ends with a specified <see cref='string'/>
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="match">The match text</param>
        [Op]
        public static bit tail(string src, string match)
        {
            if(nonempty(src) && nonempty(match))
                return src.EndsWith(match, Invariant);
            return false;
        }

        /// <summary>
        /// Determines whether a specified <see cref='string'/> ends with a specified <see cref='char'/>
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="match">The match text</param>
        [Op]
        public unsafe static bit tail(string src, char match)
        {
            var len = src?.Length ?? 0;
            if(len != 0)
                return src[len - 1] == match;
            else
                return false;
        }
    }
}