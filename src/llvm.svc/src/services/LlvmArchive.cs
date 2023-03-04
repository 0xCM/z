//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    class LlvmArchive : IRootedArchive
    {
        public readonly IRootedArchive Root;

        public readonly ProjectId ProjectId;

        [MethodImpl(Inline)]
        public LlvmArchive(IRootedArchive root, ProjectId name)
        {
            Root = root;
            ProjectId = name;
        }

        public IDbArchive BuildRoot()
            => Root.Sources(build);

        public Files BuildFiles()
            => BuildRoot().Files();

        public Files BuildFiles(FileKind kind)
            => BuildRoot().Files(kind).Array();

        public Files BuildFiles(params FileKind[] kinds)
            => BuildRoot().Files(kinds);

        public Files Files()
            => Root.Files();

        public Files Files(FileKind kind)
            => Root.Files(kind).Array();

        FolderPath IRootedArchive.Root
        {
            [MethodImpl(Inline)]
            get => Root.Root;
        }
    }
}