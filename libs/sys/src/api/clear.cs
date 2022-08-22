//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Fills a span with the element type's default value
        /// </summary>
        /// <param name="src">The target spen</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static Span<T> clear<T>(Span<T> src)
        {
            src.Clear();
            return src;
        }

        /// <summary>
        /// Fills an array with the element type's default value
        /// </summary>
        /// <param name="dst">The target array</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] clear<T>(T[]? dst)
        {
            if(dst == null)
                return empty<T>();
            else
            {
                Array.Fill(dst, default(T));
                return dst;
            }
        }
    }
}