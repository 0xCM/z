//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a generic reference as an sbyte pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe sbyte* p8i<T>(in T src)
            where T : unmanaged
                => gptr<T,sbyte>(src);

        /// <summary>
        /// Presents a generic reference as a byte pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe byte* p8u<T>(in T src)
            where T : unmanaged
                => gptr<T,byte>(src);
    }
}