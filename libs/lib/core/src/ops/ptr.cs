//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        /// <summary>
        /// Converts a generic reference into a void pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The type of the referenced data</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static unsafe void* pvoid<T>(in T src)
            => AsPointer(ref edit(src));

        /// <summary>
        /// Presents a generic reference as an sbyte pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe sbyte* p8i<T>(in T src)
            where T : unmanaged
                => refptr<T,sbyte>(ref edit(src));

        /// <summary>
        /// Presents a generic reference as a byte pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe byte* p8u<T>(in T src)
            where T : unmanaged
                => refptr<T,byte>(ref edit(src));

        /// <summary>
        /// Presents a generic reference as a short pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe short* p16i<T>(in T src)
            where T : unmanaged
                => refptr<T,short>(ref edit(src));

        /// <summary>
        /// Presents a generic reference as a ushort pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ushort* p16u<T>(in T src)
            where T : unmanaged
                => refptr<T,ushort>(ref edit(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe char* p16c<T>(in T src)
            where T : unmanaged
                => refptr<T,char>(ref edit(src));

        /// <summary>
        /// Presents a generic reference as an uint32 pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe uint* p32u<T>(in T src)
            where T : unmanaged
                => refptr<T,uint>(ref edit(src));

        /// <summary>
        /// Presents a generic reference as an int32 pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe int* p32i<T>(in T src)
            where T : unmanaged
                => refptr<T,int>(ref edit(src));

        /// <summary>
        /// Presents a generic reference as an int64 pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe long* p64i<T>(in T src)
            where T : unmanaged
                => refptr<T,long>(ref edit(src));

        /// <summary>
        /// Presents a generic reference as an int64 pointer
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The source reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ulong* p64u<T>(in T src)
            where T : unmanaged
                => refptr<T,ulong>(ref edit(src));
    }
}