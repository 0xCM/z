//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct IntervalComparer<T> : IComparer<ClosedInterval<T>>, IComparer<Interval<T>>
        where T : unmanaged, IComparable<T>, IEquatable<T>
    {
        [MethodImpl(Inline)]
        public int Compare(ClosedInterval<T> x, ClosedInterval<T> y)
            => gmath.cmp(x.Min, y.Max);

        [MethodImpl(Inline)]
        public int Compare(Interval<T> x, Interval<T> y)
            => gmath.cmp(x.Left, y.Left);
    }
}