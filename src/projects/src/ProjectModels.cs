//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class ProjectModels : Channeled<ProjectModels>
    {        
        public IProject CreateProject(ProjectKind kind, FolderPath root)
        {
            var project = default(IProject);
            var config = ConfigFile.Empty;
            var archive = root.DbArchive();
            var develop = LaunchScript.Empty;
            var workpsace = WorkspaceFile.Empty;
            if(ConfigFile.path(root).Exists)
                config = ProjectServices.configuration(root);
            else
            {
                config = ProjectServices.configure(kind, root);
                ProjectServices.save(Channel, config);
            }
            if(LaunchScript.path(root).Exists)
            {
                develop = LaunchScript.load(root);
            }
            else
            {
                develop = LaunchScript.create(root);
                ProjectServices.save(Channel, develop);
            }

            if(WorkspaceFile.path(root).Exists)
            {

            }
            else
            {
                workpsace = new WorkspaceFile(WorkspaceFile.path(root), new WorkspaceFolder(@string.Empty, FS.dir(".")));
                ProjectServices.save(Channel, workpsace);
            }

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