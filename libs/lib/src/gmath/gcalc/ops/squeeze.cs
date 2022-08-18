//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        /// <summary>
        /// Evenly projects points from the interval [0,maxval[T]] onto the interval [0,max]
        /// </summary>
        /// <param name="src">The value to contract</param>
        /// <param name="max">The maximum value in the target interval</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T squeeze<T>(T src, T max)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.squeeze(uint8(src), uint8(max)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.squeeze(uint16(src), (uint16(max))));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.squeeze(uint32(src), (uint32(max))));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.squeeze(uint64(src), (uint64(max))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Closures(Closure)]
        public static void squeeze<T>(in T src, in T max, ref T dst, uint count)
            where T : unmanaged
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = squeeze(skip(src,i), skip(max,i));
        }

        [MethodImpl(Inline), Closures(Closure)]
        public static void squeeze<T>(ReadOnlySpan<T> src, ReadOnlySpan<T> max, Span<T> dst)
            where T : unmanaged
        {
            squeeze(first(src),first(max), ref first(dst), (uint)dst.Length);
        }

        [MethodImpl(Inline), Closures(Closure)]
        public static Span<T> squeeze<T>(ReadOnlySpan<T> src, ReadOnlySpan<T> max)
            where T : unmanaged
        {
            var count = (uint)src.Length;
            var dst = span<T>(count);
            squeeze<T>(first(src), first(max), ref first(dst), count);
            return dst;
        }
    }
}