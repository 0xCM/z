//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

partial struct gcalc
{
    /// <summary>
    /// Computes the smallest/greatest bin counts
    /// </summary>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ClosedInterval<uint> bounds<T>(in Histogram<T> src)
        where T : unmanaged, IEquatable<T>, IComparable<T>
            => (src.Counts.Min(), src.Counts.Max());
}
