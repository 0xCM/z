//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static FilePath Absolute(this FileUri src)
            => FS.absolute(src);

        public static FilePath Absolute(this FilePath src)
            => FS.absolute(src);

        public static FolderPath Absolute(this FolderPath src)
            => FS.absolute(src);
    }
}