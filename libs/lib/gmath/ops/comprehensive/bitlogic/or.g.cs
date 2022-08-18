//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Numeric;
    using static Refs;
    using static ScalarCast;

    partial class gmath
    {
        /// <summary>
        /// Computes the bitwise or between two primal values
        /// </summary>
        /// <param name="a">The left value</param>
        /// <param name="b">The right value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Or, Closures(Integers)]
        public static T or<T>(T a, T b)
            where T : unmanaged
                => or_u(a,b);

        /// <summary>
        /// Computes the bitwise or among three primal values
        /// </summary>
        /// <param name="a">The left value</param>
        /// <param name="b">The right value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T or<T>(T a, T b, T c)
            where T : unmanaged
                => or_u(a,b,c);

        /// <summary>
        /// Computes the bitwise or among four primal values
        /// </summary>
        /// <param name="a">The left value</param>
        /// <param name="b">The right value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T or<T>(T a, T b, T c, T d)
            where T : unmanaged
                => or(or(a,b,c), d);

        /// <summary>
        /// Computes the bitwise or among five primal values
        /// </summary>
        /// <param name="a">The left value</param>
        /// <param name="b">The right value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T or<T>(T a, T b, T c, T d, T e)
            where T : unmanaged
                => or(or(a,b,c), or(d, e));

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T or<T>(T a, T b, T c, T d, T e, T f)
            where T : unmanaged
                => or(or(a,b,c), or(d, e, f));

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T or<T>(T a, T b, T c, T d, T e, T f, T g)
            where T : unmanaged
                => or(
                    or(or(a,b), or(c,d), or(e, f)),
                    g
                    );

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T or<T>(T a, T b, T c, T d, T e, T f, T g, T h)
            where T : unmanaged
                => or(
                    or(or(a,b), or(c,d), or(e, f)),
                    or(g, h)
                    );

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T or<T>(T a, T b, T c, T d, T e, T f, T g, T h, T i)
            where T : unmanaged
                => or(
                    or(or(a,b), or(c,d), or(e, f)),
                    or(g, h, i)
                    );

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T or<T>(T a, T b, T c, T d, T e, T f, T g, T h, T i, T j)
            where T : unmanaged
                => or(
                    or(or(a,b), or(c,d), or(e, f)),
                    or(g, h), or(i,j)
                    );

        [MethodImpl(Inline)]
        static T or_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(math.or(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(ushort))
                return force<T>(math.or(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.or(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.or(uint64(a), uint64(b)));
            else
                return or_i(a,b);
        }

        [MethodImpl(Inline)]
        static T or_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(math.or(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(short))
                return force<T>(math.or(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.or(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.or(int64(a), int64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T or_u<T>(T a, T b, T c)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return sys.generic<T>(math.or(uint8(a), uint8(b), uint8(c)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.or(uint16(a), uint16(b), uint16(c)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.or(uint32(a), uint32(b), uint32(c)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.or(uint64(a), uint64(b), uint64(c)));
            else
                return or_i(a,b,c);
        }

        [MethodImpl(Inline)]
        static T or_i<T>(T a, T b, T c)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.or(int8(a), int8(b), int8(c)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.or(int16(a), int16(b), int16(c)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.or(int32(a), int32(b), int32(c)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.or(int64(a), int64(b), int64(c)));
            else
                throw no<T>();
        }
    }
}