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
        public static IEnumerable<FilePath> files(FolderPath src, Func<FilePath,bool> predicate, bool recurse = true)
        {
            foreach(var file in Directory.EnumerateFiles(src.Name, "*", options(recurse)))
            {
                var path = FS.path(file);
                if(predicate(path))
                    yield return path;
            }
        }

        [MethodImpl(Inline), Op]
        public static IEnumerable<FilePath> files(FolderPath root, FileKind kind, bool recurse)
            => files(root, recurse, kind.Ext());

        [MethodImpl(Inline), Op]
        public static IEnumerable<FilePath> files(FolderPath src, bool recurse, FileExt ext)
            => files(src, ext.SearchPattern, recurse);

        public static IEnumerable<FilePath> files(FolderPath src, string pattern, bool recurse)
        {
            if(src.Exists)
                foreach(var file in Directory.EnumerateFiles(src.Name, pattern, options(recurse)))
                    yield return new FilePath(file);
        }

        public static IEnumerable<FilePath> files(FolderPath src, bool recurse, params FileKind[] kinds)
        {
            if(src.Exists)
            {
                if(kinds.Length != 0)
                {            
                    foreach(var kind in kinds)
                    foreach(var file in Directory.EnumerateFiles(src.Name, kind.SearchPattern(), options(recurse)))
                        yield return new FilePath(file);
                }
                else
                {
                    foreach(var file in Directory.EnumerateFiles(src.Name, "*", options(recurse)))
                        yield return new FilePath(file);
                }
            }            
        }

        public static IEnumerable<FilePath> files(FolderPath src, bool recurse, params FileExt[] extensions)
        {
            if(src.Exists)
            {
                if(extensions.Length != 0)
                {
                    foreach(var ext in extensions)
                    foreach(var file in Directory.EnumerateFiles(src.Name, ext.SearchPattern, options(recurse)))
                        yield return new FilePath(file);
                }
                else
                {
                    foreach(var file in Directory.EnumerateFiles(src.Name, "*", options(recurse)))
                        yield return new FilePath(file);
                }
            }            
        }

         static EnumerationOptions options(bool recurse, FileAttributes? skip = null)
            => new EnumerationOptions{
                RecurseSubdirectories = recurse,
                MatchCasing = MatchCasing.CaseInsensitive,
                AttributesToSkip = skip ?? 0,
                MatchType = MatchType.Simple,
                IgnoreInaccessible = false,                
            };                
    }
}