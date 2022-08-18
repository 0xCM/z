//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, byte count)
            => ref seek(src, count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, ushort count)
            => ref seek(src, count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, uint count)
            => ref seek(src, count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, long count)
            => ref seek(src, count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, ulong count)
            => ref seek(src, count);
    }
}