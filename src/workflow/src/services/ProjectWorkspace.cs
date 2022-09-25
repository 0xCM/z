//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectWorkspace : IProjectWorkspace
    {
        public ProjectId ProjectId {get;}

        public FolderPath Root {get;}

        [MethodImpl(Inline)]
        public ProjectWorkspace(FolderPath src, ProjectId id)
        {
            Root = src;
            ProjectId = id;
        }

        [MethodImpl(Inline)]
        public ProjectWorkspace(IRootedArchive src, ProjectId id)
        {
            Root = src.Root;
            ProjectId = id;
        }
    }
}