// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        public static Index<T> index<T>(params T[] src)
            => src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedIndex<T> index<T>(char sep, params T[] src)
            => new DelimitedIndex<T>(src, sep, 0, null);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedIndex<T> index<T>(char sep, int pad, params T[] src)
            => new DelimitedIndex<T>(src, sep, pad, null);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedIndex<T> index<T>(char sep, int pad, Fence<char> fence, params T[] src)
            => new DelimitedIndex<T>(src, sep, pad, fence);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedIndex<T> index<T>(string sep, params T[] src)
            => new DelimitedIndex<T>(src, sep, 0, null);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedIndex<T> index<T>(string sep, int pad, params T[] src)
            => new DelimitedIndex<T>(src, sep, pad, null);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DelimitedIndex<T> index<T>(string sep, int pad, Fence<char> fence, params T[] src)
            => new DelimitedIndex<T>(src, sep, pad, fence);
    }
}
