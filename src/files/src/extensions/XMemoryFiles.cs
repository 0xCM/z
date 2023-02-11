//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = MemoryFiles;

    partial class XTend
    {
        /// <summary>
        /// Presents file content as a sequence of <see cref='byte'/> cells
        /// </summary>
        [MethodImpl(Inline)]
        public static Span<byte> Edit(this MemoryFile src)
            => api.edit(src);

        /// <summary>
        /// Presents a single cell from the underlying source located at a <typeparamref name='T'/> measured offset
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public unsafe static ref T Seek<T>(this MemoryFile src, uint index)
            where T : unmanaged
                => ref sys.seek<T>((T*)src.Base, index);

        /// <summary>
        /// Presents file content segment as a readonly sequence of <typeparamref name='T'/> cells beginning
        /// at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> Slice<T>(this MemoryFile src, uint index)
            => api.slice<T>(src, index);

        /// <summary>
        /// Presents file content as a <typeparamref name='T'/> sequence of length <paramref name='count'/> beginning at a <typeparamref name='T'/> measured offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The file-relative T-measured index</param>
        /// <param name="count">The number of cells in the returned squence</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> Slice<T>(this MemoryFile src, uint index, uint count)
            => api.slice<T>(src, index, count);

        public static MemoryFile MemoryMap(this FilePath src, bool stream = false)
            => MemoryFiles.map(src, stream);
    }
}