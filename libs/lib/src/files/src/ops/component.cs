//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [Op]
        public static FS.FileName component(PartId part, FS.FileExt ext)
            => FS.file(string.Format("z0.{0}", part.Format()), ext);

        [Op]
        public static FS.FileName component(PartId part, FS.FileExt x1, FS.FileExt x2)
            => FS.file(string.Format("z0.{0}", part.Format()), x1, x2);
    }
}