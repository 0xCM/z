//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct memory
    {
        /// <summary>
        /// Presents a uint64 as an address
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(ulong src)
            => new MemoryAddress(src);

        /// <summary>
        /// Presents a <see cref='Ptr'/> as a <see cref='MemoryAddress'/>
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(IntPtr src)
            => new MemoryAddress((ulong)src.ToInt64());

        [MethodImpl(Inline), Op]
        public unsafe static MemoryAddress address(void* pSrc)
            => address((ulong)pSrc);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<P>(P* pSrc)
            where P : unmanaged
                => new MemoryAddress(pSrc);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<T>(Span<T> src)
            => new MemoryAddress(Pointers.pvoid(sys.first(src)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<T>(ReadOnlySpan<T> src)
            => new MemoryAddress(Pointers.pvoid(sys.first(src)));

        /// <summary>
        /// Derives the address of a <see cref='Type'/> from the value of its <see cref='Type.TypeHandle' />
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemoryAddress address(Type src)
            => sys.handle(src).ToPointer();

        /// <summary>
        /// Returns the address of the first character in the source string
        /// </summary>
        /// <param name="src">The source string</param>
        [MethodImpl(Inline), Op]
        public static unsafe MemoryAddress address(string src)
            => address(Pointers.pchar(src));

        /// <summary>
        /// Determines the address of a reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<T>(in T src)
            => new MemoryAddress(Pointers.pvoid(src));

        /// <summary>
        /// Determines the address of the leading source cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op]
        public static unsafe MemoryAddress address<T>(T[] src)
            => Pointers.pvoid(sys.first(src));

        /// <summary>
        /// Determines the address of a cell in an array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="index">The cell index</param>
        /// <typeparam name="T">The stored type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe MemoryAddress address<T>(T[] src, int index)
            => Pointers.pvoid(sys.seek(src,index));
    }
}