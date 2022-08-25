//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [Op]
        public static FileName Component(this PartId part, FileExt ext)
            => FS.component(part, ext);

        [Op]
        public static FileName Component(this PartId part, FileExt x1, FileExt x2)
            => FS.component(part, x1, x2);
    }
}