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
        /// Defines the test within:bit := dist(a,b) <= delta
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="delta">The tolerance</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Within, Closures(AllNumeric)]
        public static bit within<T>(T a, T b, T delta)
            where T : unmanaged
                => within_u(a,b,delta);

        [MethodImpl(Inline)]
        static bit within_u<T>(T a, T b, T delta)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.within(force<T,uint>(a), force<T,uint>(b), force<T,uint>(delta));
            else if(typeof(T) == typeof(ushort))
                return math.within(force<T,uint>(a), force<T,uint>(b), force<T,uint>(delta));
            else if(typeof(T) == typeof(uint))
                return math.within(uint32(a), uint32(b), uint32(delta));
            else if(typeof(T) == typeof(ulong))
                return math.within(uint64(a), uint64(b), uint64(delta));
            else
                return within_i(a,b,delta);
        }

        [MethodImpl(Inline)]
        static bit within_i<T>(T a, T b, T delta)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return math.within(force<T,int>(a), force<T,int>(b), force<T,int>(delta));
            else if(typeof(T) == typeof(short))
                return math.within(force<T,int>(a), force<T,int>(b), force<T,int>(delta));
            else if(typeof(T) == typeof(int))
                return math.within(int32(a), int32(b), int32(delta));
            else if(typeof(T) == typeof(long))
                return math.within(int64(a), int64(b), int64(delta));
            else
                return gfp.within(a,b,delta);
        }
    }
}