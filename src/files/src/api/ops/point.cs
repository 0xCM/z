//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static FilePoint point(FilePath src, LineOffset offset)
            => new FilePoint(src,offset);

        [MethodImpl(Inline), Op]
        public static FilePoint point(FilePath src, Count line, Count col)
            => new FilePoint(src, ((uint)line,(uint)col));
    }
}