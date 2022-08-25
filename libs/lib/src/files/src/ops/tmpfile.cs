//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct FS
    {
        public static FilePath tmpfile()
            => FS.dir(Path.GetTempPath()) + FS.file(string.Format("{0}.{1}", controller().PartName(), timestamp()));
    }
}