//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct emath
    {
        [ApiHost("emath.closures")]
        public class EClosures
        {
            [MethodImpl(Inline), Add, Closures(UInt8k)]
            public static @enum<E8u,T> add<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.add(a, b);

            [MethodImpl(Inline), Sub, Closures(UInt8k)]
            public static @enum<E8u,T> sub<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.sub(a, b);

            [MethodImpl(Inline), Add, Closures(UInt8k)]
            public static @enum<E8u,T> mul<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.mul(a, b);

            [MethodImpl(Inline), Div, Closures(UInt8k)]
            public static @enum<E8u,T> div<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.div(a, b);

            [MethodImpl(Inline), Mod, Closures(UInt8k)]
            public static @enum<E8u,T> mod<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.mod(a, b);

            [MethodImpl(Inline), And, Closures(UInt8k)]
            public static @enum<E8u,T> and<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.and(a, b);

            [MethodImpl(Inline), Or, Closures(UInt8k)]
            public static @enum<E8u,T> or<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.or(a, b);

            [MethodImpl(Inline), Xor, Closures(UInt8k)]
            public static @enum<E8u,T> xor<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.xor(a, b);

            [MethodImpl(Inline), Nand, Closures(UInt8k)]
            public static @enum<E8u,T> nand<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.nand(a, b);

            [MethodImpl(Inline), Nor, Closures(UInt8k)]
            public static @enum<E8u,T> nor<T>(@enum<E8u,T> a, @enum<E8u,T> b)
                where T : unmanaged
                    => emath.nor(a, b);

            [MethodImpl(Inline), Add, Closures(UInt64k)]
            public static @enum<E64u,T> add<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.add(a, b);

            [MethodImpl(Inline), Sub, Closures(UInt64k)]
            public static @enum<E64u,T> sub<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.sub(a, b);

            [MethodImpl(Inline), Add, Closures(UInt64k)]
            public static @enum<E64u,T> mul<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.mul(a, b);

            [MethodImpl(Inline), Div, Closures(UInt64k)]
            public static @enum<E64u,T> div<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.div(a, b);

            [MethodImpl(Inline), Mod, Closures(UInt64k)]
            public static @enum<E64u,T> mod<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.mod(a, b);

            [MethodImpl(Inline), And, Closures(UInt64k)]
            public static @enum<E64u,T> and<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.and(a, b);

            [MethodImpl(Inline), Or, Closures(UInt64k)]
            public static @enum<E64u,T> or<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.or(a, b);

            [MethodImpl(Inline), Xor, Closures(UInt64k)]
            public static @enum<E64u,T> xor<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.xor(a, b);

            [MethodImpl(Inline), Nand, Closures(UInt64k)]
            public static @enum<E64u,T> nand<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.nand(a, b);

            [MethodImpl(Inline), Nor, Closures(UInt64k)]
            public static @enum<E64u,T> nor<T>(@enum<E64u,T> a, @enum<E64u,T> b)
                where T : unmanaged
                    => emath.nor(a, b);
        }

    }
}