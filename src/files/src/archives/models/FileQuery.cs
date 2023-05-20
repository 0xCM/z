//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FileQuery : PathQuery<FileQuery>
    {
        public static FileQuery create(IDbArchive src, params FileExt[] ext)
            => create(src.Root, ext);
            
        public static FileQuery create(FolderPath src, params FileExt[] ext)
        {
            var filter = FileFilter.Empty;
            if(ext.Length != 0)
                filter.Extensions = ext;
            else
                filter.Inclusions = sys.array(SearchPattern.All);
            return new FileQuery(src,filter);
        }

        public static FileQuery create(FolderPath src, string match, params FileExt[] ext)
        {
            var dst = new FileQuery();
            var filter = FileFilter.Empty;
            filter.Extensions = ext;
            filter.Inclusions = sys.array(pattern(match));
            return new FileQuery(src,filter);
        }

        [MethodImpl(Inline), Op]
        static SearchPattern pattern(params string[] src)
            => string.Join(Chars.Pipe, src);

        public FileFilter Filter;

        public FileQuery()
            : base(FolderPath.Empty)
        {
            Filter = FileFilter.Empty;
        }

        public FileQuery(FolderPath root)
            : base(root)
        {
            Filter = FileFilter.Empty;
        }

        public FileQuery(FolderPath root, FileFilter filter)
            : base(root)
        {
            Filter = filter;
        }

        public static FileQuery Empty => new();
    }
}