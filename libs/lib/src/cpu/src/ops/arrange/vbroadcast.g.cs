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
        /// Broadcasts an S-cell over a T-cell
        /// </summary>
        /// <param name="src">The source cell value</param>
        /// <param name="dst">The target cell</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline)]
        public static T broadcast<S,T>(S src)
            where S : unmanaged
            where T : unmanaged
                => vfirst<S,T>(vbroadcast(w128, src));

        /// <summary>
        /// Projects a scalar value onto each component of a 128-bit vector
        /// gcpu::vbroadcast[T]:w128->T->v256x8u
        /// </summary>
        /// <param name="w">The bitness selector</param>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vbroadcast<T>(W128 w, T src)
            where T : unmanaged
                => vbroadcast_u(w, src);

        /// <summary>
        /// Projects a scalar value onto each component of a 256-bit vector
        /// </summary>
        /// <param name="w">The bitness selector</param>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector256<T> vbroadcast<T>(W256 w, T src)
            where T : unmanaged
                => vbroadcast_u(w, src);

        /// <summary>
        /// Projects a scalar value onto each component of a 512-bit vector
        /// </summary>
        /// <param name="w">The bitness selector</param>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector512<T> vbroadcast<T>(W512 w, T src)
            where T : unmanaged
                => (vbroadcast(w256,src), vbroadcast(w256,src));

        [MethodImpl(Inline)]
        static Vector128<T> vbroadcast_u<T>(W128 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vbroadcast(w, uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vbroadcast(w, uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vbroadcast(w, uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vbroadcast(w, uint64(src)));
            else
                return vbroadcast_i(w,src);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vbroadcast_i<T>(W128 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vbroadcast(w, int8(src)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vbroadcast(w, int16(src)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vbroadcast(w, int32(src)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vbroadcast(w, int64(src)));
            else
                return vbroadcast_f(w,src);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vbroadcast_f<T>(W128 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vbroadcast(w, float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vbroadcast(w, float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vbroadcast_u<T>(W256 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vbroadcast(w, uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vbroadcast(w, uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vbroadcast(w, uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vbroadcast(w, uint64(src)));
            else
                return vbroadcast_i(w,src);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vbroadcast_i<T>(W256 w, T src)
            where T : unmanaged
        {
             if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vbroadcast(w, int8(src)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vbroadcast(w, int16(src)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vbroadcast(w, int32(src)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vbroadcast(w, int64(src)));
            else
                return vbroadcast_f(w,src);
       }

        [MethodImpl(Inline)]
        static Vector256<T> vbroadcast_f<T>(W256 w, T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vbroadcast(w, float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vbroadcast(w, float64(src)));
            else
                throw no<T>();
        }
    }
}