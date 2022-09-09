//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using G = HashCodes.Generic;

    partial class sys
    {
        [MethodImpl(Inline)]
        public static Hash32 hash<A>(A src)
            => G.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash<A,B>(A a, B b)
            => (Hash32)G.hash(a) | (Hash32)G.hash(b);

        [MethodImpl(Inline)]
        public static Hash32 hash<A,B,C>(A a, B b, C c)
            => (Hash32)G.hash(a) | (Hash32)G.hash(b) | (Hash32)G.hash(c);

        [MethodImpl(Inline)]
        public static Hash32 hash<A,B,C,D>(A a, B b, C c, D d)
            => (Hash32)G.hash(a) | (Hash32)G.hash(b) | (Hash32)G.hash(c) | (Hash32)G.hash(d);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(ReadOnlySpan<T> src)
            => G.hash(src);
    }
}