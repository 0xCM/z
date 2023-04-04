//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public class Workspace : IProject
        {
            public readonly WorkspaceFile File;

            public readonly ReadOnlySeq<IProject> Projects;

            public Workspace(WorkspaceFile file)
            {
                File = file;
                Projects = sys.empty<IProject>();
            }

            public Workspace(WorkspaceFile file, params IProject[] projects)
            {
                File = file;
                Projects = projects;
            }

            public ProjectKind Kind 
                => ProjectKind.Aggregate;
            
            public IDbArchive Root 
                => File.Path.FolderPath.DbArchive();

            public @string Name 
                => Root.Name;

        }
    }
}