//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    partial class text
    {
        /// <summary>
        /// Returns the index of the first whitespace character, if any
        /// </summary>
        /// <param name="src">The content to search</param>
        [MethodImpl(Inline), Op]
        public static int whitespace(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var found = NotFound;
            for(var i=0; i<count; i++)
            {
                if(SQ.whitespace(core.skip(src,i)))
                {
                    found = i;
                    break;
                }
            }
            return found;
        }

        [Op]
        public static bool member(string src, ISet<string> set, bool partial = true)
        {
            if(partial)
            {
                foreach(var item in set)
                {
                    if(src.Contains(item))
                        return true;
                }
                return false;
            }
            else
                return set.Contains(src);
        }
    }
}