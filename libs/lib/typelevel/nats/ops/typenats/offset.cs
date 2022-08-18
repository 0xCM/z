//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static System.Runtime.CompilerServices.Unsafe;
    using static core;

    partial class TypeNats
    {
        /// <summary>
        /// Adds a an offset of 1 byte to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T offset<T>(in T src, N1 n)
            => ref AddByteOffset(ref edit(src), (IntPtr)1);

        /// <summary>
        /// Adds a an offset of 2 bytes to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T offset<T>(in T src, N2 n)
            => ref AddByteOffset(ref edit(src), (IntPtr)2);

        /// <summary>
        /// Adds a an offset of 3 bytes to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T offset<T>(in T src, N3 n)
            => ref AddByteOffset(ref edit(src), (IntPtr)3);

        /// <summary>
        /// Adds a an offset of 4 bytes to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T offset<T>(in T src, N4 n)
            => ref AddByteOffset(ref edit(src), (IntPtr)4);

        /// <summary>
        /// Adds a an offset of 5 bytes to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T offset<T>(in T src, N5 n)
            => ref AddByteOffset(ref edit(src), (IntPtr)5);

        /// <summary>
        /// Adds a an offset of 6 bytes to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T offset<T>(in T src, N6 n)
            => ref AddByteOffset(ref edit(src), (IntPtr)6);

        /// <summary>
        /// Adds a an offset of 7 bytes to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T offset<T>(in T src, N7 n)
            => ref AddByteOffset(ref edit(src), (IntPtr)7);
    }
}