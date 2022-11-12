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
        /// Loads a 128-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector128<T> vload<T>(W128 w, in T src)
            where T : unmanaged
                => vload(gptr(src), out Vector128<T> _);

        /// <summary>
        /// Loads a 256-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector256<T> vload<T>(W256 w, in T src)
            where T : unmanaged
                => vload(gptr(src), out Vector256<T> _);

        /// <summary>
        /// Loads a 512-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector512<T> vload<T>(W512 w, in T src)
            where T : unmanaged
                => vload(gptr(src), out Vector512<T> _);

        /// <summary>
        /// Loads a 128-bit vector from a readonly memory reference offset by a cell-relative offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <param name="offset">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector128<T> vload<T>(W128 w, in T src, int offset)
            where T : unmanaged
                => vload(gptr(src, offset), out Vector128<T> _);

        /// <summary>
        /// Loads a 256-bit vector from a readonly memory reference offset by a cell-relative offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <param name="offset">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector256<T> vload<T>(W256 w, in T src, int offset)
            where T : unmanaged
                => vload(gptr(src, offset), out Vector256<T> _);

        /// <summary>
        /// Loads a 256-bit vector from a readonly memory reference offset by a cell-relative offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <param name="offset">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector512<T> vload<T>(W512 w, in T src, int offset)
            where T : unmanaged
                => vload(gptr(src, offset), out Vector512<T> _);

        /// <summary>
        /// Loads a 128-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector128<T> vload<T>(in T src, out Vector128<T> dst)
            where T : unmanaged
                => vload(gptr(src), out dst);

        /// <summary>
        /// Loads a 256-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector256<T> vload<T>(in T src, out Vector256<T> dst)
            where T : unmanaged
                => vload(gptr(src), out dst);

        /// <summary>
        /// Loads a 512-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector512<T> vload<T>(in T src, out Vector512<T> dst)
            where T : unmanaged
                => vload(gptr(src), out dst);
    }
}