//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public record class Project : IProject
        {
            public readonly FolderPath Root;

            public readonly ProjectKind Kind;
        
            public Project(ProjectKind kind, FolderPath root)
            {
                Kind = kind;
                Root = root;
            }

            protected Project(ProjectKind kind)
            {
                Kind = kind;
                Root = FolderPath.Empty;
            }            

            FolderPath IProject.Root
                => Root;

            ProjectKind IProject.Kind
                => Kind;
        }
    }
}