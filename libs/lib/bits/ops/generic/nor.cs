//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Numeric;

    using BL = math;

    partial class gbits
    {
        /// <summary>
        /// Computes the bitwise nor c := ~(a | b) for integral values a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Nor, Closures(Integers)]
        public static T nor<T>(T a, T b)
            where T : unmanaged
                => nor_u(a,b);

        [MethodImpl(Inline)]
        static T nor_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(BL.nor(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(ushort))
                return force<T>(BL.nor(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(BL.nor(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(BL.nor(uint64(a), uint64(b)));
            else
                return nor_i(a,b);
        }

        [MethodImpl(Inline)]
        static T nor_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(BL.nor(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(short))
                return force<T>(BL.nor(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(int))
                return generic<T>(BL.nor(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                return generic<T>(BL.nor(int64(a), int64(b)));
            else
                throw no<T>();
        }
    }
}