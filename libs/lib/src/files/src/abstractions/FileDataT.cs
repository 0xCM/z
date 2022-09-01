//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FileData<T>
    {
        readonly Dictionary<FilePath,T> Data;

        public FileData()
        {
            Data = new();
        }

        protected FileData(Dictionary<FilePath,T> src)
        {
            Data = src;
        }

        public ICollection<FilePath> Paths
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Count;
        }

        public T this[FilePath path]
        {
            [MethodImpl(Inline)]
            get => Data[path];
        }

        public ConstLookup<FilePath,T> ToLookup()
            => Data;

        public Index<Paired<FilePath,T>> Entries
            => Data.Map(x => Tuples.paired(x.Key,x.Value));
    }
}