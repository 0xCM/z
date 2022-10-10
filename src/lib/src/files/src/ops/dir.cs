//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static FilePath path(string name)
            => new FilePath(name);

        public static FolderPath dir(FileUri src)
            => new FolderPath(text.replace(src.LocalPath, Chars.FSlash, Chars.BSlash));
    }
}