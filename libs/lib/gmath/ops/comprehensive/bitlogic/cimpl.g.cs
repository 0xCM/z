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

    using BL = math;

    partial class gmath
    {
        /// <summary>
        /// Computes the converse implication c := ~a | b integral values a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CImpl, Closures(Integers)]
        public static T cimpl<T>(T a, T b)
            where T : unmanaged
                => cimpl_u(a,b);

        [MethodImpl(Inline)]
        static T cimpl_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return force<T>(BL.cimpl(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(ushort))
                return force<T>(BL.cimpl(force<T,uint>(a), force<T,uint>(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(BL.cimpl(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(BL.cimpl(uint64(a), uint64(b)));
            else
                return cimpl_i(a,b);
        }

        [MethodImpl(Inline)]
        static T cimpl_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(BL.cimpl(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(short))
                return force<T>(BL.cimpl(force<T,int>(a), force<T,int>(b)));
            else if(typeof(T) == typeof(int))
                return generic<T>(BL.cimpl(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                return generic<T>(BL.cimpl(int64(a), int64(b)));
            else
                throw Unsupported.define<T>();
        }
    }
}