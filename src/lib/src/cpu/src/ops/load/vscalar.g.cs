//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcpu
    {
        /// <summary>
        /// Loads a scalar into the first component of a 128-bit vector
        /// </summary>
        /// <param name="w">The width of the target vector</param>
        /// <param name="a">The scalar to load</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vscalar<T>(W128 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vscalar_u(w, src);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vscalar_i(w, src);
            else
                return vscalar_f(w, src);
        }

        /// <summary>
        /// Loads a scalar into the first component of a 256-bit vector
        /// </summary>
        /// <param name="a">The scalar to load</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector256<T> vscalar<T>(W256 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vscalar_u(w, src);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vscalar_i(w, src);
            else
                return vscalar_f(w, src);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vscalar_u<T>(W128 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vscalar(w, uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vscalar(w, uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vscalar(w, uint32(src)));
            else
                return generic<T>(cpu.vscalar(w, uint64(src)));
        }

        [MethodImpl(Inline)]
        static Vector128<T> vscalar_i<T>(W128 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vscalar(w, int8(src)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vscalar(w, int16(src)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vscalar(w, int32(src)));
            else
                return generic<T>(cpu.vscalar(w, int64(src)));
        }

        [MethodImpl(Inline)]
        static Vector128<T> vscalar_f<T>(W128 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vscalar(w, float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vscalar(w, float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vscalar_u<T>(W256 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vscalar(w, uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vscalar(w, uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vscalar(w, uint32(src)));
            else
                return generic<T>(cpu.vscalar(w, uint64(src)));
        }

        [MethodImpl(Inline)]
        static Vector256<T> vscalar_i<T>(W256 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vscalar(w, int8(src)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vscalar(w, int16(src)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vscalar(w, int32(src)));
            else
                return generic<T>(cpu.vscalar(w, int64(src)));
        }

        [MethodImpl(Inline)]
        static Vector256<T> vscalar_f<T>(W256 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vscalar(w, float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vscalar(w, float64(src)));
            else
                throw no<T>();
        }
    }
}