//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct gcalc
{
    /// <summary>
    /// Slices an interval into manageable pieces, disjoint even
    /// </summary>
    /// <param name="src">The source interval</param>
    /// <param name="width">The partition width</param>
    /// <param name="precision">The precision with which the calculations are carried out</param>
    /// <typeparam name="T">The primal numeric type over which the interval is defined</typeparam>
    [Op, Closures(Integers)]
    public static Index<T> partition<T>(Interval<T> src, T width, int? precision = null)
        where T : unmanaged, IEquatable<T>
    {
        var dst = list<T>();
        var scale = precision ?? 4;
        if(src.LeftClosed)
            dst.Add(src.Left);

        var next = gfp.round(gmath.add(src.Left, width), scale);
        while(gmath.lt(next,src.Right))
        {
            dst.Add(next);
            next = gfp.round(gmath.add(next, width), scale);
        }

        if(src.RightClosed)
            dst.Add(src.Right);

        return dst.ToArray();
    }

    public static Index<T> partition<T>(Interval<T> src)
        where T : unmanaged, IEquatable<T>
    {
        var left = bw64i(src.Left);
        var right = bw64i(src.Right);
        var min = (src.Closed || src.LeftClosed) ? left : left + 1;
        var max = (src.Closed || src.RightClosed) ? right : right - 1;
        var count = max - min + 1;
        var dst = sys.empty<T>();
        if(count > 0)
        {
            var k = min;
            dst = alloc<T>(count);
            for(var i=0; i<count; i++,k++)
                seek(dst,i) = Numeric.force<T>(k);
        }
        return dst;
    }
}
