//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Intervals
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool contains<T>(ClosedInterval<T> src, T point)
            where T : unmanaged, IEquatable<T>
        {
            if(size<T>() == 1)
                return u8(point) >= u8(src.Min) && u8(point) <= u8(src.Max);
            else if(size<T>() == 2)
                return u16(point) >= u16(src.Min) && u16(point) <= u16(src.Max);
            else if(size<T>() == 4)
                return u32(point) >= u32(src.Min) && u32(point) <= u32(src.Max);
            else
                return u64(point) >= u64(src.Min) && u64(point) <= u64(src.Max);
        }
    }
}