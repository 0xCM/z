//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.MemoryMappedFiles;

    using A = System.IO.MemoryMappedFiles.MemoryMappedFileAccess;
    using M = System.IO.FileMode;

    /// <summary>
    /// Spcifies apspects that are appliable when creating/opening a <see cref='MemoryFile'/>
    /// </summary>
    [StructLayout(StructLayout)]
    public record struct MemoryFileSpec
    {
        [MethodImpl(Inline)]
        public static MemoryFileSpec init(FilePath src)
        {
            var dst = new MemoryFileSpec();
            dst.Path = src;
            return dst;
        }

        public MemoryFileSpec()
        {


        }

        /// <summary>
        /// The file location
        /// </summary>
        public FilePath Path = FilePath.Empty;

        /// <summary>
        /// If specified, the name to expose for cross-process access; if unspecified access is only available within the creating process
        /// </summary>
        public string? MapName = null;

        /// <summary>
        /// Specifies whether streaming is enabled
        /// </summary>
        public bool Stream = false;

        /// <summary>
        /// The maximum size, in bytes, to allocate to the memory-mapped file. Specify 0 to set the capacity to the size of the file on disk.
        /// </summary>
        public long Capacity = 0;

        /// <summary>
        /// CreateNew ^ Create ^ Open ^ OpenOrCreate ^ Truncate
        /// </summary>
        public FileMode Mode = FileMode.Open;

        /// <summary>
        /// ReadWrite ^ Read ^ Write ^ CopyOnWrite ^ ReadExecute ^ ReadWriteExecute
        /// </summary>
        public MemoryMappedFileAccess Access = MemoryMappedFileAccess.Read;

        /// <summary>
        /// Specifies whether memory allocation is delayed until a view is created with either the
        /// MemoryMappedFile.CreateViewAccessor or MemoryMappedFile.CreateViewStream method.
        /// </summary>
        public bool LazyAllocation = false;

        /// <summary>
        /// Specifies whether the underlying handle is inheritable by child processes
        /// </summary>
        public bool Inheritable = false;

        /// <summary>
        /// Specifies whether only unmanaged resources are released when the file is disposed
        /// </summary>
        public bool UnmangagedDisposal = false;

        [MethodImpl(Inline)]
        public MemoryFileSpec WithCapacity(long size)
        {
            Capacity = size;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Mode'/> value to <see cref='M.CreateNew'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithCreateNewMode()
        {
            Mode = M.CreateNew;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Mode'/> value to <see cref='M.Create'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithCreateMode()
        {
            Mode = M.Create;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Mode'/> value to <see cref='M.OpenOrCreate'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithOpenOrCreateMode()
        {
            Mode = M.OpenOrCreate;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Mode'/> value to <see cref='M.Truncate'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithTruncateMode()
        {
            Mode = M.Truncate;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Access'/> value to <see cref='A.ReadWrite'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithReadWriteAccess()
        {
            Access = A.ReadWrite;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Access'/> value to <see cref='A.Read'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithReadAccess()
        {
            Access = A.Read;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Access'/> value to <see cref='A.Write'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithWriteAccess()
        {
            Access = A.Write;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Access'/> value to <see cref='A.CopyOnWrite'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithCopyOnWriteAccess()
        {
            Access = A.CopyOnWrite;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Access'/> value to <see cref='A.ReadExecute'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithReadExecuteAccess()
        {
            Access = A.ReadExecute;
            return this;
        }

        /// <summary>
        /// Sets the <see cref='Access'/> value to <see cref='A.ReadWriteExecute'/>
        /// </summary>
        [MethodImpl(Inline)]
        public MemoryFileSpec WithGodPower()
        {
            Access = A.ReadWriteExecute;
            return this;
        }
    }
}