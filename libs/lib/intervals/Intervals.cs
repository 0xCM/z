//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly partial struct Intervals
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static IntervalRange<T,W> range<T,W>(T name, W min, W max)
            where W : unmanaged ,IEquatable<W>, IComparable<W>
                => new IntervalRange<T,W>(name, (min, max));

        public static IntervalComparer<T> comparer<T>()
            where T : unmanaged, IComparable<T>, IEquatable<T>
                => default;

        [MethodImpl(Inline)]
        static ulong left<T>(in ClosedInterval<T> src)
            where T : unmanaged, IEquatable<T>
                => uint64(src.Min);

        [MethodImpl(Inline)]
        static ulong right<T>(in ClosedInterval<T> src)
            where T : unmanaged, IEquatable<T>
                => uint64(src.Max);

        public static string format<T>(ClosedIntervals<T> src)
            where T : unmanaged, IEquatable<T>
        {
            var dst = text.buffer();
            dst.Append("<<");
            for(var i=0u; i<src.SegCount; i++)
                dst.Append(src.Range(i).Format());
            dst.Append(">>");
            return dst.Emit();
        }
    }
}