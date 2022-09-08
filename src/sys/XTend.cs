//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XTend
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Presents a mutable span as a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> ReadOnly<T>(this Span<T> src)
            => src;

        public static T[] Select<S,T>(this ReadOnlySpan<S> src, Func<S,T> f)
        {
            var count = src.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                sys.seek(dst,i) = f(sys.skip(src,i));
            return dst;
        }

        [MethodImpl(Inline)]
        public static bool Test<E>(this E src, E flag)
            where E : unmanaged, Enum
                => (sys.bw64(src) & sys.bw64(flag)) != 0;            
    }
}