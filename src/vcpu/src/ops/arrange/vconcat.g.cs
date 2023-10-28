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
        [MethodImpl(Inline), Concat, Closures(Closure)]
        public static Vector512<T> vconcat<T>(Vector256<T> a, Vector256<T> b)
            where T : unmanaged
                => Vector512.Create(a,b);

        /// <summary>
        /// Creates a 256-bit vector from two 128-bit vectors
        /// This mimics the _mm256_set_m128i intrinsic which does not appear to be available
        /// </summary>
        /// <param name="lo">The lo part</param>
        /// <param name="hi">The hi part</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vconcat<T>(Vector128<T> lo, Vector128<T> hi)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vcpu.vconcat(v8u(lo), v8u(hi)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vcpu.vconcat(v16u(lo), v16u(hi)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vcpu.vconcat(v32u(lo), v32u(hi)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(vcpu.vconcat(v64u(lo), v64u(hi)));
            else
                return vconcat_i(lo,hi);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vconcat_i<T>(Vector128<T> lo, Vector128<T> hi)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vconcat(v8i(lo), v8i(hi)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vconcat(v16i(lo), v16i(hi)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vconcat(v32i(lo), v32i(hi)));
            else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vconcat(v64i(lo), v64i(hi)));
            else
                throw no<T>();
        }
    }
}