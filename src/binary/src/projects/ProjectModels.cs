//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static ProjectSettings;

    public partial class ProjectModels : Channeled<ProjectModels>
    {
        public IProject CreateProject(ProjectKind kind, FolderPath root)
        {
            var project = default(IProject);
            var config = ConfigFile.Empty;
            var archive = root.DbArchive();
            var cfgpath = archive.Path("config", FileKind.Cmd);
            if(cfgpath.Exists)
                config = ProjectSettings.load(root);
            else
                config = ProjectSettings.configure(kind, root);
            switch(kind)
            {
                case ProjectKind.Binary:
                    project = new BinaryProject(root, new FileIndex());
                break;
                default:
                    project = new Project(kind,root);
                break;
            }
            return project;
        }

        public ExecToken SaveProject(IWfChannel channel,  IProject project)
        {
            var flow = channel.Running($"Saving project {project.Root}");

            return channel.Ran(flow, $"Saved project {project.Root}");
        }
    }
}