//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProjectWorkspace : IProjectWorkspace
    {
        static FS.FilePath target(IProjectWorkspace project, string name, FileKind kind = FileKind.Log)
            => project.BuildOut()+ FS.file(name, kind.Ext());

        public static WsLog log(FS.FilePath dst, bool overwrite = true)
            => new (dst, overwrite);

        public static WsLog log(IProjectWorkspace project, string name, FileKind kind = FileKind.Log, bool overwrite = true)
            => log(target(project,name,kind), overwrite);

        public static IProjectWorkspace load(FS.FolderPath root, ProjectId id)
            => new ProjectWorkspace(root, id);

        public static IProjectWorkspace load(IRootedArchive root, ProjectId id)
            => new ProjectWorkspace(root, id);

        public ProjectId ProjectId {get;}

        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        public ProjectWorkspace(FS.FolderPath src, ProjectId id)
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