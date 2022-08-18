//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a generic reference as a short pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe short* p16i<T>(in T src)
            where T : unmanaged
                => gptr<T,short>(src);

        /// <summary>
        /// Presents a generic reference as a ushort pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ushort* p16u<T>(in T src)
            where T : unmanaged
                => gptr<T,ushort>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe char* p16c<T>(in T src)
            where T : unmanaged
                => gptr<T,char>(src);
    }
}