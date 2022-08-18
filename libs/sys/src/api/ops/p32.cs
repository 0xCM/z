//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a generic reference as an uint32 pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe uint* p32u<T>(in T src)
            where T : unmanaged
                => gptr<T,uint>(src);

        /// <summary>
        /// Presents a generic reference as an int32 pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe int* p32i<T>(in T src)
            where T : unmanaged
                => gptr<T,int>(src);
    }
}