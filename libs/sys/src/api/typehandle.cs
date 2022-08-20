//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op]
        public static IntPtr handle(Type src)
            => src.TypeHandle.Value;

        [MethodImpl(Options), Op, Closures(Closure)]
        public static IntPtr handle<T>()
            => typeof(T).TypeHandle.Value;
    }
}