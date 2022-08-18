//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static FS.FileName Component(this PartId part, FS.FileExt ext)
            => FS.component(part, ext);

        [Op]
        public static FS.FileName Component(this PartId part, FS.FileExt x1, FS.FileExt x2)
            => FS.component(part, x1, x2);
    }
}