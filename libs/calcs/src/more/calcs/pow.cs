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

    partial struct Calcs
    {
        /// <summary>
        /// Computes the integral exponent of each numeric source cell and deposits the result in a caller-supplied target
        /// </summary>
        /// <param name="bases">The source span</param>
        /// <param name="exp">The exponent value</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Pow, Closures(AllNumeric)]
        public static Span<T> pow<T>(ReadOnlySpan<T> bases, uint exp, Span<T> dst)
            where T : unmanaged
        {
            var count = dst.Length;
            ref readonly var a = ref first(bases);
            ref var results = ref first(dst);
            for(var i=0; i<count; i++)
                seek(results,i) = gmath.pow(skip(a,i), exp);
            return dst;
        }
    }
}