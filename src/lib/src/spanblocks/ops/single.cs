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
        /// Creates a single block from stack-allocated storage
        /// </summary>
        /// <param name="w">The block width</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock8<T> single<T>(W8 w)
            where T : unmanaged
        {
            ref var storage = ref first(recover<T>(Cells.alloc(w).Bytes));
            return load(w, ref storage, 1);
        }

        /// <summary>
        /// Creates a single block from stack-allocated storage
        /// </summary>
        /// <param name="w">The block width</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock16<T> single<T>(W16 w)
            where T : unmanaged
        {
            ref var storage = ref first(recover<T>(Cells.alloc(w).Bytes));
            return load(w, ref storage, 1);
        }

        /// <summary>
        /// Creates a single block from stack-allocated storage
        /// </summary>
        /// <param name="w">The block width</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock32<T> single<T>(W32 w)
            where T : unmanaged
        {
            ref var storage = ref first(recover<T>(Cells.alloc(w).Bytes));
            return load(w, ref storage, 1);
        }

        /// <summary>
        /// Creates a single block from stack-allocated storage
        /// </summary>
        /// <param name="w">The block width</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock64<T> single<T>(W64 w)
            where T : unmanaged
        {
            ref var storage = ref first(recover<T>(Cells.alloc(w).Bytes));
            return load(w, ref storage, 1);
        }

        /// <summary>
        /// Creates a single block from stack-allocated storage
        /// </summary>
        /// <param name="w">The block width</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock128<T> single<T>(W128 w)
            where T : unmanaged
        {
            ref var storage = ref first(recover<T>(Cells.alloc(w).Bytes));
            return load(w, ref storage, 1);
        }

        /// <summary>
        /// Creates a single block from stack-allocated storage
        /// </summary>
        /// <param name="w">The block width</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock256<T> single<T>(W256 w)
            where T : unmanaged
        {
            ref var storage = ref first(recover<T>(Cells.alloc(w).Bytes));
            return load(w, ref storage, 1);
        }

        /// <summary>
        /// Creates a single block from stack-allocated storage
        /// </summary>
        /// <param name="w">The block width</param>
        /// <typeparam name="T">The block cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock512<T> single<T>(W512 w)
            where T : unmanaged
        {
            ref var storage = ref first(recover<T>(Cells.alloc(w).Bytes));
            return load(w, ref storage, 1);
        }
    }
}