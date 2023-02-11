//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;
    

    public class FileIndex
    {
        static ConcurrentBag<T> bag<T>(params T[] src)
        {
            var dst = new ConcurrentBag<T>();
            iter(src, item => dst.Add(item));
            return dst;
        }

        static ConcurrentBag<T> include<T>(T src, ConcurrentBag<T> dst)
        {
            dst.Add(src);
            return dst;
        }

        readonly ConcurrentDictionary<FileUri, HashedFile> PathLookup = new();

        readonly ConcurrentDictionary<Hash128, HashedFile> HashLookup = new();

        readonly ConcurrentDictionary<Hash128, ConcurrentBag<HashedFile>> _Duplicates = new();

        void Include(HashedFile src)
        {
            PathLookup.TryAdd(src.Path, src);
            if(!HashLookup.TryAdd(src.FileHash.ContentHash, src))
                _Duplicates.AddOrUpdate(src.FileHash.ContentHash, bag(src), (_,b) => include(src,b));
        }

        internal FileIndex(IEnumerable<HashedFile> src)
        {
            iter(src, Include, true);
            iter(_Duplicates.Keys, hash => {
                require(HashLookup.TryGetValue(hash, out var file));
                require(_Duplicates.TryGetValue(hash, out var bag));
                bag.Add(file);
                });                     
        }

        public bool Find(FileUri src, out HashedFile dst)
            => PathLookup.TryGetValue(src, out dst);
        
        public ICollection<HashedFile> Members
            => PathLookup.Values;
        
        public ICollection<FileUri> Paths
            => PathLookup.Keys;
        
        public ICollection<KeyValuePair<Hash128,ConcurrentBag<HashedFile>>> Duplicates() 
            => _Duplicates;
        // public IEnumerable<Paired<Hash128,ConcurrentBag<HashedFile>>> Duplicates()
        //     => from entry in LookupByHash where entry.Value.Count > 1 select Tuples.paired(entry.Key, entry.Value);
    }
}