//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        /// <summary>
        /// Projects a source span to target span via a supplied transformation
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="f">The transformation</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T[] Map<S,T>(this ReadOnlySpan<S> src, Func<S,T> f)
        {
            var count = (uint)src.Length;
            var dst = sys.alloc<T>(count);
            ref readonly var current = ref first(src);
            ref var target = ref first(dst);
            for(var i= 0u; i<count; i++)
                seek(target,i) = f(skip(src,i));
            return dst;
        }

        [MethodImpl(Inline)]
        public static T[] Map<S,I,T>(this ReadOnlySpan<S> src, Func<I,S,T> f, I rep = default)
            where I : unmanaged
        {
            var count = (uint)src.Length;
            var dst = sys.alloc<T>(count);
            ref readonly var source = ref first(src);
            ref var target = ref first(dst);
            for(var i= 0ul; i<count; i++)
                seek(target,i) = f(@as<ulong,I>(i), skip(source,i));
            return dst;
        }

        [MethodImpl(Inline)]
        public static void Map<S,I,T>(this ReadOnlySpan<S> src, Func<I,S,T> f, Span<T> dst, I rep = default)
            where I : unmanaged
        {
            var count = (uint)src.Length;
            ref readonly var source = ref first(src);
            ref var target = ref first(dst);
            for(var i= 0ul; i<count; i++)
                seek(target,i) = f(@as<ulong,I>(i), skip(source,i));
        }

        [MethodImpl(Inline)]
        public static void Map<S,I,T>(this ReadOnlySpan<S> src, Func<I,S,T> f, ref T target, I rep = default)
            where I : unmanaged
        {
            var count = (uint)src.Length;
            ref readonly var source = ref first(src);
            for(var i= 0ul; i<count; i++)
                seek(target,i) = f(@as<ulong,I>(i), skip(source,i));
        }

        /// <summary>
        /// Projects a source span to target span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T[] Map<S,T>(this Span<S> src, Func<S,T> f)
            => src.ReadOnly().Map(f);

        [MethodImpl(Inline)]
        public static T[] Select<S,T>(this Span<S> src, Func<S,T> f)
            => src.ReadOnly().Map(f);
    }
}