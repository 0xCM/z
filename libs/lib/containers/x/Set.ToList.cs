//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Creates a read-only list from a source sequence
        /// </summary>
        /// <param name="src">The source sequence</param>
        public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> src)
            => src.ToList();
    }
}