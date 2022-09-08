//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Span<T> Increments<T>(this Interval<T> src)
            where T : unmanaged, IComparable<T>, IEquatable<T>
                => Partitions.increments(src.ToClosed());
    }
}