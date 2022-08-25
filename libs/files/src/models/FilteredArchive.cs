//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FilteredArchive : IFilteredArchive
    {
        public FS.FolderPath Root {get;}

        public string TextFilter {get;}

        public Index<FileExt> ExtFilter {get;}

        [MethodImpl(Inline)]
        public FilteredArchive(FS.FolderPath root, string filter)
        {
            Root = root;
            TextFilter = filter;
            ExtFilter = Index<FileExt>.Empty;
        }

        [MethodImpl(Inline)]
        public FilteredArchive(FS.FolderPath root, FileExt[] ext)
        {
            Root = root;
            TextFilter = EmptyString;
            ExtFilter = ext;
        }

        public Index<FS.FolderPath> Directories()
            => Root.SubDirs(true);

        public Deferred<FilePath> Files()
            =>  ExtFilter.IsNonEmpty
            ?  Root.EnumerateFiles(ExtFilter, true)
            :  Root.EnumerateFiles(TextFilter, true);
    }
}