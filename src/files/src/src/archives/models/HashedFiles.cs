//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class HashedFiles
    {
        readonly ConcurrentBag<HashedFile> Buffer;

        public HashedFiles()
        {
            Buffer = new();
        }

        public void Include(FileUri src)
        {
            Buffer.Add(FS.hash(src));
        }

        public void Include(IEnumerable<FileUri> src)
            => iter(src, file => Buffer.Add(FS.hash(file)), true);

        public FileIndex Index()
            => new (Buffer);
    }
}