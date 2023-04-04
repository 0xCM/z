//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ProjectModels;

    public class ProjectStores : Channeled<ProjectStores>
    {
        public void SaveProject(IProject src)
        {
            
        }
        public Workspace LoadWorkspace(FilePath src)
        {
            return default;

        }

        record class ProjectDef
        {
            public @string Name;

            public ProjectKind ProjectKind;

            public FolderPath Root;
        }


        record class ProjectFlows
        {
            public FolderPath Source;

            public ProjectFlow[] Steps;
        }

        record class ProjectFlow
        {
            public @string Command;

        }

        record class WorkspaceDef
        {
            public @string Name;

            public ProjectDef[] Projects;
        }
    }
}
