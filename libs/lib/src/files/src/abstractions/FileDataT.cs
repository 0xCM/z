//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FileData<T>
    {
        readonly Dictionary<FS.FilePath,T> Data;

        public FileData()
        {
            Data = new();
        }

        protected FileData(Dictionary<FS.FilePath,T> src)
        {
            Data = src;
        }

        public ICollection<FS.FilePath> Paths
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public T this[FS.FilePath path]
        {
            [MethodImpl(Inline)]
            get => Data[path];
        }

        public ConstLookup<FS.FilePath,T> ToLookup()
            => Data;

        public Index<Paired<FS.FilePath,T>> Entries
            => Data.Map(x => core.paired(x.Key,x.Value));
    }
}