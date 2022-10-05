//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FilteredArchive
    {
        [MethodImpl(Inline), Op]
        public static FilteredArchive filter(FolderPath src, params FileExt[] ext)
            => new FilteredArchive(src, ext);

        [MethodImpl(Inline), Op]
        public static FilteredArchive filter(FolderPath src, params FileKind[] kinds)
            => new FilteredArchive(src, kinds.Map(x => x.Ext()));

        public static Files search(FolderPath src, FileExt[] ext, uint limit = 0)
            => limit != 0 ? match(src, limit, ext) : match(src, ext);

        public static Files match(FolderPath src, uint max, params FileExt[] ext)
        {
            var files = filter(src, ext).Files().Take(max).Array();
            Array.Sort(files);
            return files;
        }

        public static Files match(FolderPath src, params FileKind[] ext)
        {
            var files = filter(src, ext).Files().Array();
            Array.Sort(files);
            return files;
        }

        public static Files match(FolderPath src, params FileExt[] ext)
        {
            var files = filter(src, ext).Files().Array();
            Array.Sort(files);
            return files;
        }

        public readonly FolderPath Root {get;}

        public string TextFilter {get;}

        public readonly ReadOnlySeq<FileExt> ExtFilter;

        [MethodImpl(Inline)]
        public FilteredArchive(FolderPath root, string filter)
        {
            Root = root;
            TextFilter = filter;
            ExtFilter = Index<FileExt>.Empty;
        }

        [MethodImpl(Inline)]
        public FilteredArchive(FolderPath root, FileExt[] ext)
        {
            Root = root;
            TextFilter = EmptyString;
            ExtFilter = ext;
        }

        // public FilteredArchive Scoped(string name)
        //     => new FilteredArchive(Root + FS.folder(name), );

        public Deferred<FilePath> Files()
            =>  ExtFilter.IsNonEmpty
            ?  Root.EnumerateFiles(ExtFilter.Storage, true)
            :  Root.EnumerateFiles(TextFilter, true);
    }
}