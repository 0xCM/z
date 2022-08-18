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
        public static bit eq<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.eq(a.Scalar, b.Scalar);

        [MethodImpl(Inline)]
        public static bit eq<E,T>(@enum<E,T> a, T b)
            where E : unmanaged
            where T : unmanaged
                => gmath.eq(a.Scalar, b);

        [MethodImpl(Inline)]
        public static bit eq<E,T>(T a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.eq(a, b.Scalar);

        [MethodImpl(Inline)]
        public static bit eq<E>(E e1, E e2)
            where E : unmanaged
        {
            if(size<E>() == 1)
                return math.eq(uint8(e1), uint8(e2));
            else if(size<E>() == 2)
                return math.eq(uint16(e1), uint16(e2));
            else if(size<E>() == 4)
                return math.eq(uint32(e1), uint32(e2));
            else
                return math.eq(uint64(e1), uint64(e2));
        }

        /// <summary>
        /// Determines equality between an enum literal and an integral scalar value
        /// </summary>
        /// <param name="e">The enum literal value</param>
        /// <param name="s">The scalar value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static bit same<E,T>(E e, T s)
            where E : unmanaged
            where T : unmanaged
                => gmath.eq(@as<E,T>(e), s);

        [MethodImpl(Inline)]
        public static bit between<E,T>(T s, E e0, E e1)
            where E : unmanaged
            where T : unmanaged
                => gmath.between(s, @as<E,T>(e0), @as<E,T>(e1));

        [MethodImpl(Inline)]
        public static bit gt<E,T>(E e, T s)
            where E : unmanaged
            where T : unmanaged
                => gmath.gt(@as<E,T>(e), s);

        [MethodImpl(Inline)]
        public static bit gt<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.lt(a.Scalar, b.Scalar);

        [MethodImpl(Inline)]
        public static bit gt<E,T>(@enum<E,T> e, T s)
            where E : unmanaged
            where T : unmanaged
                => gmath.gt(e.Scalar, s);

        [MethodImpl(Inline)]
        public static bit gt<E,T>(T a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.gt(a, b.Scalar);

        [MethodImpl(Inline)]
        public static bit gteq<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.lteq(a.Scalar, b.Scalar);

        [MethodImpl(Inline)]
        public static bit gteq<E,T>(in E e, T s)
            where E : unmanaged
            where T : unmanaged
                => gmath.gt(@as<E,T>(e), s);

        [MethodImpl(Inline)]
        public static bit gteq<E,T>(T s, in E e)
            where E : unmanaged
            where T : unmanaged
                => gmath.gt(s, @as<E,T>(e));

        [MethodImpl(Inline)]
        public static bit lt<E,T>(in E e, T s)
            where E : unmanaged
            where T : unmanaged
                => gmath.lt(@as<E,T>(e), s);

        [MethodImpl(Inline)]
        public static bit lt<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.lt(a.Scalar, b.Scalar);

        [MethodImpl(Inline)]
        public static bit lteq<E,T>(in E e, T s)
            where E : unmanaged
            where T : unmanaged
                => gmath.lteq(@as<E,T>(e), s);

        [MethodImpl(Inline)]
        public static bit lteq<E,T>(T s, E e)
            where E : unmanaged
            where T : unmanaged
                => gmath.lteq(s, @as<E,T>(e));

        [MethodImpl(Inline)]
        public static bit lteq<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.lteq(a.Scalar, b.Scalar);

        [MethodImpl(Inline)]
        public static bit neq<E,T>(@enum<E,T> a, @enum<E,T> b)
            where E : unmanaged
            where T : unmanaged
                => gmath.neq(a.Scalar, b.Scalar);

        [MethodImpl(Inline)]
        public static bit nonz<E,T>(@enum<E,T> a)
            where E : unmanaged
            where T : unmanaged
                => gmath.nonz(a.Scalar);
    }
}