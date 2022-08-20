//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Allocates a specified number <typeparamref name='T'/> measured cells
        /// </summary>
        /// <param name="count">The number of cells to allocate</param>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] alloc<T>(byte count)
            => new T[count];

        /// <summary>
        /// Allocates a specified number <typeparamref name='T'/> measured cells
        /// </summary>
        /// <param name="count">The number of cells to allocate</param>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] alloc<T>(ushort count)
            => new T[count];

        /// <summary>
        /// Allocates a specified number <typeparamref name='T'/> measured cells
        /// </summary>
        /// <param name="count">The number of cells to allocate</param>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] alloc<T>(uint count)
            => new T[count];

        /// <summary>
        /// Allocates a specified number <typeparamref name='T'/> measured cells
        /// </summary>
        /// <param name="count">The number of cells to allocate</param>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] alloc<T>(long count)
            => new T[count];

        /// <summary>
        /// Allocates a specified number <typeparamref name='T'/> measured cells
        /// </summary>
        /// <param name="count">The number of cells to allocate</param>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] alloc<T>(ulong count)
            => new T[count];

        /// <summary>
        /// Allocates a new array and populates it with a specified value
        /// </summary>
        /// <param name="length">The array length</param>
        /// <param name="src">The value with which to populate the array</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] alloc<T>(int length, T src)
        {
            var dst = new T[length];
            Array.Fill(dst, src);
            return dst;
        }
    }
}