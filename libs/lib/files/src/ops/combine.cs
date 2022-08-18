//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static FS.FileExt combine(FS.FileExt x1, FS.FileExt x2)
            => x1 + x2;

        [Op]
        public static PathPart combine(in RelativePath src, FileName file, PathSeparator sep = PathSeparator.FS, bool quote = false)
            => string.Format("{0}" + $"{(char)sep}" + "{1}", src.Format(sep), file);
    }
}