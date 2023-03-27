//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class FolderIndex
    {
        ConcurrentDictionary<FolderPath, FolderIndexEntry> Lookup = new();

        ConcurrentDictionary<Hash32, FolderIndexEntry> HashLookup = new();

        ReadOnlySeq<FolderIndexEntry> SortedEntries;

        public static FolderIndexEntry entry(FolderPath src)
        {
            var dst = new FolderIndexEntry();
            dst.Path  = src;
            return dst;
        }

        public FolderIndex()
        {

        }

        public FolderIndex Seal()
        {
            SortedEntries = Members().Array().Sort().Resequence();
            return this;
        }

        public void Include(FolderPath src)
        {
            var e = entry(src);
            Lookup.TryAdd(src, e);
            HashLookup.TryAdd(src.Hash, e);
        }

        public void Include(IEnumerable<FolderPath> src)
        {
            iter(src, Include, true);
        }

        public ICollection<FolderIndexEntry> Members()
            => Lookup.Values;

        public ReadOnlySeq<FolderIndexEntry> Sorted()
            => SortedEntries;
    }
}