//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        /// <summary>
        /// Reduces a stream to a single value via a specified monoid
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The stream element type</typeparam>
        [MethodImpl(Inline)]
        public static T fold<H,T>(ReadOnlySpan<T> src, H monoid)
            where T : struct
            where H : struct, IMonoid<H,T>
        {
            var result = monoid.Identity;
            var count = src.Length;
            for(var i=0u; i<count; i++)
                result = monoid.Compose(result, Spans.skip(src,i));
            return result;
        }
    }
}