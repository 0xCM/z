//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gpack
    {
        [MethodImpl(Inline), Unpack, Closures(Closure)]
        public static Span<Bit32> unpack32<T>(ReadOnlySpan<T> src, Span<Bit32> dst)
            where T : unmanaged
        {
            var srcsize = width<T>();
            var bitcount = width<T>()*src.Length;
            ref var target = ref first(dst);
            var k = 0;
            for(var i=0; i<src.Length; i++)
            for(byte j=0; j<srcsize; j++, k++)
                seek(target, k) = bit.gtest(skip(src,i), j);
            return dst;
        }

        /// <summary>
        /// Extracts each bit from each source element into caller-supplied target at the corresponding index
        /// </summary>
        /// <param name="src">The source values to be unpacked</param>
        /// <param name="dst">The target span of length at least bitsize[T]*length(Span[T])</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Unpack, Closures(Closure)]
        public static Span<Bit32> unpack32<T>(Span<T> src, Span<Bit32> dst)
            where T : unmanaged
                => unpack32(src.ReadOnly(),dst);

        /// <summary>
        /// Extracts each bit from each source element into caller-supplied target at the corresponding index
        /// </summary>
        /// <param name="src">The source values to be unpacked</param>
        /// <param name="dst">The target array of length at least bitsize[T]*length(Span[T])</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Unpack, Closures(Closure)]
        public static Span<Bit32> unpack32<T>(Span<T> src, Bit32[] dst)
            where T : unmanaged
                => unpack32(src, dst.AsSpan());

        /// <summary>
        /// Projects each source bit from each source element into an element of the target span at the corresponding index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The bit target</param>
        /// <typeparam name="T">The bit source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> unpack32<S,T>(ReadOnlySpan<S> src, Span<T> dst)
            where S : unmanaged
            where T : unmanaged
        {
            if(typeof(T) == typeof(Bit32))
                return recover<Bit32,T>(unpack32(src, recover<T,Bit32>(dst)));
            else
            {
                var srcsize = width<S>();
                var bitcount = width<S>()*src.Length;
                var k = 0u;
                for(var i=0; i<src.Length; i++)
                for(byte j=0; j<srcsize; j++)
                    seek(dst,k++) = bit.gtest(skip(src,i), j) == bit.On ? one<T>() : zero<T>();
                return dst;
            }
        }

        [MethodImpl(Inline)]
        public static Span<T> unpack32<S,T>(Span<S> src, Span<T> dst)
            where S : unmanaged
            where T : unmanaged
                => unpack32(src.ReadOnly(), dst);
    }
}