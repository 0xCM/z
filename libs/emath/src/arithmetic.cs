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
        public static @enum<E,T> add<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => new @enum<E,T>(gmath.add(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static T add<E,T>(@enum<E,T> a, T b)
            where E : unmanaged
            where T : unmanaged
                => gmath.add(a.Scalar, b);

        [MethodImpl(Inline)]
        public static T add<E,T>(T a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.add(a, b.Scalar);

        [MethodImpl(Inline)]
        public static @enum<E,T> div<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => new @enum<E,T>(gmath.div(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static T div<E,T>(@enum<E,T> a, T b)
            where E : unmanaged
            where T : unmanaged
                => gmath.div(a.Scalar, b);

        [MethodImpl(Inline)]
        public static T div<E,T>(T a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.div(a, b.Scalar);

        [MethodImpl(Inline)]
        public static @enum<E,T> mod<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => new @enum<E,T>(gmath.mod(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static T mod<E,T>(@enum<E,T> a, T b)
            where E : unmanaged
            where T : unmanaged
                => gmath.mod(a.Scalar, b);

        [MethodImpl(Inline)]
        public static T mod<E,T>(T a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.mod(a, b.Scalar);

        [MethodImpl(Inline)]
        public static @enum<E,T> mul<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => new @enum<E,T>(gmath.mul(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static T mul<E,T>(@enum<E,T> a, T b)
            where E : unmanaged
            where T : unmanaged
                => gmath.mul(a.Scalar, b);

        [MethodImpl(Inline)]
        public static T mul<E,T>(T a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.mul(a, b.Scalar);

        [MethodImpl(Inline)]
        public static @enum<E,T> negate<E,T>(@enum<E,T> a)
            where E : unmanaged
            where T : unmanaged
                => new @enum<E,T>(gmath.negate(a.Scalar));

        [MethodImpl(Inline)]
        public static @enum<E,T> sub<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => new @enum<E,T>(gmath.sub(a.Scalar, b.Scalar));

        [MethodImpl(Inline)]
        public static T sub<E,T>(@enum<E,T> a, T b)
            where E : unmanaged
            where T : unmanaged
                => gmath.sub(a.Scalar, b);

        [MethodImpl(Inline)]
        public static T sub<E,T>(T a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.sub(a, b.Scalar);

        [MethodImpl(Inline)]
        public static E inc<E>(E src)
            => @as<ulong,E>(++u64(src));

        [MethodImpl(Inline)]
        public static E dec<E>(E src)
            => @as<ulong,E>(--u64(src));

    }
}