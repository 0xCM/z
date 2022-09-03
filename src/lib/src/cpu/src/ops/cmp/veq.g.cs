//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// Compares corresponding components in each vector for equality. For equal
        /// components, the corresponding component the result vector has all bits
        /// enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> veq<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => veq_u(x,y);

        /// <summary>
        /// Compares corresponding components in each vector for equality. For equal
        /// components, the corresponding component the result vector has all bits
        /// enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> veq<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => veq_u(x,y);

        /// <summary>
        /// Compares corresponding components in each vector for equality. For equal
        /// components, the corresponding component the result vector has all bits
        /// enabled; otherwise, all bits the component are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> veq<T>(in Vector512<T> x, in Vector512<T> y)
            where T : unmanaged
                => (veq(x.Lo, y.Lo), veq(x.Hi, y.Hi));

        [MethodImpl(Inline)]
        static Vector128<T> veq_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.veq(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.veq(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.veq(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.veq(v64u(x), v64u(y)));
            else
                return veq_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> veq_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.veq(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.veq(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.veq(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.veq(v64i(x), v64i(y)));
            else
                return veq_f(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> veq_f<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.veq(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.veq(v64f(x), v64f(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> veq_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.veq(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.veq(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.veq(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.veq(v64u(x), v64u(y)));
            else
                return veq_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> veq_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.veq(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.veq(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.veq(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.veq(v64i(x), v64i(y)));
            else
                return veq_f(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> veq_f<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.veq(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.veq(v64f(x), v64f(y)));
            else
                throw no<T>();
        }
    }
}