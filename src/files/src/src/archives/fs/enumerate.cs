//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct FS
    {
        public static IEnumerable<FilePath> enumerate(FolderPath src, Func<FilePath,bool> predicate, bool recurse = true)
        {
            foreach(var file in Directory.EnumerateFiles(src.Name, "*", options(recurse)))
            {
                var path = FS.path(file);
                if(predicate(path))
                    yield return path;
            }
        }

        [MethodImpl(Inline), Op]
        public static IEnumerable<FileUri> enumerate(FolderPath root, FileKind kind, bool recurse)
            => enumerate(root, recurse, kind.Ext());

        [MethodImpl(Inline), Op]
        public static IEnumerable<FileUri> enumerate(FolderPath src, bool recurse, FileExt ext)
            => files(src, ext.SearchPattern, recurse);

        public static IEnumerable<FileUri> enumerate(FolderPath src, string pattern, bool recurse)
        {
            if(src.Exists)
                foreach(var file in Directory.EnumerateFiles(src.Name, pattern, options(recurse)))
                    yield return new FileUri(file);
        }

        public static IEnumerable<FileUri> enumerate(FolderPath src, bool recurse, params FileKind[] kinds)
        {
            if(src.Exists)
            {
                foreach(var kind in kinds)
                foreach(var file in Directory.EnumerateFiles(src.Name, kind.SearchPattern(), options(recurse)))
                    yield return new FileUri(file);
            }            
        }

        public static IEnumerable<FileUri> enumerate(FolderPath src, bool recurse, params FileExt[] extensions)
        {
            if(src.Exists)
            {
                foreach(var ext in extensions)
                foreach(var file in Directory.EnumerateFiles(src.Name, ext.SearchPattern, options(recurse)))
                    yield return new FileUri(file);
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