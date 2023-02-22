//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static void OnSome(this bool x, Action f)
        {
            if(x)
                f();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void OnSome<T>(this T? x, Action<T> f)
            where T : struct
        {
            if(x.HasValue)
                f(x.Value);
        }

        [MethodImpl(Inline), Op]
        public static void OnSome(this bit x, Action f)
        {
            if(x)
                f();
        }
    }
}