//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial struct core
    {
        /// <summary>
        /// Presents a pointer as a reference
        /// </summary>
        /// <param name="ptr">The source pointer</param>
        /// <typeparam name="T">The reference type</typeparam>
        /// <remarks>For all T, effects: mov rax,rcx</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref T @ref<T>(T* ptr)
            where T : unmanaged
                => ref AsRef<T>(ptr);

        /// <summary>
        /// Presents a void pointer as a reference
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref T @ref<T>(void* pSrc)
            => ref AsRef<T>(pSrc);

        /// <summary>
        /// Returns a reference to an identified location
        /// </summary>
        /// <param name="src">The source address</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref T @ref<T>(MemoryAddress src)
            => ref AsRef<T>((void*)src.Location);
    }
}