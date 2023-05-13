//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct FS
    {
        public static FilePath absolute(FilePath src)            
            => FS.path(Path.GetFullPath(src.Format()));

        public static FolderPath absolute(FolderPath src)            
            => FS.dir(Path.GetFullPath(src.Format()));
    }
}