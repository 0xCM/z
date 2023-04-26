//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class FileRelations : Stateless<FileRelations>
    {
        public static RelativePathResolver resolver(IDbArchive root, ReadOnlySeq<IDbArchive> search)
            => new (root,search);

        public static RelativePathResolver resolver(FolderPath root, ReadOnlySeq<FolderPath> search)
            => new (root.DbArchive(),search.Map(x => x.DbArchive()));
        
        public RelativePathResolver Resolver(IDbArchive root, ReadOnlySeq<IDbArchive> search)
            => resolver(root, search);

        public RelativePathResolver Resolver(FolderPath root, ReadOnlySeq<FolderPath> search)
            => resolver(root, search);

    }
}