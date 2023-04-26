//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [Op]
        public static NestedFolder nested(FolderPath root, FolderPath src)
            => new NestedFolder(root, components(src));
    }
}