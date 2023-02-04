//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Reads a generic value beginning at a specified offset
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The index at which span consumption should begin</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Int8x64k)]
        public static ref readonly T cell<T>(ReadOnlySpan<byte> src, int offset)
            where T : unmanaged
                => ref first<T>(slice(src,offset));

        [MethodImpl(Inline), Op]
        public static ref ushort cell16(Span<byte> src, uint offset)
            => ref first<ushort>(slice(src, offset));

        [MethodImpl(Inline), Op]
        public static ref uint cell32(Span<byte> src, uint offset)
            => ref first<uint>(slice(src, offset));

        [MethodImpl(Inline), Op]
        public static ref ulong cell64(Span<byte> src, uint offset)
            => ref first<ulong>(slice(src, offset));

        /// <summary>
        /// Computes the whole number of <typeparamref name='T'/> cells covered by a specified <see cref='MemoryRange'/>
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint cells<T>(MemoryRange src)
            => (uint)(src.ByteCount/size<T>());

        /// <summary>
        /// Computes the number of <typeparamref name='T'/> cells that comprise a single 8-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8k)]
        public static uint cells<T>(W8 w)
            where T : unmanaged
                => size<T>();

        /// <summary>
        /// Computes the number of <typeparamref name='T'/> cells that comprise a single 16-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8x16k)]
        public static uint cells<T>(W16 w)
            where T : unmanaged
                => 2/size<T>();

        /// <summary>
        /// Computes the number of <typeparamref name='T'/> cells that comprise a single 32-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8x16x32k)]
        public static uint cells<T>(W32 w)
            where T : unmanaged
                => 4/size<T>();

        /// <summary>
        /// Computes the number of <typeparamref name='T'/> cells that comprise a single 64-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint cells<T>(W64 w)
            where T : unmanaged
                => 8/size<T>();

        /// <summary>
        /// Computes the number of <typeparamref name='T'/> cells that comprise a single 128-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint cells<T>(W128 w)
            where T : unmanaged
                => 16/size<T>();

        /// <summary>
        /// Computes the number of <typeparamref name='T'/> cells that comprise a 256-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint cells<T>(W256 w)
            where T : unmanaged
                => 32/size<T>();

        /// <summary>
        /// Computes the number of <typeparamref name='T'/> cells that comprise a 512-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint cells<T>(W512 w)
            where T : unmanaged
                => 64/size<T>();
    }
}