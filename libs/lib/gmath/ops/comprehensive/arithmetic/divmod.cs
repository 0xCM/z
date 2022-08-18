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

    partial class gmath
    {
        /// <summary>
        /// Computes div/mod
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), DivMod, Closures(AllNumeric)]
        public static void divmod<T>(T a, T b, out T d, out T m)
            where T : unmanaged
                => divmod_u(a,b,out d, out m);

        [MethodImpl(Inline)]
        static void divmod_u<T>(T a, T b, out T d, out T m)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
            {
                math.divmod(uint8(a), uint8(b), out var _d, out var _m);
                d = generic<T>(_d);
                m = generic<T>(_m);
            }
            else if(typeof(T) == typeof(ushort))
            {
                math.divmod(uint16(a), uint16(b), out var _d, out var _m);
                d = generic<T>(_d);
                m = generic<T>(_m);
            }
            else if(typeof(T) == typeof(uint))
            {
                math.divmod(uint32(a), uint32(b), out var _d, out var _m);
                d = generic<T>(_d);
                m = generic<T>(_m);
            }
            else if(typeof(T) == typeof(ulong))
            {
                math.divmod(uint64(a), uint64(b), out var _d, out var _m);
                d = generic<T>(_d);
                m = generic<T>(_m);
            }
            else
                divmod_i(a,b, out d, out m);
        }

        [MethodImpl(Inline)]
        static void divmod_i<T>(T a, T b, out T d, out T m)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
            {
                math.divmod(int8(a), int8(b), out var _d, out var _m);
                d = generic<T>(_d);
                m = generic<T>(_m);
            }
            else if(typeof(T) == typeof(short))
            {
                math.divmod(int16(a), int16(b), out var _d, out var _m);
                d = generic<T>(_d);
                m = generic<T>(_m);
            }
            else if(typeof(T) == typeof(int))
            {
                math.divmod(int32(a), int32(b), out var _d, out var _m);
                d = generic<T>(_d);
                m = generic<T>(_m);
            }
            else if(typeof(T) == typeof(long))
            {
                math.divmod(int64(a), int64(b), out var _d, out var _m);
                d = generic<T>(_d);
                m = generic<T>(_m);
            }
            else
                throw no<T>();
        }
    }
}
