//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Deposits a <see cref='ReadOnlySpan{T}'/> into a <see cref='HashSet<T>'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [Op, Closures(Closure)]
        public static HashSet<T> set<T>(ReadOnlySpan<T> src)
        {
            var dst = new HashSet<T>(src.Length);
            deposit(src,dst);
            return dst;
        }

        [Op, Closures(Closure)]
        public static HashSet<T> set<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
        {
            var dst = new HashSet<T>(a.Length + b.Length);
            deposit(a,b,dst);
            return dst;
        }
    }
}