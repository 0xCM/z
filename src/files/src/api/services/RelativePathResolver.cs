//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Roslyn.Utilities;

    public class RelativePathResolver
    {
        public readonly ReadOnlySeq<IDbArchive> Search;

        public readonly IDbArchive Root;

        readonly ReadOnlySeq<string> SearchNames;

        readonly string RootName;
        
        public RelativePathResolver(IDbArchive root, ReadOnlySeq<IDbArchive> search)
        {
            Root = root;
            Search = search;
            RootName = root.Root.Name;
            SearchNames = Search.Map(x => x.Root.Name.Format());
        }

        public FilePath ResolvePath(FolderPath @base, RelativeFilePath reference)
        {
            var resolvedPath = FileUtilities.ResolveRelativePath(reference.Name, @base.Name, Root.Root.Name, SearchNames, x => FS.exists(FS.path(x)));
            if (resolvedPath == null)
            {
                return FilePath.Empty;
            }

            return FS.path(FileUtilities.TryNormalizeAbsolutePath(resolvedPath));
        }
    }
}