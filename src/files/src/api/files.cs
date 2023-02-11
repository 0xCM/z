//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;

    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static Files files(params FilePath[] src)
            => new Files(src);

        [MethodImpl(Inline), Op]
        public static IEnumerable<FilePath> files(FolderPath src, string pattern, bool recurse)
            => EnumerateFiles(src, pattern, recurse);

        static IEnumerable<FilePath> EnumerateFiles(FolderPath src, string pattern, bool recurse, bool casematch = false)
            => !exists(src) ? sys.empty<FilePath>() : from f in Directory.EnumerateFiles(src.Name, pattern, options(recurse)) select new FilePath(f);
    }
}