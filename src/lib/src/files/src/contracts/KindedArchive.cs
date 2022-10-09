//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class KindedArchive<K> : IKindedArchive<K>
        where K : IFileKind<K>, new()

    {
        public FolderPath Root {get;}

        public abstract Deferred<FileUri> Files(K kind);

        protected KindedArchive(FolderPath root)
        {
            Root = root;
        }
    }
}