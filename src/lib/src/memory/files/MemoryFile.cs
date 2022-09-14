//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.MemoryMappedFiles;

    using static sys;

    using api = MemoryFiles;

    public unsafe class MemoryFile : IMemoryFile<MemoryFile>
    {
        readonly MemoryFileSpec Spec;

        public readonly FilePath Path;

        readonly MemoryMappedFile File;

        byte* Base;

        public readonly ByteSize FileSize;

        readonly MemoryMappedViewAccessor ViewAccessor;

        readonly MemoryMappedViewStream ViewStream;

        public readonly MemoryAddress BaseAddress;

        public readonly MemoryFileInfo Description;

        public MemoryFile(MemoryFileSpec spec)
        {
            Spec = spec;
            Path = spec.Path;
            FileSize = (ulong)Path.Info.Length;
            File = MemoryMappedFile.CreateFromFile(spec.Path.Name, spec.Mode, spec.MapName, spec.Capacity, spec.Access);
            Description = api.describe(this);
            ViewAccessor = File.CreateViewAccessor(0, (long)FileSize);
            ViewAccessor.SafeMemoryMappedViewHandle.AcquirePointer(ref Base);
            BaseAddress = Base;
            if(spec.Stream)
                ViewStream = File.CreateViewStream();
            else
                ViewStream = null;
        }

        internal MemoryFile(FilePath path, bool stream = false)
        {
            Path = path;
            FileSize = (ulong)Path.Info.Length;
            File = MemoryMappedFile.CreateFromFile(path.Name);
            Base = File.SafeMemoryMappedFileHandle.ToPointer<byte>();
            Description = api.describe(this);
            ViewAccessor = File.CreateViewAccessor(0, Path.Info.Length);
            ViewAccessor.SafeMemoryMappedViewHandle.AcquirePointer(ref Base);
            BaseAddress = Base;
            if(stream)
                ViewStream = File.CreateViewStream();
            else
                ViewStream = null;
        }

        public void Dispose()
        {
            ViewAccessor?.Dispose();
            Stream?.Dispose();
            File?.Dispose();
        }

        public ref readonly MemoryAddress EndAddress
        {
            [MethodImpl(Inline)]
            get => ref Description.EndAddress;
        }

        public void Accessor(Action<MemoryMappedViewAccessor> f)
        {
            using var accessor = File.CreateViewAccessor();
            f(accessor);
        }

        public void Accessor(Action<MemoryMappedViewAccessor> f, uint offset)
        {
            var size = EndAddress - (BaseAddress + offset);
            using var accessor = File.CreateViewAccessor(offset,size);
            f(accessor);
        }

        public ref readonly MemoryMappedViewStream Stream
        {
            get
            {
                ViewStream.Seek(0, System.IO.SeekOrigin.Begin);
                return ref ViewStream;
            }
        }

        [MethodImpl(Inline)]
        public SegRef<T> Segment<T>(uint index, uint Size)
            => new SegRef<T>(api.address<T>(Base,index),Size);

        [MethodImpl(Inline)]
        public SegRef Segment(uint index, uint Size)
            => new SegRef(api.address<byte>(Base,index),Size);

        [MethodImpl(Inline)]
        public MemorySeg Segment()
            => new MemorySeg(Base,FileSize);

        [MethodImpl(Inline)]
        public Span<byte> Edit(ulong offset, ByteSize size)
            => edit(BaseAddress, offset, size);

        /// <summary>
        /// Presents file content as a sequence of <see cref='byte'/> cells
        /// </summary>
        [MethodImpl(Inline)]
        public Span<byte> Edit()
            => api.edit(this);

        /// <summary>
        /// Presents file content as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public Span<T> Edit<T>()
            => api.edit<T>(this);

        /// <summary>
        /// Presents a single cell from the underlying source located at a <typeparamref name='T'/> measured offset
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public ref T Seek<T>(uint index)
            where T : unmanaged
                => ref core.seek<T>((T*)Base, index);

        /// <summary>
        /// Presents file content segment as a readonly sequence of <typeparamref name='T'/> cells beginning
        /// at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public Span<T> Slice<T>(uint index)
            => api.slice<T>(this, index);

        /// <summary>
        /// Presents file content as a <typeparamref name='T'/> sequence of length <paramref name='count'/> beginning at a <typeparamref name='T'/> measured offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The file-relative T-measured index</param>
        /// <param name="count">The number of cells in the returned squence</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public Span<T> Slice<T>(uint index, uint count)
            => api.slice<T>(this, index, count);

        public ref byte this[uint offset]
        {
            [MethodImpl(Inline)]
            get => ref Seek<byte>(offset);
        }

        public ref byte this[int offset]
        {
            [MethodImpl(Inline)]
            get => ref Seek<byte>((uint)offset);
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> View(ulong offset, ByteSize size)
            => api.view(BaseAddress, offset, size);

        /// <summary>
        /// Presents file content as a readonly sequence of <see cref='byte'/> cells
        /// </summary>
        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> View()
            => api.view(this);

        /// <summary>
        /// Presents file content as a readonly sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public ReadOnlySpan<T> View<T>()
            => api.view<T>(this);

        /// <summary>
        /// Presents a single cell from the underlying source located at a <typeparamref name='T'/> measured offset
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public ref readonly T Skip<T>(uint index)
            => ref first(View<T>(index));

        [MethodImpl(Inline)]
        public ref readonly T First<T>()
            => ref first(View<T>(0));

        /// <summary>
        /// Presents file content segment as a readonly sequence of <typeparamref name='T'/> cells beginning
        /// at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public ReadOnlySpan<T> View<T>(uint index)
            => api.view<T>(this, index);

        /// <summary>
        /// Presents file content segment as a readonly sequence of <typeparamref name='T'/> cells beginning
        /// at a <typeparamref name='T'/> measured offset and continuing to the end of the file
        /// </summary>
        /// <param name="index">The number of cells to advance from the base address</param>
        /// <param name="count">The number of cells to present</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public ReadOnlySpan<T> View<T>(uint index, uint count)
            => api.view<T>(this,index, count);

        [MethodImpl(Inline)]
        public int CompareTo(MemoryFile src)
            => BaseAddress.CompareTo(src.BaseAddress);

        MemoryAddress IMemoryFile.BaseAddress
            => BaseAddress;

        ByteSize ISized.ByteCount
            => FileSize;

        BitWidth ISized.BitWidth
            => FileSize.Bits;
    }
}