//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Intervals
{
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static T length<T>(Interval<T> src)
        where T : unmanaged,IEquatable<T>
            => gmath.abs(gmath.sub(src.Right, src.Left));

}