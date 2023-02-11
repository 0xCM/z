//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static RelativePath relative(PathPart name)
            => new RelativePath(name);

        [Op]
        public static RelativeFilePath relative(FolderPath root, FilePath src)
            => new RelativeFilePath(relative(Path.GetRelativePath(root.Format(), src.Format())));


        public static IEnumerable<RelativeFilePath> relative(FolderPath root, IEnumerable<FilePath> src)
            => src.Select(x => relative(root,x));            
    }
}