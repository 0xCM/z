//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiPackArchive : IApiPackArchive
    {
        [MethodImpl(Inline)]
        public static ApiPackArchive create(FS.FolderPath root)
            => new ApiPackArchive(root);

        public readonly FS.FolderPath Root;

        [MethodImpl(Inline)]
        ApiPackArchive(FS.FolderPath root)
        {
            Root = root;
        }

        FS.FolderPath IFileArchive.Root
            => Root;
    }
}