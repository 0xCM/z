//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static FolderPath dir(string name)
            => new FolderPath(name);

        [MethodImpl(Inline), Op]
        public static FilePath path(string name)
            => new FilePath(name);

        [MethodImpl(Inline), Op]
        static PathPart normalize(PathPart src)
            => text.remove(src.Text.Replace('\\', '/'), "file:///");

        [Op]
        public static string SearchPattern(FileExt[] src)
            => string.Join(";*.", src.Select(e => e.Name));
    }
}