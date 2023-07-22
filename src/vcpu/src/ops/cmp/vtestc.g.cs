//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;
    
    partial class vgcpu
    {
        /// <summary>
        /// Returns 1 if all mask-identified source bits are all enabled and 0 otherwise
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits in the source to test</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), TestC, Closures(AllNumeric)]
        public static bit vtestc<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
                => vtestc_u(src,mask);

        /// <summary>
        /// Returns 1 if all mask-identified source bits are all enabled and 0 otherwise
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), TestC, Closures(AllNumeric)]
        public static bit vtestc<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
                => vtestc_u(src,mask);

        /// <summary>
        /// Returns 1 if all mask-identified source bits are all enabled and 0 otherwise
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), TestC, Closures(AllNumeric)]
        public static bit vtestc<T>(in Vector512<T> src, in Vector512<T> mask)
            where T : unmanaged
                => vtestc(vlo(src), vlo(mask)) && vtestc(vhi(src), vhi(mask));

        /// <summary>
        /// Returns 1 if all source bits are enabled and 0 otherwise
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits in the source to test</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), TestC, Closures(AllNumeric)]
        public static bit vtestc<T>(Vector128<T> src)
            where T : unmanaged
                => vtestc(src, vones<T>(w128));

        /// <summary>
        /// Returns 1 if all source bits are enabled and 0 otherwise
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), TestC, Closures(AllNumeric)]
        public static bit vtestc<T>(Vector256<T> src)
            where T : unmanaged
                => vtestc(src, vones<T>(w256));

        // /// <summary>
        // /// Returns 1 if all source bits are enabled and 0 otherwise
        // /// </summary>
        // /// <param name="src">The source bits</param>
        // /// <typeparam name="T">The primal component type</typeparam>
        // [MethodImpl(Inline), TestC, Closures(AllNumeric)]
        // public static bit vtestc<T>(Vector512<T> src)
        //     where T : unmanaged
        //         => vtestc(src, vones<T>(w512));

        [MethodImpl(Inline)]
        static bit vtestc_u<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return vcpu.vtestc(v8u(src), v8u(mask));
            else if(typeof(T) == typeof(ushort))
                return vcpu.vtestc(v16u(src), v16u(mask));
            else if(typeof(T) == typeof(uint))
                return vcpu.vtestc(v32u(src), v32u(mask));
            else if(typeof(T) == typeof(ulong))
                return vcpu.vtestc(v64u(src), v64u(mask));
            else
                return vtestc_i(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestc_i<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return vcpu.vtestc(v8i(src), v8i(mask));
            else if(typeof(T) == typeof(short))
                return vcpu.vtestc(v16i(src), v16i(mask));
            else if(typeof(T) == typeof(int))
                return vcpu.vtestc(v32i(src), v32i(mask));
            else if(typeof(T) == typeof(long))
                return vcpu.vtestc(v64i(src), v64i(mask));
            else
                return vtestc_f(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestc_f<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return vcpu.vtestc(v32f(src), v32f(mask));
            else if(typeof(T) == typeof(double))
                return vcpu.vtestc(v64f(src), v64f(mask));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static bit vtestc_u<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return vcpu.vtestc(v8u(src), v8u(mask));
            else if(typeof(T) == typeof(ushort))
                return vcpu.vtestc(v16u(src), v16u(mask));
            else if(typeof(T) == typeof(uint))
                return vcpu.vtestc(v32u(src), v32u(mask));
            else if(typeof(T) == typeof(ulong))
                return vcpu.vtestc(v64u(src), v64u(mask));
            else
                return vtestc_i(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestc_i<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return vcpu.vtestc(v8i(src), v8i(mask));
            else if(typeof(T) == typeof(short))
                return vcpu.vtestc(v16i(src), v16i(mask));
            else if(typeof(T) == typeof(int))
                return vcpu.vtestc(v32i(src), v32i(mask));
            else if(typeof(T) == typeof(long))
                return vcpu.vtestc(v64i(src), v64i(mask));
            else
                return vtestc_f(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestc_f<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return vcpu.vtestc(v32f(src), v32f(mask));
            else if(typeof(T) == typeof(double))
                return vcpu.vtestc(v64f(src), v64f(mask));
            else
                throw no<T>();
        }
    }
}