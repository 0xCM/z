//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct SpanBlocks
    {
        /// <summary>
        /// Returns a generic pointer to the leading cell of the first block of a 128-bit blocked container
        /// </summary>
        /// <param name="src">The source block</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline),Op, Closures(Closure)]
        public static unsafe T* ptr<T>(in SpanBlock128<T> src)
            where T : unmanaged
                => gptr(src.First);

        /// <summary>
        /// Returns a generic pointer to the leading cell of the first block of a 256-bit blocked container
        /// </summary>
        /// <param name="src">The source block</param>
        /// <typeparam name="T">The reference type</typeparam>
        [MethodImpl(Inline),Op, Closures(Closure)]
        public static unsafe T* ptr<T>(in SpanBlock256<T> src)
            where T : unmanaged
                => gptr(src.First);
    }
}