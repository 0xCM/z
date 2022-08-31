//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gfp
    {
        [MethodImpl(Inline), Nonz, Closures(Floats)]
        public static bit nonz<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fmath.nonz(float32(a));
            else if(typeof(T) == typeof(double))
                return fmath.nonz(float64(a));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Eq, Closures(Closure)]
        public static int cmp<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return fmath.cmp(float32(a), float32(b));
            else if(typeof(T) == typeof(double))
                 return fmath.cmp(float64(a), float64(b));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Eq, Closures(Closure)]
        public static bit eq<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return fmath.eq(float32(a), float32(b));
            else if(typeof(T) == typeof(double))
                 return fmath.eq(float64(a), float64(b));
            else
                throw no<T>();
        }


        [MethodImpl(Inline), Neq, Closures(Closure)]
        public static bit neq<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return fmath.neq(float32(a), float32(b));
            else if(typeof(T) == typeof(double))
                 return fmath.neq(float64(a), float64(b));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Lt, Closures(Closure)]
        public static bit lt<T>(T lhs, T rhs)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return fmath.lt(float32(lhs), float32(rhs));
            else if(typeof(T) == typeof(double))
                 return fmath.lt(float64(lhs), float64(rhs));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), LtEq, Closures(Closure)]
        public static bit lteq<T>(T lhs, T rhs)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return fmath.lteq(float32(lhs), float32(rhs));
            else if(typeof(T) == typeof(double))
                 return fmath.lteq(float64(lhs), float64(rhs));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Gt, Closures(Closure)]
        public static bit gt<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return fmath.gt(float32(a), float32(b));
            else if(typeof(T) == typeof(double))
                 return fmath.gt(float64(a), float64(b));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), GtEq, Closures(Closure)]
        public static bit gteq<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return fmath.gteq(float32(a), float32(b));
            else if(typeof(T) == typeof(double))
                 return fmath.gteq(float64(a), float64(b));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T min<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.min(float32(a), float32(b)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.min(float64(a), float64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T max<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.max(float32(a), float32(b)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.max(float64(a), float64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit within<T>(T a, T b, T delta)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fmath.within(float32(a),float32(b), float32(delta));
            else if(typeof(T) == typeof(double))
                return fmath.within(float64(a), float64(b), float64(delta));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Between, Closures(Closure)]
        public static bit between<T>(T x, T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fmath.between(float32(x),float32(a), float32(b));
            else if(typeof(T) == typeof(double))
                return fmath.between(float64(x), float64(a), float64(b));
            else
                throw no<T>();
        }
    }
}