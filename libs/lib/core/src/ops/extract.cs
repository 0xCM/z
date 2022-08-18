//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T extract<T>(T? src)
            where T : struct
                => @as<T?,T>(src);
    }
}