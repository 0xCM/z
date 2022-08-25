//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static PathPart normalize(PathPart src)
            => text.remove(src.Text.Replace('\\', '/'), "file:///");
    }
}