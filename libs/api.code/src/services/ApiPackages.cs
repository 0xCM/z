//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiPackages : IRootedArchive
    {
        public readonly FolderPath Root;

        [MethodImpl(Inline)]
        public ApiPackages(FolderPath root)
        {
            Root = root;
        }

        FolderPath IRootedArchive.Root
            => Root;

        public FolderPath ResPackDir()
            => Root + FS.folder("respack");

        public FilePath ResPackLib()
            => ResPackDir() + FS.file("z0.respack", FS.Dll);

        [MethodImpl(Inline)]
        public static implicit operator ApiPackages(FolderPath root)
            => new ApiPackages(root);
    }
}