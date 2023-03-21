//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiPackArchive : IApiPackArchive
    {
        [MethodImpl(Inline)]
        public static ApiPackArchive create(FolderPath root)
            => new ApiPackArchive(root);

        public readonly FolderPath Root;

        [MethodImpl(Inline)]
        ApiPackArchive(FolderPath root)
        {
            Root = root;
        }

        FolderPath IRootedArchive.Root
            => Root;
    }
}