//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static Type type<T>()
            => typeof(T);

        [MethodImpl(Options), Op]
        public static Type type(object src)
            => src?.GetType() ?? typeof(void);
    }
}