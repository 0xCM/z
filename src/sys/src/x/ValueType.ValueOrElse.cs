//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T ValueOrElse<T>(this T? x,  Func<T> @else)
            where T : struct
                => x != null ? x.Value : @else();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T ValueOrElse<T>(this T? x, T @else)
            where T : struct
                => x != null ? x.Value : @else;
    }
}