//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading;

    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        /// <summary>
        /// Atomically add a source value to a target
        /// </summary>
        /// <param name="src">The value to increment in-place</param>
        [MethodImpl(Inline), Op]
        public static long add(ref long dst, long src)
            => Interlocked.Add(ref dst, src);

        /// <summary>
        /// Atomically add a source value to a target
        /// </summary>
        /// <param name="src">The value to increment in-place</param>
        [MethodImpl(Inline), Op]
        public static long add(ref int dst, int src)
            => Interlocked.Add(ref dst, src);

        /// <summary>
        /// Adds an offset to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to add</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T add<T>(in T src, sbyte count)
            => ref Add(ref edit(src), count);

        /// <summary>
        /// Adds a specified count of <typeparamref name='T'/> measured offsets to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T add<T>(in T src, byte count)
            => ref Add(ref edit(src), count);

        /// <summary>
        /// Adds a specified count of <typeparamref name='T'/> measured offsets to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T add<T>(in T src, short count)
            => ref Add(ref edit(src), count);

        /// <summary>
        /// Adds a specified count of <typeparamref name='T'/> measured offsets to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T add<T>(in T src, ushort count)
            => ref Add(ref edit(src), (int)count);

        /// <summary>
        /// Adds a specified count of <typeparamref name='T'/> measured offsets to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        /// u8:  movsxd rax,edx -> add rax,rcx
        /// u16: movsxd rax,edx -> lea rax,[rcx+rax*2]
        /// u32: movsxd rax,edx -> lea rax,[rcx+rax*4]
        /// u64: movsxd rax,edx -> lea rax,[rcx+rax*8]
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T add<T>(in T src, int count)
            => ref Add(ref edit(src), count);

        /// <summary>
        /// Adds a specified count of <typeparamref name='T'/> measured offsets to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        /// <remarks>
        /// u8:  movsxd rax,edx -> add rax,rcx
        /// u16: movsxd rax,edx -> lea rax,[rcx+rax*2]
        /// u32: movsxd rax,edx -> lea rax,[rcx+rax*4]
        /// u64: movsxd rax,edx -> lea rax,[rcx+rax*8]
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T add<T>(in T src, uint count)
            => ref Add(ref edit(src), (int)count);

        /// <summary>
        /// Adds an offset to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to add</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T add<T>(in T src, long count)
            => ref Add(ref edit(src), (int)count);

        /// <summary>
        /// Adds a specified count of <typeparamref name='T'/> measured offsets to a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T add<T>(in T src, ulong count)
            => ref Add(ref edit(src), (int)count);
    }
}