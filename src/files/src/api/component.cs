//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [Op]
        public static FileName component(PartName part, FileExt ext)
            => FS.file(string.Format("z0.{0}", part.Format()), ext);

        [Op]
        public static FileName component(PartName part, FileExt x1, FileExt x2)
            => FS.file(string.Format("z0.{0}", part.Format()), x1, x2);

        public static ReadOnlySeq<string> components(FolderPath src)
            => src.Format(PathSeparator.FS).Remove(":").Split(Chars.FSlash);
    }
}