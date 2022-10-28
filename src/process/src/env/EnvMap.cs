//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EnvMap
    {
        public static DbArchive archive(string src)
            => new DbArchive(FS.dir(src));

        public static FolderPath folder(string src)
            => FS.dir(src);

        public static FolderPaths folders(ReadOnlySpan<string> src)
            => src.Map(FS.dir);

        public static IncludePath include(string src)
            => new IncludePath(folder(src));

        public static IncludePath include(FolderPath src)
            => new IncludePath(src);
    }
}