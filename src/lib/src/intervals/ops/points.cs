//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Intervals
    {
        public static Index<T> points<T>(Interval<T> src)
            where T : unmanaged
        {
            if(src.Degenerate)
                return sys.empty<T>();
            var min = src.LeftClosed ? bw64(src.Left) : (bw64(src.Left) + 1);
            var max = src.RightClosed ? bw64(src.Right) : (bw64(src.Right) - 1);
            var count = max - min;
            var dst = alloc<T>(count);
            for(var i=0ul; i<count; i++)
                seek(dst,i) = generic<T>(min + i);
            return dst;
        }
    }
}