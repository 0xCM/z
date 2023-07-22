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
        /// <summary>
        /// Applies a cross-lane permutation over 8 32-bit source vector segments
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="spec">The perm spec</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vperm8x32<T>(Vector256<T> src, Vector256<uint> spec)
            where T : unmanaged
                => vperm8x32_u(src,spec);

        [MethodImpl(Inline)]
        static Vector256<T> vperm8x32_u<T>(Vector256<T> src, Vector256<uint> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vperm8x32(v8u(src), spec));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vperm8x32(v16u(src), spec));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vperm8x32(v32u(src), spec));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vperm8x32(v64u(src), spec));
            else
                return vperm8x32_i(src,spec);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vperm8x32_i<T>(Vector256<T> src, Vector256<uint> spec)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vperm8x32(v8i(src), spec));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vperm8x32(v16i(src), spec));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vperm8x32(v32i(src), spec));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vperm8x32(v64i(src), spec));
            else
                throw no<T>();
        }
    }
}