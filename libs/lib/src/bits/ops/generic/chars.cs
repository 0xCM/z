//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gbits
    {
        /// <summary>
        /// Constructs a sequence of n characters {ci} := [c_n-1,..., c_0]
        /// over the domain {'0','1'} according to whether the bit in the i'th
        /// position of the source is respectively disabled/enabled
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void chars<T>(T src, Span<char> dst, int offset = 0)
            where T : unmanaged
                => BitStringStore.bitchars(src,dst,offset);

        /// <summary>
        /// Constructs a sequence of n characters {ci} := [c_n-1,..., c_0]
        /// over the domain {'0','1'} according to whether the bit in the i'th
        /// position of the source is respectively disabled/enabled
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [Op, Closures(Closure)]
        public static ReadOnlySpan<char> chars<T>(in T src)
            where T : unmanaged
        {
            var dst = core.alloc<char>(width<T>());
            chars(src, dst);
            return dst;
        }

        /// <summary>
        /// Converts a span of primal values to a span of characters, each of which represent a bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [Op, Closures(Closure)]
        public static Span<char> chars<T>(ReadOnlySpan<T> src, int? maxlen = null)
            where T : unmanaged
        {
            var seglen = (int)width<T>();
            var srclen = src.Length;
            Span<char> dst = core.alloc<char>(srclen * seglen);
            ref readonly var input = ref first(src);
            for(var i=0; i<srclen; i++)
                chars(skip(input,i)).CopyTo(dst, i*seglen);
            return maxlen != null && dst.Length >= maxlen ?  dst.Slice(0,maxlen.Value) :  dst;
        }

        [Op, Closures(Closure)]
        public static Span<char> chars<T>(Span<T> src, int? maxlen = null)
            where T : unmanaged
                => chars(src.ReadOnly(), maxlen);
    }
}