//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public readonly partial struct Intervals
{
    const NumericKind Closure = UnsignedInts;

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
}
