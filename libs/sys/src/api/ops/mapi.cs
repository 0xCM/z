//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        public static T[] mapi<S,T>(ReadOnlySpan<S> rows, Func<int,S,T> f)
        {
            var count = rows.Length;
            var dst = sys.alloc<T>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = f(i, skip(rows,i));
            return dst;
        }

        /// <summary>
        /// Projects a sequence of <typeparamref name='S'/> cells into an allocated <typeparamref name='T'/> indexed cell receiver
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        public static IEnumerable<T> mapi<S,T>(IEnumerable<S> src, Func<int,S,T> f)
        {
            var i=0;
            foreach(var item in src)
                yield return f(i++,item);
        }

        /// <summary>
        /// Projects a sequence of <typeparamref name='S'/> cells into a caller-supplied <typeparamref name='T'/> cell receiver
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> mapi<S,T>(ReadOnlySpan<S> src, Func<int,S,T> f, Span<T> dst)
        {
            var count = Math.Min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst, i)= f((int)i, skip(src, i));
            return dst;
        }
    }
}