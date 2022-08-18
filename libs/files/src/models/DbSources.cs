//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DbSources : IDbSources
    {
        public readonly DbArchive DbFiles {get;}

        [MethodImpl(Inline)]
        public DbSources(FS.FolderPath root, string scope)
        {
            DbFiles = root + FS.folder(scope);
        }

        [MethodImpl(Inline)]
        public DbSources(FS.FolderPath root)
        {
            DbFiles = root;
        }

        [MethodImpl(Inline)]
        public DbSources(IRootedArchive root)
        {
            DbFiles = new DbArchive(root.Root);
        }

        public FS.FolderPath Root
            => DbFiles;

        public string Format()
            => DbFiles.Format();

        public override string ToString()
            => Format();

        public static implicit operator FS.FolderPath(DbSources src)
            => src.DbFiles;

        public static DbSources Empty => new DbSources(FS.FolderPath.Empty);
    }
}