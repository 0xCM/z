//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct MemoryFiles
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static MemoryFile map(FS.FilePath path)
            => new MemoryFile(path, false);

        [MethodImpl(Inline), Op]
        public static MemoryFile map(FS.FilePath path, bool stream)
            => new MemoryFile(path, stream);

        public static MemoryFile map(MemoryFileSpec spec)
            => new MemoryFile(spec);

        /// <summary>
        /// Creates a <see cref='MappedFiles'/> that covers the first level of a specified directory
        /// </summary>
        /// <param name="src">The source directory</param>
        [Op]
        public static MappedFiles map(FS.FolderPath src)
        {
            var files = src.EnumerateFiles(false).Array();
            if(files.Length != 0)
                return new MappedFiles(files.Select(map));
            else
                return MappedFiles.Empty;
        }

        [MethodImpl(Inline), Op]
        public static Span<byte> edit(in MemoryFile src)
            => cover<byte>(src.BaseAddress, src.FileSize);

        [MethodImpl(Inline), Op]
        public static Span<byte> slice(MemoryAddress @base, ulong offset, ByteSize size)
            => cover<byte>(@base + offset, size);

        /// <summary>
        /// Computes the address offset at a specified T-measured cell count
        /// </summary>
        /// <param name="base"></param>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        public static MemoryAddress address<T>(MemoryAddress @base, uint count)
            => @base + size<T>()*count;

        /// <summary>
        /// Presents file content as a <typeparamref name='T'/>  sequence
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> edit<T>(in MemoryFile src)
            => cover<T>(src.BaseAddress, src.FileSize/size<T>());

        /// <summary>
        /// Presents file content as a <typeparamref name='T'/>  sequence beginning at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(in MemoryFile src, uint index)
            => sys.cover<T>(src.BaseAddress, src.FileSize/size<T>());

        /// <summary>
        /// Presents file content as a <typeparamref name='T'/> sequence of length <paramref name='count'/> beginning at a <typeparamref name='T'/> measured offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The file-relative T-measured index</param>
        /// <param name="count">The number of cells in the returnd squence</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(in MemoryFile src, uint index, uint count)
            => sys.slice(edit<T>(src), index, count);

        /// <summary>
        /// Reveeals the <typeparamref name='T'/> cells at a specified index
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(in MemoryFile src, uint index)
            => ref sys.first(slice<T>(src, index));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(MemoryAddress @base, ulong offset, ByteSize size)
            => sys.cover<byte>(@base + offset, size);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in MemoryFile src)
            => cover<byte>(src.BaseAddress, src.FileSize);

        /// <summary>
        /// Presents file content as a readonly sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> view<T>(in MemoryFile src)
            => cover<T>(src.BaseAddress, src.FileSize/size<T>());

        /// <summary>
        /// Presents file content as a readonly <typeparamref name='T'/> sequence beginning at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> view<T>(in MemoryFile src, uint index)
            => sys.slice(view<T>(src), index);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> view<T>(in MemoryFile src, uint index, uint count)
            => sys.slice(view<T>(src), index, count);

        [Op]
        public static MemoryFileInfo describe(MemoryFile src)
        {
            var dst = new MemoryFileInfo();
            var fi = src.Path.Info;
            dst.BaseAddress = src.BaseAddress;
            dst.Size = src.FileSize;
            dst.EndAddress = dst.BaseAddress + dst.Size;
            dst.Path = src.Path;
            dst.CreateTS = fi.CreationTime;
            dst.UpdateTS = fi.LastWriteTime;
            dst.Attributes = fi.Attributes;
            return dst;
        }
    }
}