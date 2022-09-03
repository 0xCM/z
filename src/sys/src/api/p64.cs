//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a generic reference as an int64 pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe long* p64i<T>(in T src)
            where T : unmanaged
                => gptr<T,long>(src);

        /// <summary>
        /// Presents a generic reference as an int64 pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ulong* p64u<T>(in T src)
            where T : unmanaged
                => gptr<T,ulong>(src);
    }
}