//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = UnsignedInts;

        public static T[] Select<S,T>(this ReadOnlySpan<S> src, Func<S,T> f)
        {
            var count = src.Length;
            var dst = new T[count];
            for(var i=0; i<count; i++)
                Arrays.seek(dst,i) = f(Spans.skip(src,i));
            return dst;
        }

        [MethodImpl(Inline)]
        public static bool Test<E>(this E src, E flag)
            where E : unmanaged, Enum
                => (Algs.bw64(src) & Algs.bw64(flag)) != 0;
    }
}