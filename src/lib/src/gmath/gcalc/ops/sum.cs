//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong sum<T>(ReadOnlySpan<Bin<T>> bins)
            where T : unmanaged, IEquatable<T>, IComparable<T>
        {
            var sum = 0ul;
            var count = bins.Length;
            for(var i=0u; i<count; i++)
                sum += skip(bins,i).Count;
            return sum;
        }

        [MethodImpl(Inline), Sum, Closures(Closure)]
        public static T sum<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var count = src.Length;
            var result = default(T);
            for(var i=0; i<count; i++)
                result = checked(gmath.add(result, skip(src,i)));
            return result;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong sumzx<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var count = src.Length;
            var result = 0ul;
            for(var i=0; i<count; i++)
                result = checked(math.add(bw64(result), bw64(skip(src,i))));
            return result;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static long sumsx<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var count = src.Length;
            var result = 0L;
            for(var i=0; i<count; i++)
                result = checked(math.add(bw64i(result), bw64i(skip(src,i))));
            return result;
        }

        [MethodImpl(Inline), Sum, Closures(Closure)]
        public static T sum<T>(T[] src)
            where T : unmanaged
        {
            var count = src.Length;
            var result = default(T);
            for(var i=0; i<count; i++)
                result = checked(gmath.add(result, skip(src,i)));
            return result;
        }

        [MethodImpl(Inline)]
        public static T sum<T>(Span<T> src)
            where T : unmanaged
                => sum(src.ReadOnly());
    }
}