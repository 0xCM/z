//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    partial struct FS
    {
        public static FS.FilePath tmpfile()
            => FS.dir(Path.GetTempPath()) + FS.file(string.Format("{0}.{1}", controller().PartName(), core.timestamp()));
    }
}