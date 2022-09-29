//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CpuBytes;

    partial struct gcpu
    {
        /// <summary>
        /// Creates a 128-bit vector with component values 0, 1, ... k - 1 where k is the length of the target vector
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public  static Vector128<T> vinc<T>(W128 w)
            where T : unmanaged
       {
            if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vload(w, first(Inc128x8u)));
            else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
                return generic<T>(cpu.vload(w, first(Inc128x16u)));
            else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int) || typeof(T) == typeof(float))
                return generic<T>(cpu.vload(w, first(Inc128x32u)));
            else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
                return generic<T>(cpu.vload(w, first(Inc128x64u)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Creates a 256-bit vector with component values 0, 1, ... k - 1 where k is the length of the target vector
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public  static Vector256<T> vinc<T>(W256 w)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vload(w, first(Inc256x8u)));
            else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
                return generic<T>(cpu.vload(w, first(Inc256x16u)));
            else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int)  || typeof(T) == typeof(float))
                return generic<T>(cpu.vload(w, first(Inc256x32u)));
            else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
                return generic<T>(cpu.vload(w, first(Inc256x64u)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Creates a 512-bit vector with component values 0, 1, ... k - 1 where k is the length of the target vector
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector512<T> vinc<T>(W512 w)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
                return gcpu.vload<T>(w, Inc512x8u);
            else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
                return gcpu.vload<T>(w, Inc512x16u);
            else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int) || typeof(T) == typeof(float))
                return gcpu.vload<T>(w, Inc512x32u);
            else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
                return gcpu.vload<T>(w,Inc512x64u);
            else
                throw no<T>();
        }
        /// <summary>
        /// Increments each component by unit value
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Inc, Closures(Integers)]
        public static Vector128<T> vinc<T>(Vector128<T> src)
            where T : unmanaged
                => vinc_u(src);

        /// <summary>
        /// Increments each component by unit value
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Inc, Closures(Integers)]
        public static Vector256<T> vinc<T>(Vector256<T> src)
            where T : unmanaged
                => vinc_u(src);

        /// <summary>
        /// Creates a 128-bit vector with components that increase by unit step from an initial value
        /// </summary>
        /// <param name="x0">The value of the first component</param>
        /// <param name="step">The distance between adjacent components</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Inc, Closures(Integers)]
        public static Vector128<T> vinc<T>(W128 w, T x0)
            where T : unmanaged
                => gcpu.vadd(gcpu.vinc<T>(w), x0);

        /// <summary>
        /// Creates a 256-bit vector with components that increase by unit step from an initial value
        /// </summary>
        /// <param name="x0">The value of the first component</param>
        /// <param name="step">The distance between adjacent components</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Inc, Closures(Integers)]
        public static Vector256<T> vinc<T>(W256 w, T x0)
            where T : unmanaged
                => gcpu.vadd(gcpu.vinc<T>(w), x0);

        /// <summary>
        /// Creates a 256-bit vector with components that increase by unit step from an initial value
        /// </summary>
        /// <param name="x0">The value of the first component</param>
        /// <param name="step">The distance between adjacent components</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector512<T> vinc<T>(W512 w, T x0)
            where T : unmanaged
                => gcpu.vadd(gcpu.vinc<T>(w), x0);

        [MethodImpl(Inline)]
        static Vector128<T> vinc_u<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vinc(v8u(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vinc(v16u(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vinc(v32u(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vinc(v64u(src)));
            else
                return vinc_i(src);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vinc_i<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vinc(v8i(src)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vinc(v16i(src)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vinc(v32i(src)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(cpu.vinc(v64i(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vinc_u<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vinc(v8u(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vinc(v16u(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vinc(v32u(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vinc(v64u(src)));
            else
                return vinc_i(src);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vinc_i<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vinc(v8i(src)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vinc(v16i(src)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vinc(v32i(src)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(cpu.vinc(v64i(src)));
            else
                throw no<T>();
        }
    }
}