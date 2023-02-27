//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = MemoryFiles;

    public class MappedFiles : IMappedFiles
    {
        readonly Index<MemoryFile> MemoryFiles;

        readonly Index<MemoryAddress> Addresses;

        readonly Index<MemoryFileInfo> FileInfo;

        internal MappedFiles(Index<MemoryFile> src)
        {
            if(src.Count != 0)
            {
                MemoryFiles = src.Sort();
                var count = MemoryFiles.Count;
                Addresses = sys.alloc<MemoryAddress>(count);
                for(var i=0; i<count; i++)
                    Addresses[i] = MemoryFiles[i].BaseAddress;
                FileInfo = MemoryFiles.Select(api.describe);
            }
            else
            {
                MemoryFiles = Index<MemoryFile>.Empty;
                Addresses = Index<MemoryAddress>.Empty;
                FileInfo =  Index<MemoryFileInfo>.Empty;
            }
        }

        [MethodImpl(Inline)]
        ushort FindIndex(MemoryAddress @base)
        {
            var count = FileCount;
            ref readonly var src = ref Addresses.First;
            for(ushort i=0; i<FileCount; i++)
                if(skip(src,i) == @base)
                    return i;
            return 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => MemoryFiles.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => MemoryFiles.IsNonEmpty;
        }

        public uint FileCount
        {
            [MethodImpl(Inline)]
            get => MemoryFiles.Count;
        }

        public ref readonly MemoryFile this[ushort index]
        {
            [MethodImpl(Inline)]
            get => ref MemoryFiles[index];
        }

        public ref readonly MemoryFile this[MemoryAddress @base]
        {
            [MethodImpl(Inline)]
            get => ref MemoryFiles[FindIndex(@base)];
        }

        public Index<MemoryFileInfo> Descriptions
        {
            [MethodImpl(Inline)]
            get => FileInfo;
        }

        public void Dispose()
        {
            var count = FileCount;
            if(count != 0)
            {
                for(ushort i=0; i<count; i++)
                    this[i].Dispose();

                MemoryFiles.Clear();
                Addresses.Clear();
            }
        }

        public static MappedFiles Empty
        {
            [MethodImpl(Inline)]
            get => new MappedFiles(Index<MemoryFile>.Empty);
        }
    }
}