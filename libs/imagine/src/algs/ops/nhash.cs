//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using G = HashCodes.Generic;

    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 native<T>(T src)
            where T : unmanaged
                => G.native(src);
                
        [MethodImpl(Inline)]
        public static Hash32 nhash<A,B>(A a, B b)
            where A : unmanaged
            where B : unmanaged
                => G.native(a) | G.native(b);

        [MethodImpl(Inline)]
        public static Hash32 nhash<A,B,C>(A a, B b, C c)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
                => G.native(a) | G.native(b) | G.native(c);

        [MethodImpl(Inline)]
        public static Hash32 nhash<A,B,C,D>(A a, B b, C c, D d)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
                => G.native(a) | G.native(b) | G.native(c) | G.native(d);

        [MethodImpl(Inline)]
        public static Hash32 nhash<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => HashCodes.native(src);
    }
}