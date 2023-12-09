//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;

    partial class vgcpu
    {
        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static Vector128<T> vsrl<T>(Vector128<T> x, [Imm] byte count)
            where T : unmanaged
                => vsrl_u(x,count);

        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static Vector256<T> vsrl<T>(Vector256<T> x, [Imm] byte count)
            where T : unmanaged
                => vsrl_u(x,count);

        [MethodImpl(Inline)]
        static Vector128<T> vsrl_u<T>(Vector128<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsrl(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsrl(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsrl(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsrl(v64u(x), count));
            else
                return vsrl_i(x,count);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsrl_i<T>(Vector128<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsrl(v8i(x), count));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsrl(v16i(x), count));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsrl(v32i(x), count));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsrl(v64i(x), count));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsrl_u<T>(Vector256<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vsrl(v8u(x), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vsrl(v16u(x), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vsrl(v32u(x), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vsrl(v64u(x), count));
            else
                return vsrl_i(x,count);
       }

        [MethodImpl(Inline)]
        static Vector256<T> vsrl_i<T>(Vector256<T> x, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsrl(v8i(x), count));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsrl(v16i(x), count));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsrl(v32i(x), count));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsrl(v64i(x), count));
            else
                throw no<T>();
        }
    }
}