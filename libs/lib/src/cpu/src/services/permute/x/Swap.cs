//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Interchanges span elements i and j
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="i">An index of a span element</param>
        /// <param name="j">An index of a span element</param>
        /// <typeparam name="T">The span element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void Swap<T>(this Span<T> src, uint i, uint j)
            where T : unmanaged
                => Swaps.swap(src,i,j);
    }
}