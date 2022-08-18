//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe T* gptr<T>(in T src)
            where T : unmanaged
                => (T*)AsPointer(ref edit(src));

        /// <summary>
        /// Presents a readonly reference to an unmanaged value as a pointer displaced
        /// by a specified element offset
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <param name="offset">The number of elements to skip</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe T* gptr<T>(in T src, int offset)
            where T : unmanaged
                => refptr(ref edit(in skip(in src, (uint)offset)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static T* gptr<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => (T*)AsPointer(ref edit(first(src)));

        /// <summary>
        /// Presents a generic reference r:T as a generic pointer p:T
        /// </summary>
        /// <param name="r">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        /// <typeparam name="P">The target pointer type</typeparam>
        [MethodImpl(Inline)]
        public static unsafe T* gptr<S,T>(in S src)
            where S : unmanaged
            where T : unmanaged
                => (T*)AsPointer(ref edit(src));
    }
}