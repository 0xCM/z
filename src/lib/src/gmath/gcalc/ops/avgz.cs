//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        [MethodImpl(Inline), Avg, Closures(AllNumeric)]
        public static T avgz<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            ref readonly var a = ref first(src);
            var result = a;
            for(var i=1; i<src.Length; i++)
                result = gmath.avgz(result, skip(a, i));
            return result;
        }

        [MethodImpl(Inline), Avg, Closures(AllNumeric)]
        public static T avgz<T>(Span<T> src)
            where T : unmanaged
                => avgz(src.ReadOnly());
    }
}