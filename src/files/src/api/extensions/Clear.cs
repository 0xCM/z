//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static FilePath PartPath(this IPart part)
            => FS.path(part.Owner.Location);

        [Op]
        public static FolderPath Clear(this FolderPath src, bool recurse = false)
        {
            FS.clear(src, recurse);
            return src;
        }

        [Op]
        public static List<FilePath> Clear(this FolderPath src, List<FilePath> dst, bool recurse = false)
            => FS.clear(src, dst, recurse);

        public static FilePath CopyTo(this FilePath src, FilePath dst, bool overwrite = true)
            => FS.copy(src, dst, overwrite);

        [Op]
        public static FilePath CopyTo(this FilePath src, FolderPath dst, bool overwrite = true)
            => FS.copy(src, dst, overwrite);

        [Op]
        public static Files Clear(this Files src)
            => FS.clear(src);

    }
}