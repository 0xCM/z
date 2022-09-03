//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Outcome<Arrow<FilePath>> LinkTo(this FilePath link, FilePath dst, bool deleteExising = false)
            => FS.symlink(link, dst, deleteExising);
    }
}