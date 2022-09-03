//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Skips a specified number of pointer-identified elements and returns a reference to the result
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ref T seek<T>(T* pSrc, long count)
            where T : unmanaged
                => ref @ref(pSrc + size<T>()*count);

        /// <summary>
        /// Skips a specified number of pointer-identified elements and returns a reference to the result
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ref T seek<T>(T* pSrc, ulong count)
            where T : unmanaged
                => ref @ref(pSrc + size<T>()*count);
    }
}