//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public static IMemDb open(FS.FilePath store)
            => open(store,0);

        public static IMemDb open(FS.FilePath store, ByteSize capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity));

        public static IMemDb open(FS.FilePath store, Gb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));

        public static IMemDb open(FS.FilePath store, Mb capacity)
            => Opened.GetOrAdd(store, s =>  new MemDb(s, capacity.Size));
    }
}