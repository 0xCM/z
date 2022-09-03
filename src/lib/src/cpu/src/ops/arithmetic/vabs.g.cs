//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcpu
    {
        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static Vector128<T> vabs<T>(Vector128<T> x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vabs(v8i(x)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vabs(v16i(x)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vabs(v32i(x)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vabs(v64i(x)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static Vector256<T> vabs<T>(Vector256<T> x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vabs(v8i(x)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vabs(v16i(x)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vabs(v32i(x)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vabs(v64i(x)));
            else
                throw no<T>();
        }
    }
}
