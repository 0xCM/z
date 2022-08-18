//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial struct FS
    {
        [Op]
        public static string missing(FS.FilePath src)
            => Msg.DoesNotExist.Format(src);

        [Op]
        public static string missing(FS.FolderPath src)
            => Msg.DirDoesNotExist.Format(src);
    }
}