//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Creates a <see cref='Index{T}'/> from an enumerable <typeparamref name='T'/> cell sequence
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Index<T> Index<T>(this IEnumerable<T> src)
            => sys.array(src);
    }
}