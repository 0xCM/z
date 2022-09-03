//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    partial struct gcpu
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector256<T> vperm4x64<T>(Vector256<T> x, Perm4L spec)
            where T : unmanaged
                => vperm4x64_u(x, spec);

        [MethodImpl(Inline)]
        static Vector256<T> vperm4x64_u<T>(Vector256<T> x, Perm4L spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(v8u(cpu.vperm4x64(v64u(x), spec)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(v16u(cpu.vperm4x64(v64u(x), spec)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(v32u(cpu.vperm4x64(v64u(x), spec)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vperm4x64(v64u(x), spec));
            else
                return vperm4x64_i(x,spec);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vperm4x64_i<T>(Vector256<T> x, Perm4L spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(v8i(cpu.vperm4x64(v64u(x), spec)));
            else if(typeof(T) == typeof(short))
                return generic<T>(v16i(cpu.vperm4x64(v64u(x), spec)));
            else if(typeof(T) == typeof(int))
                return generic<T>(v32i(cpu.vperm4x64(v64u(x), spec)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vperm4x64(v64i(x), spec));
            else
                return vperm4x64_f(x,spec);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vperm4x64_f<T>(Vector256<T> x, Perm4L spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(v32f(cpu.vperm4x64(v64f(x), spec)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vperm4x64(v64f(x), spec));
            else
                throw no<T>();
        }
    }
}