//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [Op]
        public static string missing(FilePath src)
            => Msg.DoesNotExist.Format(src);

        [Op]
        public static string missing(FolderPath src)
            => Msg.DirDoesNotExist.Format(src);
    }
}