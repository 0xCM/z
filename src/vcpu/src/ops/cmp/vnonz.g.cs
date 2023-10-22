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
        /// Returns true if at least one of the components of the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Nonz, Closures(AllNumeric)]
        public static bool vnonz<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vnonz_u(src);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vnonz_i(src);
            else
                return vnonz_f(src);
        }

        /// <summary>
        /// Returns true if at least one of the components of the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Nonz, Closures(AllNumeric)]
        public static bool vnonz<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vnonz_u(src);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vnonz_i(src);
            else
                return vnonz_f(src);
        }

        /// <summary>
        /// Returns true if at least one of the components of the source vector is nonzero, false otherwise
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Nonz, Closures(AllNumeric)]
        public static bool vnonz<T>(in Vector512<T> src)
            where T : unmanaged
                => vnonz(vlo(src)) || vnonz(vhi(src));

        [MethodImpl(Inline)]
        static bool vnonz_i<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return vcpu.vnonz(v8i(src));
            else if(typeof(T) == typeof(short))
                return vcpu.vnonz(v16i(src));
            else if(typeof(T) == typeof(int))
                return vcpu.vnonz(v32i(src));
            else
                return vcpu.vnonz(v64i(src));
        }

        [MethodImpl(Inline)]
        static bool vnonz_u<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return vcpu.vnonz(v8u(src));
            else if(typeof(T) == typeof(ushort))
                return vcpu.vnonz(v16u(src));
            else if(typeof(T) == typeof(uint))
                return vcpu.vnonz(v32u(src));
            else
                return vcpu.vnonz(v64u(src));
        }

        [MethodImpl(Inline)]
        static bool vnonz_f<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fcpu.vnonz(v32f(src));
            else if(typeof(T) == typeof(double))
                return fcpu.vnonz(v64f(src));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static bool vnonz_i<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return vcpu.vnonz(v8i(src));
            else if(typeof(T) == typeof(short))
                return vcpu.vnonz(v16i(src));
            else if(typeof(T) == typeof(int))
                return vcpu.vnonz(v32i(src));
            else
                return vcpu.vnonz(v64i(src));
        }

        [MethodImpl(Inline)]
        static bool vnonz_u<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return vcpu.vnonz(v8u(src));
            else if(typeof(T) == typeof(ushort))
                return vcpu.vnonz(v16u(src));
            else if(typeof(T) == typeof(uint))
                return vcpu.vnonz(v32u(src));
            else
                return vcpu.vnonz(v64u(src));
        }

        [MethodImpl(Inline)]
        static bool vnonz_f<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fcpu.vnonz(v32f(src));
            else if(typeof(T) == typeof(double))
                return fcpu.vnonz(v64f(src));
            else
                throw no<T>();
        }
    }
}