//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.Unsafe;
    using static Root;

    partial struct core
    {
        /// <summary>
        /// Presents generic reference as a generic pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The reference type</typeparam>
        /// <remarks>For all T, effects: mov rax,rcx</remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe T* refptr<T>(ref T src)
            where T : unmanaged
                => (T*)AsPointer(ref src);

        /// <summary>
        /// Presents generic reference as a generic pointer displaced by an element offset
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <param name="offset">The number of elements to skip</param>
        /// <typeparam name="T">The reference type</typeparam>
        /// <remarks>
        /// Effects
        /// width[T]=8:  movsxd rax,edx => add rax,rcx
        /// width[T]=16: movsxd rax,edx => lea rax,[rcx+rax*2]
        /// width[T]=32: movsxd rax,edx => lea rax,[rcx+rax*4]
        /// width[T]=64: movsxd rax,edx => lea rax,[rcx+rax*8]
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe T* refptr<T>(ref T src, int offset)
            where T : unmanaged
                => (T*)AsPointer(ref Add(ref src, offset));

        /// <summary>
        /// Presents a generic reference r:T as a generic pointer p:T
        /// </summary>
        /// <param name="r">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        /// <typeparam name="P">The target pointer type</typeparam>
        [MethodImpl(Inline)]
        public static unsafe P* refptr<T,P>(ref T r)
            where T : unmanaged
            where P : unmanaged
                => (P*)AsPointer(ref r);
    }
}