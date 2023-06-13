//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    partial class XText
    {
        /// <summary>
        /// Creates a stream of replicated strings
        /// </summary>
        /// <param name="src">The character to replicate</param>
        /// <param name="count">The replication count</param>
        [TextUtility]
        public static IEnumerable<string> Replicate(this string src, int count)
        {
            for(var i=0; i<count; i++)
                yield return src;
        }

        /// <summary>
        /// Creates a span of replicated characters
        /// </summary>
        /// <param name="src">The character to replicate</param>
        /// <param name="count">The replication count</param>
        [TextUtility]
        public static IEnumerable<char> Replicate(this char src, int count)
            => new string(src,count);
    }
}