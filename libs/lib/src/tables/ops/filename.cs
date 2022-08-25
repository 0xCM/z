//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        public static FS.FileName filename(TableId id)
            => filename(id, FS.Csv);

        public static FS.FileName filename(TableId id, FileExt ext)
            => FS.file(id.Format(), ext);

        public static FS.FileName filename<T>()
            where T : struct
                => filename<T>(FS.Csv);

        public static FS.FileName filename<T>(FileExt ext)
            where T : struct
                => filename(identify<T>());

        public static FS.FileName filename<T>(string prefix)
            where T : struct
                => FS.file(string.Format("{0}.{1}", prefix, identify<T>()), FS.Csv);
    }
}