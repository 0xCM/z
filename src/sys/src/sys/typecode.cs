//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static TypeCode typecode<T>()
            => Type.GetTypeCode(typeof(T));

        [MethodImpl(Options), Op]
        public static TypeCode typecode(Type src)
            => Type.GetTypeCode(src);
    }
}