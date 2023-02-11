//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    { 
        public static FileIndex index(IEnumerable<FileUri> src)
        {
            var files = new HashedFiles();
            files.Include(src);
            return files.Index();
        }
    }
}