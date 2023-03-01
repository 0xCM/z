//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

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

        readonly ConcurrentDictionary<FilePath, HashedFile> PathLookup = new();

        readonly ConcurrentDictionary<Hash128, HashedFile> HashLookup = new();

        readonly ConcurrentDictionary<Hash128, ConcurrentBag<HashedFile>> _Duplicates = new();

        public FileIndex()
        {

        }

        bool Include(HashedFile src)
        {
            var included = false;
            if(PathLookup.TryAdd(src.Path, src))
            {
                included = HashLookup.TryAdd(src.FileHash.ContentHash, src);
                if(!included)
                    _Duplicates.AddOrUpdate(src.FileHash.ContentHash, bag(src), (_,b) => include(src,b));
            }
            return included;
        }

        public bool Include(FilePath src)
            => Include(FS.hash(src));

        public void Include(IEnumerable<FilePath> src)
        {
            iter(src, path => Include(FS.hash(path)), true);
        }

        public bool Find(FileUri src, out HashedFile dst)
            => PathLookup.TryGetValue(src, out dst);
        
        public ICollection<HashedFile> Members
            => PathLookup.Values;
        
        public ICollection<HashedFile> Unique
            => HashLookup.Values;

        public ICollection<FilePath> Paths
            => PathLookup.Keys;
        
        public ICollection<KeyValuePair<Hash128,ConcurrentBag<HashedFile>>> Duplicates 
            => _Duplicates;
    }
}