//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class Algs
    {
        /// <summary>
        /// Subtracts a specified count of <typeparamref name='T'/> measured offsets from a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), MemSub, Closures(Closure)]
        public static ref T sub<T>(in T src, byte count)
            => ref Subtract(ref edit(src), count);

        /// <summary>
        /// Subtracts a specified count of <typeparamref name='T'/> measured offsets from a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), MemSub, Closures(Closure)]
        public static ref T sub<T>(in T src, ushort count)
            => ref Subtract(ref edit(src), count);

        /// <summary>
        /// Subtracts a specified count of <typeparamref name='T'/> measured offsets from a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), MemSub, Closures(Closure)]
        public static ref T sub<T>(in T src, uint count)
            => ref Subtract(ref edit(src), (int)count);

        /// <summary>
        /// Subtracts a specified count of <typeparamref name='T'/> measured offsets from a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The T-cell count to subtract</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline), MemSub, Closures(Closure)]
        public static ref T sub<T>(in T src, ulong count)
            => ref Subtract(ref edit(src), (int)count);
    }
}