//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;

    using I0 = System.IO;
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static Files files(params FilePath[] src)
            => new Files(src);

        [MethodImpl(Inline), Op]
        public static Deferred<FilePath> files(FolderPath root, FileKind kind, bool recurse)
            => files(root, recurse, kind.Ext());

        [MethodImpl(Inline), Op]
        public static Deferred<FilePath> files(FolderPath src, bool recurse)
            => files(src, "*.*", recurse);

        [MethodImpl(Inline), Op]
        public static Deferred<FilePath> files(FolderPath src, bool recurse, FileExt ext)
            => files(src, ext.SearchPattern, recurse);

        [MethodImpl(Inline), Op]
        public static Deferred<FilePath> files(FolderPath src, bool recurse, params FileExt[] ext)
            => files(src, pattern(ext), recurse);

        [MethodImpl(Inline), Op]
        public static Deferred<FilePath> files(FolderPath src, string pattern, bool recurse)
            => EnumerateFiles(src, pattern, recurse);

        static Deferred<FilePath> EnumerateFiles(FolderPath src, string pattern, bool recurse, bool casematch = false)
            => !exists(src) ? Algs.defer<FilePath>() : Algs.defer(from f in Directory.EnumerateFiles(src.Name, pattern, SearchOptions(recurse, casematch)) select path(f));

        [MethodImpl(Inline)]
        static EnumerationOptions SearchOptions(bool recurse, bool casematch = false, FileAttributes? skip = null)
            => new EnumerationOptions{
                RecurseSubdirectories = recurse,
                AttributesToSkip = skip ?? 0,
                MatchCasing = casematch ? MatchCasing.CaseSensitive : MatchCasing.CaseInsensitive,
                MatchType = MatchType.Win32
            };
    }
}