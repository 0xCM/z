//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        [MethodImpl(Inline), Op, Closures(UInt32k)]
        public static bit search<T>(N4 n, in T src, T match, uint offset)
            where T : unmanaged
                => gmath.eq(match, add(src, offset + 0)) ||
                   gmath.eq(match, add(src, offset + 1)) ||
                   gmath.eq(match, add(src, offset + 2)) ||
                   gmath.eq(match, add(src, offset + 3));


        [MethodImpl(Inline), Op, Closures(UInt32k)]
        public static bit search<T>(N8 n, in T src, T match, uint offset)
            where T : unmanaged
                => gmath.eq(match, add(src, offset + 0)) ||
                   gmath.eq(match, add(src, offset + 1)) ||
                   gmath.eq(match, add(src, offset + 2)) ||
                   gmath.eq(match, add(src, offset + 3)) ||
                   gmath.eq(match, add(src, offset + 4)) ||
                   gmath.eq(match, add(src, offset + 5)) ||
                   gmath.eq(match, add(src, offset + 6)) ||
                   gmath.eq(match, add(src, offset + 7)
                    );
    }
}