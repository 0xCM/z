//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Creates a <typeparamref name='T'/> cell array from an enumerable <typeparamref name='T'/> cell sequence
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T[] Array<T>(this IEnumerable<T> src)
            => sys.array(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Span<T> Span<T>(this IEnumerable<T> src)
            => sys.array(src);

        [MethodImpl(Inline)]
        public static T[] Array<T>(this T[] src)
            => src;
    }
}