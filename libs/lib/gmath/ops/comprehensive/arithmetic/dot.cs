//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class gmath
    {
        /// <summary>
        /// Imagines the source operands are vectors of identical length and computes their canonical scalar product
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        /// <typeparam name="T">The primal scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T dot<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : unmanaged
        {
            var count = a.Length;
            ref readonly var lSrc = ref first(a);
            ref readonly var rSrc = ref first(b);
            var dst = default(T);
            for(var i = 0; i< count; i++)
                dst = fma(skip(lSrc, i), skip(rSrc,i), dst);
            return dst;
        }
   }
}