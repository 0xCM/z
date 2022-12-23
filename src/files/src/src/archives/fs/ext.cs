//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static FileExt ext(PathPart name)
            => new FileExt(name);

        [MethodImpl(Inline), Op]
        public static FileExt ext(PathPart a, PathPart b)
            => new FileExt(a,b);

        [MethodImpl(Inline), Op]
        public static FileExt ext(string a, string b)
            => new FileExt(a, b);

        [MethodImpl(Inline), Op]
        public static FileExt ext(FileExt a, FileExt b)
            => a + b;
    }
}