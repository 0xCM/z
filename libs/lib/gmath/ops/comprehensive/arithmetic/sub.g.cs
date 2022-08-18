//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static Numeric;

    partial class gmath
    {
        /// <summary>
        /// Subtracts the right value from the left
        /// </summary>
        /// <param name="a">The left value</param>
        /// <param name="b">The right value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Sub, Closures(AllNumeric)]
        public static T sub<T>(T a, T b)
            where T : unmanaged
                => sub_u(a,b);

        [MethodImpl(Inline)]
        static T sub_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(math.sub(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(ushort))
                return force<T>(math.sub(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.sub(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.sub(uint64(a), uint64(b)));
            else
                return sub_i(a,b);
        }

        [MethodImpl(Inline)]
        static T sub_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(math.sub(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(short))
                return force<T>(math.sub(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.sub(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.sub(int64(a), int64(b)));
            else
                return gfp.sub(a,b);
        }
    }
}
