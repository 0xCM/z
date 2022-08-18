//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static Outcome<Arrow<FS.FilePath>> LinkTo(this FS.FilePath link, FS.FilePath dst, bool deleteExising = false)
            => FS.symlink(link, dst, deleteExising);
    }
}