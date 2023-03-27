//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.Extensions.FileSystemGlobbing;
    
    using static sys;
    
    partial struct FS
    {
        public static void search(FileQuery q, Action<FilePath> dst)       
            => iter(FS.matcher(q).GetResultsInFullPath(q.Root.Format()), name => dst(path(name)), true);
    }
}