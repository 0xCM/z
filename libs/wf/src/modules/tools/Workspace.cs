//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Workspace : IWorkspace
    {
        readonly IDbArchive Archive;

        public FolderPath Root {get;}

        public readonly ReadOnlySeq<IWorkspace> Deps;

        [MethodImpl(Inline)]
        public Workspace(IDbArchive archive)
        {
            Archive = archive;
            Root = archive.Root;
            Deps = sys.empty<IWorkspace>();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Archive == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Archive != null;
        }

        public IDbArchive Location
        {
            [MethodImpl(Inline)]
            get => Archive;
        }

        public Deferred<FileUri> Members()
            => IsNonEmpty ? Location.Enumerate() : sys.defer<FileUri>();
    }
}