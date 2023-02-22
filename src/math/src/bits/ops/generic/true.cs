//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class gbits
    {
        [MethodImpl(Inline), True, Closures(Integers)]
        public static T @true<T>()
            where T:unmanaged
                => sys.ones<T>();

        [MethodImpl(Inline), True, Closures(Integers)]
        public static T @true<T>(T a)
            where T:unmanaged
                => @true<T>();

        [MethodImpl(Inline), True, Closures(Integers)]
        public static T @true<T>(T a, T b)
            where T:unmanaged
                => @true<T>();
    }
}