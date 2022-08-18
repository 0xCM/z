//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct emath
    {
        [MethodImpl(Inline)]
        public static @enum<E,T> or<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => new @enum<E,T>(gmath.or(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static T or<E,T>(@enum<E,T> a, T b)
            where E : unmanaged
            where T : unmanaged
                => gmath.or(a.Scalar, b);

        [MethodImpl(Inline)]
        public static T or<E,T>(T a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.or(a, b.Scalar);

        [MethodImpl(Inline)]
        public static byte or<E>(E a, byte b)
            where E : unmanaged
                => math.or(bw8(a), b);

        [MethodImpl(Inline)]
        public static ushort or<E>(E a, ushort b)
            where E : unmanaged
                => math.or(bw16(a), b);

        [MethodImpl(Inline)]
        public static uint or<E>(E a, uint b)
            where E : unmanaged
                => math.or(bw32(a), b);

        [MethodImpl(Inline)]
        public static ulong or<E>(E a, ulong b)
            where E : unmanaged
                => math.or(bw64(a), b);

        [MethodImpl(Inline)]
        public static byte or<E>(byte a, E b)
            where E : unmanaged
                => math.or(a, bw8(b));

        [MethodImpl(Inline)]
        public static ushort or<E>(ushort a, E b)
            where E : unmanaged
                => math.or(a, bw16(b));

        [MethodImpl(Inline)]
        public static uint or<E>(uint a, E b)
            where E : unmanaged
                => math.or(a, bw32(b));

        [MethodImpl(Inline)]
        public static ulong or<E>(ulong a, E b)
            where E : unmanaged
                => math.or(a, bw64(b));

        [MethodImpl(Inline)]
        public static byte or8<E1,E2>(E1 a, E2 b)
            where E1 : unmanaged
            where E2 : unmanaged
                => math.or(bw8(a), bw8(b));

        [MethodImpl(Inline)]
        public static ushort or16<E1,E2>(E1 a, E2 b)
            where E1 : unmanaged
            where E2 : unmanaged
                => math.or(bw16(a), bw16(b));

        [MethodImpl(Inline)]
        public static uint or32<E1,E2>(E1 a, E2 b)
            where E1 : unmanaged
            where E2 : unmanaged
                => math.or(bw32(a), bw32(b));

        [MethodImpl(Inline)]
        public static ulong or64<E1,E2>(E1 a, E2 b)
            where E1 : unmanaged
            where E2 : unmanaged
                => math.or(bw64(a), bw64(b));
    }
}