//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiPackages : IRootedArchive
    {
        public readonly FS.FolderPath Root;

        [MethodImpl(Inline)]
        public ApiPackages(FS.FolderPath root)
        {
            Root = root;
        }

        FS.FolderPath IRootedArchive.Root
            => Root;

        public FS.FolderPath ResPackDir()
            => Root + FS.folder("respack");

        public FilePath ResPackLib()
            => ResPackDir() + FS.file("z0.respack", FS.Dll);

        [MethodImpl(Inline)]
        public static implicit operator ApiPackages(FS.FolderPath root)
            => new ApiPackages(root);
    }
}