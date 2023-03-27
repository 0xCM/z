//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class FileIndex
    {
        public static FileIndex create()
            => new();
        public static FileTypes types(params Assembly[] src)
            => new (src.Types().Tagged<FileTypeAttribute>().Concrete().Map(x => (IFileType)Activator.CreateInstance(x)).ToHashSet());     

        public static FileIndexEntry entry(MemoryFile src)
        {
            var hash = FS.hash(src);
            return new FileIndexEntry{
                Path = src.Path,
                FileHash = hash.FileHash,                
            };
        }

        public static FileIndexEntry entry(FilePath src)
        {
            var hash = FS.hash(src);
            var dst = new FileIndexEntry();
            dst.Path = src;
            dst.FileHash = hash.FileHash;
            return dst;
        }

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

        readonly ConcurrentDictionary<FilePath, FileIndexEntry> PathLookup = new();

        readonly ConcurrentDictionary<Hash128, FileIndexEntry> HashLookup = new();

        readonly ConcurrentDictionary<FileKind, ConcurrentBag<FileIndexEntry>> KindLookup = new();

        readonly ConcurrentDictionary<Hash128, ConcurrentBag<FileIndexEntry>> _Duplicates = new();

        ReadOnlySeq<FileIndexEntry> SortedEntries;

        public FileIndex()
        {

        }


        public FileIndex Seal()
        {
            SortedEntries = HashLookup.Values.Array().Sort().Resequence();
            return this;
        }

        public ReadOnlySeq<FileIndexEntry> Sorted()
            => SortedEntries;
            
        public Outcome<FileIndexEntry> Include(FilePath src)
        {
            var included = false;
            var entry = FileIndex.entry(src);
            var kind = src.FileKind();
            var hash = FS.hash(src);
            if(PathLookup.TryAdd(src, entry))
            {
                included = HashLookup.TryAdd(hash.ContentHash, entry);
                if(!included)
                    _Duplicates.AddOrUpdate(hash.ContentHash, bag(entry), (_,b) => include(entry,b));
            }
            KindLookup.AddOrUpdate(kind, bag(entry), (_,b) => include(entry,b));
            return (included,entry);
        }

        public void Include(IEnumerable<FilePath> src)
            => iter(src, path => Include(path), true);

        public ICollection<FileIndexEntry> Members()
            => PathLookup.Values;
        
        public ICollection<FileIndexEntry> Distinct()
            => HashLookup.Values;

        public ICollection<FilePath> Paths
            => PathLookup.Keys;
        
        public ICollection<FileKind> Kinds
            => KindLookup.Keys;
        
        public IEnumerable<FileIndexEntry> Members(FileKind kind)
            => KindLookup[kind];
    }
}