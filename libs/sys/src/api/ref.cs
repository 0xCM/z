//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
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
        /// Presents an S-pointer as a T-reference
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline)]
        public static unsafe ref T @ref<S,T>(S* pSrc)
            where S : unmanaged
                => ref @as<S,T>(@ref<S>(pSrc));
    }
}
