//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class ClrQuery
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool IsSome<T>(this T? src)
            where T : struct
                => src.HasValue;
    }
}