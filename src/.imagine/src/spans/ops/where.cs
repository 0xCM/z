//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Spans
    {
        /// <summary>
        /// Allocates and populates a new array by filtering the source array with a specified predicate
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f">The predicate</param>
        /// <typeparam name="T">The array element type</typeparam>
        [Op, Closures(Closure)]
        public static Span<T> where<T>(ReadOnlySpan<T> src, Func<T,bool> f)
        {
            Span<T> dst = new T[count(src,f)];
            var k = 0;
            for(var i=0; i<src.Length; i++)
            {
                if(f(skip(src,i)))
                    seek(dst,k++) = skip(src,i);
            }
            return slice(dst,0,k);
        }
    }
}
