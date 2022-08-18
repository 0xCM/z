//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static void OnNone(this bit x, Action f)
        {
            if(!x)
                f();
        }

        [MethodImpl(Inline), Op]
        public static void OnNone(this bool x, Action f)
        {
            if(!x)
                f();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void OnNone<T>(this T? x, Action f)
            where T : struct
        {
            if(!x.HasValue)
                f();
        }
    }
}