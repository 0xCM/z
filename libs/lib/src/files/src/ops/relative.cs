//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static RelativePath relative(PathPart name)
            => new RelativePath(name);

        [Op]
        public static RelativeFilePath relative(FS.FolderPath root, FilePath src)
            => new RelativeFilePath(relative(Path.GetRelativePath(root.Format(), src.Format())));
    }
}