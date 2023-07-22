//-----------------------------------------------------------------------------
// Copymask   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;
    
    partial class vgcpu
    {
        /// <summary>
        /// Returns 1 if all mask-identified source bits are disabled, 0 otherwise
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ, Closures(AllNumeric)]
        public static bit vtestz<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
                => vtestz_u(src,mask);

        /// <summary>
        /// Returns 1 if all mask-identified source bits are disabled, 0 otherwise
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ, Closures(AllNumeric)]
        public static bit vtestz<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
                => vtestz_u(src,mask);

        /// <summary>
        /// Returns 1 if all mask-identified source bits are disabled, 0 otherwise
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ, Closures(AllNumeric)]
        public static bit vtestz<T>(in Vector512<T> src, in Vector512<T> mask)
            where T : unmanaged
                => vtestz(vlo(src), vlo(mask)) && vtestz(vhi(src), vhi(mask));

        [MethodImpl(Inline)]
        static bit vtestz_u<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return vcpu.vtestz(v8u(src), v8u(mask));
            else if(typeof(T) == typeof(ushort))
                return vcpu.vtestz(v16u(src), v16u(mask));
            else if(typeof(T) == typeof(uint))
                return vcpu.vtestz(v32u(src), v32u(mask));
            else if(typeof(T) == typeof(ulong))
                return vcpu.vtestz(v64u(src), v64u(mask));
            else
                return vtestz_i(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestz_i<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return vcpu.vtestz(v8i(src), v8i(mask));
            else if(typeof(T) == typeof(short))
                return vcpu.vtestz(v16i(src), v16i(mask));
            else if(typeof(T) == typeof(int))
                return vcpu.vtestz(v32i(src), v32i(mask));
            else if(typeof(T) == typeof(long))
                return vcpu.vtestz(v64i(src), v64i(mask));
            else
                return vtestz_f<T>(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestz_f<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return vcpu.vtestz(v32f(src), v32f(mask));
            else if(typeof(T) == typeof(double))
                return vcpu.vtestz(v64f(src), v64f(mask));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static bit vtestz_u<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return vcpu.vtestz(v8u(src), v8u(mask));
            else if(typeof(T) == typeof(ushort))
                return vcpu.vtestz(v16u(src), v16u(mask));
            else if(typeof(T) == typeof(uint))
                return vcpu.vtestz(v32u(src), v32u(mask));
            else if(typeof(T) == typeof(ulong))
                return vcpu.vtestz(v64u(src), v64u(mask));
            else
                return vtestz_i(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestz_i<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return vcpu.vtestz(v8i(src), v8i(mask));
            else if(typeof(T) == typeof(short))
                return vcpu.vtestz(v16i(src), v16i(mask));
            else if(typeof(T) == typeof(int))
                return vcpu.vtestz(v32i(src), v32i(mask));
            else if(typeof(T) == typeof(long))
                return vcpu.vtestz(v64i(src), v64i(mask));
            else
                return vtestz_f<T>(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestz_f<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return vcpu.vtestz(v32f(src), v32f(mask));
            else if(typeof(T) == typeof(double))
                return vcpu.vtestz(v64f(src), v64f(mask));
            else
                throw no<T>();
        }
    }
}
