//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DbTargets : IDbTargets
    {
        public readonly DbArchive DbFiles {get;}

        [MethodImpl(Inline)]
        public DbTargets(FS.FolderPath root, string scope)
        {
            DbFiles = root + FS.folder(scope);
        }

        [MethodImpl(Inline)]
        public DbTargets(FS.FolderPath root)
        {
            DbFiles = root;
        }

        public FS.FolderPath Root
            => DbFiles;

        public string Format()
            => Root.Format();

        public override string ToString()
            => Format();

        public static DbTargets Empty => new DbTargets(FS.FolderPath.Empty);
    }
}