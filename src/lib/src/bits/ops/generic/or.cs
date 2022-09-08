//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Numeric;

    using BL = math;

    partial class gbits
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

        [MethodImpl(Inline)]
        static T or_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(BL.or(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(ushort))
                return force<T>(BL.or(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(BL.or(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(BL.or(uint64(a), uint64(b)));
            else
                return or_i(a,b);
        }

        [MethodImpl(Inline)]
        static T or_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(BL.or(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(short))
                return force<T>(BL.or(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(BL.or(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(BL.or(int64(a), int64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T or_u<T>(T a, T b, T c)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(BL.or(uint8(a), uint8(b), uint8(c)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(BL.or(uint16(a), uint16(b), uint16(c)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(BL.or(uint32(a), uint32(b), uint32(c)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(BL.or(uint64(a), uint64(b), uint64(c)));
            else
                return or_i(a,b,c);
        }

        [MethodImpl(Inline)]
        static T or_i<T>(T a, T b, T c)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(BL.or(int8(a), int8(b), int8(c)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(BL.or(int16(a), int16(b), int16(c)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(BL.or(int32(a), int32(b), int32(c)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(BL.or(int64(a), int64(b), int64(c)));
            else
                throw no<T>();
        }
    }
}