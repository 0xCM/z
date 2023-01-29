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
        readonly Index<MemoryFile> FileIndex;

        readonly Index<MemoryAddress> Addresses;

        readonly Index<MemoryFileInfo> FileInfo;

        internal MappedFiles(Index<MemoryFile> src)
        {
            if(src.Count != 0)
            {
                FileIndex = src.Sort();
                var count = FileIndex.Count;
                Addresses = sys.alloc<MemoryAddress>(count);
                for(var i=0; i<count; i++)
                    Addresses[i] = FileIndex[i].BaseAddress;
                FileInfo = FileIndex.Select(api.describe);
            }
            else
            {
                FileIndex = Index<MemoryFile>.Empty;
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
            get => FileIndex.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => FileIndex.IsNonEmpty;
        }

        public uint FileCount
        {
            [MethodImpl(Inline)]
            get => FileIndex.Count;
        }

        public ref readonly MemoryFile this[ushort index]
        {
            [MethodImpl(Inline)]
            get => ref FileIndex[index];
        }

        public ref readonly MemoryFile this[MemoryAddress @base]
        {
            [MethodImpl(Inline)]
            get => ref FileIndex[FindIndex(@base)];
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

                FileIndex.Clear();
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